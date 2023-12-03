using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ROC_Tool
{
    public partial class Form1 : Form
    {   // DATA DIVISION //
        private Form2 form2;
        public DataTable resultsTable;
        public DataTable confusionTable;
        public Series needle = new Series();
        public Series ratedots = new Series();
        public Series rocdot = new Series();   
        public Series costdot = new Series();
        public Series lineCost = new Series();
        public Series lineROC = new Series();
        public Series lineMid = new Series();
        public Series lineTPR = new Series();
        public Series lineTNR = new Series();
        public decimal threshold = 0.50M; //threshold as <double> created some precision problems 
        public double TPR, TNR, FPR, FNR, cost;
        public double precision, accuracy, balanced, f1;
        public int totalPos, totalNeg;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            costdot = costChart.Series.Add("CostDot");
            costdot.ChartType = SeriesChartType.Point;
            costdot.Color = Color.Black;
            costdot.BorderWidth = 3;

            lineCost = costChart.Series.Add("Cost");
            lineCost.ChartType = SeriesChartType.Line;
            lineCost.Color = Color.DarkOrange;
            lineCost.BorderWidth = 2;

            costChart.ChartAreas[0].AxisX.Title = "Threshold Value";
            costChart.ChartAreas[0].AxisX.Minimum = 0;
            costChart.ChartAreas[0].AxisX.Maximum = 1;
            costChart.ChartAreas[0].AxisY.Title = "Calculated Cost";
            costChart.Legends[0].Enabled = false;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  //Maybe check for file already open
            {
                resultsTable = new DataTable(); 
                resultsTable.Columns.Add("Proba", typeof(double));
                resultsTable.Columns.Add("Actual", typeof(int));
                try
                {
                    using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                    {
                        bool isFirstRow = true;
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            if (isFirstRow)
                            {
                                //Think about creating headers from the file
                                isFirstRow = false;
                            }
                            else
                            {
                                resultsTable.Rows.Add(values);
                            }
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                totalPos = resultsTable.AsEnumerable().Where(row => row.Field<int>("Actual") == 1).Count();
                totalNeg = resultsTable.AsEnumerable().Where(row => row.Field<int>("Actual") == 0).Count();
                textBox1.Text = resultsTable.Rows.Count.ToString("N0");
                textBox2.Text = totalPos.ToString("N0");
                textBox3.Text = totalNeg.ToString("N0");

                confusionTable = BuildConfusionTable(resultsTable);

                plotCostChart();
                plotROCChart(); 
                plotTPRChart(); 
                trackBar1_Scroll(sender, e);
            }
        }
        public void plotTPRChart()
        {
            ratesChart.Series.Clear();

            lineTPR = ratesChart.Series.Add("TPR");
            lineTPR.ChartType = SeriesChartType.Line;
            lineTPR.Color = Color.DarkBlue;
            lineTPR.BorderWidth = 2;

            lineTNR = ratesChart.Series.Add("TNR");
            lineTNR.ChartType = SeriesChartType.Line;
            lineTNR.Color = Color.DarkOrange;
            lineTNR.BorderWidth = 2;

            needle = ratesChart.Series.Add("Threshold");
            needle.ChartType = SeriesChartType.Line;
            needle.Color = Color.Red;
            needle.BorderWidth = 1;

            ratedots = ratesChart.Series.Add("Dots");
            ratedots.ChartType = SeriesChartType.Point;
            ratedots.Color = Color.Black;
            ratedots.BorderWidth = 3;

            ratesChart.ChartAreas[0].AxisX.Title = "Threshold Value";
            ratesChart.ChartAreas[0].AxisX.Minimum = 0;
            ratesChart.ChartAreas[0].AxisX.Maximum = 1;
            ratesChart.ChartAreas[0].AxisY.Title = "True Pos/Neg Rate";
            ratesChart.ChartAreas[0].AxisY.Minimum = -0.05;
            ratesChart.ChartAreas[0].AxisY.Maximum = 1.05;
            ratesChart.Legends[0].Enabled = false;

            ratesChart.Series["TPR"].Points.Clear();
            ratesChart.Series["TNR"].Points.Clear();
            foreach (DataRow row in confusionTable.Rows)
            {
                TPR = (double)row["TPR"];
                TNR = (double)row["TNR"];
                FPR = (double)row["FPR"];
                FNR = (double)row["FNR"];
                lineTPR.Points.AddXY(row["Cutoff"], TPR);
                lineTNR.Points.AddXY(row["Cutoff"], TNR);
            }
        }
        public void plotROCChart()
        {
            rocChart.Series.Clear();
            lineROC = rocChart.Series.Add("ROC");
            lineROC.ChartType = SeriesChartType.Line;
            lineROC.Color = Color.DarkOrange;
            lineROC.BorderWidth = 2;

            lineMid = rocChart.Series.Add("Midline");
            lineMid.ChartType = SeriesChartType.Line;
            lineMid.BorderDashStyle = ChartDashStyle.Dash;
            lineMid.Color = Color.DarkBlue;
            lineMid.BorderWidth = 1;

            rocdot = rocChart.Series.Add("ROCDot");
            rocdot.ChartType = SeriesChartType.Point;
            rocdot.Color = Color.Black;
            rocdot.BorderWidth = 3;
            rocdot.CustomProperties = "IsXAxisQuantitative=True";

            rocChart.ChartAreas[0].AxisX.Title = "False Positive Rate";
            rocChart.ChartAreas[0].AxisX.Minimum = 0;
            rocChart.ChartAreas[0].AxisX.Maximum = 1;
            rocChart.ChartAreas[0].AxisY.Title = "True Positive Rate";
            rocChart.ChartAreas[0].AxisY.Minimum = 0;
            rocChart.ChartAreas[0].AxisY.Maximum = 1;
            rocChart.Legends[0].Enabled = false;

            rocChart.Series["Midline"].Points.Clear();
            rocChart.Series["ROC"].Points.Clear();
            lineROC.Points.AddXY(1, 1); //Force upper corner in case sample doesn't have enough FP 
            lineMid.Points.AddXY(0, 0);
            lineMid.Points.AddXY(1, 1);
            double prevX = 1;
            double prevY = 1;
            double AUC = 0;
            foreach (DataRow row in confusionTable.Rows)
            {
                TPR = (double)row["TPR"];
                TNR = (double)row["TNR"];
                FPR = (double)row["FPR"];
                FNR = (double)row["FNR"];
                lineROC.Points.AddXY(FPR, TPR);
                AUC += (prevX - FPR) * (prevY + TPR) / 2;
                prevX = FPR; prevY = TPR;
            }
            aucBox.Text = AUC.ToString("F2");
        }
        public void plotCostChart()
        {
            costChart.Series["Cost"].Points.Clear();
            foreach (DataRow row in confusionTable.Rows)
            {
                TPR = (double)row["TPR"];
                TNR = (double)row["TNR"];
                FPR = (double)row["FPR"];
                FNR = (double)row["FNR"];
                lineCost.Points.AddXY(row["Cutoff"], computeCost());
            }
        }
        public DataTable BuildConfusionTable(DataTable resultsTable)
        {
            DataTable confusionTable = new DataTable();
            confusionTable.Columns.Add("Cutoff", typeof(decimal));
            confusionTable.Columns.Add("TPR", typeof(double));
            confusionTable.Columns.Add("TNR", typeof(double));
            confusionTable.Columns.Add("FPR", typeof(double));
            confusionTable.Columns.Add("FNR", typeof(double));
            for (decimal cutoff = 0.0M; cutoff <= 1.0M; cutoff += 0.01M)
            {
                var assertPos = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") >= (double)cutoff);  //We need this subtable NOT just its count 
                int truePos = assertPos.AsEnumerable().Where(row => row.Field<int>("Actual") == 1).Count();
                int falsePos = assertPos.Count() - truePos;

                var assertNeg = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") < (double)cutoff);  //We need this subtable NOT just its count 
                int trueNeg = assertNeg.AsEnumerable().Where(row => row.Field<int>("Actual") == 0).Count();
                int falseNeg = assertNeg.Count() - trueNeg;

                TPR = (totalPos > 0) ? (double)truePos / totalPos : 1;
                TNR = (totalNeg > 0) ? (double)trueNeg / totalNeg : 1;
                FPR = (totalNeg > 0) ? (double)falsePos / totalNeg : 1;
                FNR = (totalPos > 0) ? (double)falseNeg / totalPos : 1;

                DataRow newRow = confusionTable.NewRow();
                newRow.ItemArray = new object[] { cutoff, TPR, TNR, FPR, FNR }; //Store the rates for display, not the counts 
                confusionTable.Rows.Add(newRow);
            }
            return confusionTable;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threshold = (decimal)trackBar1.Value / 100;

            // Update the dots // 
            ratesChart.Series["Threshold"].Points.Clear();
            ratesChart.Series["Dots"].Points.Clear();
            rocChart.Series["ROCDot"].Points.Clear();
            costChart.Series["CostDot"].Points.Clear();

            var y1 = confusionTable.AsEnumerable().Where(row => row.Field<decimal>("Cutoff") == threshold); 
            foreach (DataRow row in y1) //Single row that matches cutoff 
            {
                TPR = (double) row["TPR"];
                TNR = (double) row["TNR"];
                FPR = (double) row["FPR"];
                FNR = (double) row["FNR"];
            }
            ratedots.Points.AddXY(threshold, TPR);
            ratedots.Points.AddXY(threshold, TNR);
            rocdot.Points.AddXY(FPR, TPR);
            costdot.Points.AddXY(threshold, computeCost());
            for (double i = -0.05; i <= 1.05; i += 0.01)
            {
                needle.Points.AddXY(threshold, i);
            }

            // Update the text boxes 
            double TP = TPR * totalPos;  
            double TN = TNR * totalNeg;
            double FP = FPR * totalNeg;
            double FN = FNR * totalPos;

            precision = (TP + FP) > 0 ? TP / (TP + FP) : 1; 
            accuracy = (TP + TN) / (totalPos + totalNeg);
            balanced = (TPR + TNR) / 2;
            f1 = 2 * precision * TPR / (precision + TPR);

            costBox.Text = computeCost().ToString();
            cutoffBox.Text = threshold.ToString("F2");
            TPRBox.Text = TPR.ToString("F2");
            TNRBox.Text = TNR.ToString("F2");
            FPRBox.Text = FPR.ToString("F2");
            FNRBox.Text = FNR.ToString("F2");
            precisionBox.Text = precision.ToString("F2");
            accuracyBox.Text = accuracy.ToString("F2");
            balancedBox.Text = balanced.ToString("F2");
            f1Box.Text = f1.ToString("F2");
        }
        public double computeCost()
        {
            cost = TPR * Convert.ToDouble(costTPR.Text);
            cost += TNR * Convert.ToDouble(costTNR.Text);
            cost -= FPR * Convert.ToDouble(costFPR.Text);
            cost -= FNR * Convert.ToDouble(costFNR.Text);
            return cost;
        }
        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2(confusionTable);
                form2.Show();
            }
            else form2.BringToFront();
        }
        private void costTPR_TextChanged(object sender, EventArgs e)
        {
            plotCostChart();
            trackBar1_Scroll(sender, e);
        }
        private void costTNR_TextChanged(object sender, EventArgs e)
        {
            plotCostChart();
            trackBar1_Scroll(sender, e);
        }
        private void costFNR_TextChanged(object sender, EventArgs e)
        {
            plotCostChart();
            trackBar1_Scroll(sender, e);
        }
        private void costFPR_TextChanged(object sender, EventArgs e)
        {
            plotCostChart();
            trackBar1_Scroll(sender, e);
        }
        private void costTPR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the character
            }
        }
        private void costFNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the character
            }
        }
        private void costTNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the character
            }
        }
        private void costFPR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the character
            }
        }
    }
}
