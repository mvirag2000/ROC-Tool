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
        public Series series1 = new Series();
        public Series series2 = new Series();
        public Series series3 = new Series();
        public Series series4 = new Series();
        public Series series5 = new Series();
        public Series series6 = new Series();
        public Series series7 = new Series();   
        public Series series8 = new Series();
        public decimal threshold = 0.50M; //threshold as <double> created some precision problems 
        public double TPR, TNR, FPR, FNR;
        public double precision, accuracy, balanced, f1;
        public double cost;
        public int totalPos, totalNeg;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            series1 = ratesChart.Series.Add("TPR");
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.DarkBlue;
            series1.BorderWidth = 2;

            series2 = ratesChart.Series.Add("TNR");
            series2.ChartType = SeriesChartType.Line;
            series2.Color = Color.DarkOrange;
            series2.BorderWidth = 2;

            series3 = ratesChart.Series.Add("Threshold");
            series3.ChartType = SeriesChartType.Line;
            series3.Color = Color.Red;
            series3.BorderWidth = 1;

            series4 = ratesChart.Series.Add("Dots");
            series4.ChartType = SeriesChartType.Point;
            series4.Color = Color.Black;
            series4.BorderWidth = 3;

            series5 = rocChart.Series.Add("ROC");
            series5.ChartType = SeriesChartType.Line;
            series5.Color = Color.DarkOrange;
            series5.BorderWidth = 2;

            series6 = rocChart.Series.Add("Midline");
            series6.ChartType = SeriesChartType.Line;
            series6.BorderDashStyle = ChartDashStyle.Dash;
            series6.Color = Color.DarkBlue;
            series6.BorderWidth = 1;

            series7 = rocChart.Series.Add("ROCDot");
            series7.ChartType = SeriesChartType.Point;
            series7.Color = Color.Black;
            series7.BorderWidth = 3;
            series7.CustomProperties = "IsXAxisQuantitative=True";

            series8 = costChart.Series.Add("Cost");
            series8.ChartType = SeriesChartType.Line;
            series8.Color = Color.DarkOrange;
            series8.BorderWidth = 2;

            ratesChart.ChartAreas[0].AxisX.Title = "Threshold Value";
            ratesChart.ChartAreas[0].AxisX.Minimum = 0;
            ratesChart.ChartAreas[0].AxisX.Maximum = 1;
            ratesChart.ChartAreas[0].AxisY.Title = "True Pos/Neg Rate";
            ratesChart.ChartAreas[0].AxisY.Minimum = -0.05;
            ratesChart.ChartAreas[0].AxisY.Maximum = 1.05;
            ratesChart.Legends[0].Enabled = false;

            rocChart.ChartAreas[0].AxisX.Title = "False Positive Rate";
            rocChart.ChartAreas[0].AxisX.Minimum = 0;
            rocChart.ChartAreas[0].AxisX.Maximum = 1;
            rocChart.ChartAreas[0].AxisY.Title = "True Positive Rate";
            rocChart.ChartAreas[0].AxisY.Minimum = 0;
            rocChart.ChartAreas[0].AxisY.Maximum = 1;
            rocChart.Legends[0].Enabled = false;

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
                textBox1.Text = resultsTable.Rows.Count.ToString("N");
                textBox2.Text = totalPos.ToString("N");
                textBox3.Text = totalNeg.ToString("N");

                confusionTable = new DataTable();
                confusionTable.Columns.Add("Cutoff", typeof(decimal));
                confusionTable.Columns.Add("TPR", typeof(double));
                confusionTable.Columns.Add("TNR", typeof(double));
                confusionTable.Columns.Add("FPR", typeof(double));
                confusionTable.Columns.Add("FNR", typeof(double));

                for (decimal cutoff = 0.0M; cutoff <= 1.0M; cutoff += 0.01M)
                {
                    var assertPos = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") >= (double) cutoff);  //We need this subtable NOT just its count 
                    int truePos = assertPos.AsEnumerable().Where(row => row.Field<int>("Actual") == 1).Count();
                    int falsePos = assertPos.Count() - truePos;

                    var assertNeg = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") < (double) cutoff);  //We need this subtable NOT just its count 
                    int trueNeg = assertNeg.AsEnumerable().Where(row => row.Field<int>("Actual") == 0).Count();
                    int falseNeg = assertNeg.Count() - trueNeg;

                    TPR = (totalPos > 0) ? (double) truePos / totalPos : 1;
                    TNR = (totalNeg > 0) ? (double) trueNeg / totalNeg : 1;
                    FPR = (totalNeg > 0) ? (double) falsePos / totalNeg : 1;
                    FNR = (totalPos > 0) ? (double) falseNeg / totalPos : 1;

                    DataRow newRow = confusionTable.NewRow();
                    newRow.ItemArray = new object[] { cutoff, TPR, TNR, FPR, FNR }; //Store the rates for display, not the counts 
                    confusionTable.Rows.Add(newRow);
                }
                series5.Points.AddXY(1, 1); //Force upper corner in case sample doesn't have enough FP 
                series6.Points.AddXY(0, 0);
                series6.Points.AddXY(1, 1);
                double prevX = 1;
                double prevY = 1;
                double AUC = 0;
                foreach (DataRow row in confusionTable.Rows)
                {
                    TPR = (double)row["TPR"];
                    TNR = (double)row["TNR"];
                    FPR = (double)row["FPR"];
                    FNR = (double)row["FNR"];
                    series1.Points.AddXY(row["Cutoff"], TPR);
                    series2.Points.AddXY(row["Cutoff"], TNR);
                    series5.Points.AddXY(FPR, TPR);
                    AUC += (prevX - FPR) * (prevY + TPR) / 2;
                    prevX = FPR; prevY = TPR; 
                }
                plotCostChart();
                aucBox.Text = AUC.ToString("F2");
                trackBar1_Scroll(sender, e);
            }
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
                series8.Points.AddXY(row["Cutoff"], computeCost());
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threshold = (decimal)trackBar1.Value / 100;
            ratesChart.Series["Threshold"].Points.Clear();
            for (double i = -0.05; i <= 1.05; i += 0.01)
            {
                series3.Points.AddXY(threshold, i);
            }
            var y1 = confusionTable.AsEnumerable().Where(row => row.Field<decimal>("Cutoff") == threshold); //Single row that matches cutoff 
            ratesChart.Series["Dots"].Points.Clear();
            rocChart.Series["ROCDot"].Points.Clear(); 
            foreach (DataRow row in y1)
            {
                TPR = (double) row["TPR"];
                TNR = (double) row["TNR"];
                FPR = (double) row["FPR"];
                FNR = (double) row["FNR"];
            }
            series4.Points.AddXY(threshold, TPR);
            series4.Points.AddXY(threshold, TNR);
            series7.Points.AddXY(FPR, TPR);

            double TP = TPR * totalPos; //Recover the counts (and lose precision) 
            double TN = TNR * totalNeg;
            double FP = FPR * totalNeg;
            double FN = FNR * totalPos;

            precision = (TP + FP) > 0 ? TP / (TP + FP) : 1; 
            accuracy = (TP + TN) / (totalPos + totalNeg);
            balanced = (TPR + TNR) / 2;
            f1 = 2 * precision * TPR / (precision + TPR);
            costBox.Text = computeCost().ToString();

            cutoffBox.Text = threshold.ToString();
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
    }
}

