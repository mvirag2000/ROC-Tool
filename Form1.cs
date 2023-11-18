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
    {
        private Form2 form2;
        public DataTable resultsTable = new DataTable();
        public DataTable confusionTable = new DataTable();
        public Series series1 = new Series();
        public Series series2 = new Series();
        public Series series3 = new Series();
        public Series series4 = new Series();
        public Series series5 = new Series();
        public Series series6 = new Series();
        public Series series7 = new Series();   
        public decimal threshold = 0.50M; //threshold as <double> created some precision problems 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            confusionTable.Columns.Add("Cutoff", typeof(decimal));
            confusionTable.Columns.Add("TPR", typeof(double));
            confusionTable.Columns.Add("TNR", typeof(double));
            confusionTable.Columns.Add("FPR", typeof(double));
            confusionTable.Columns.Add("FNR", typeof(double));

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
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
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

                int totalPos = resultsTable.AsEnumerable().Where(row => row.Field<int>("Actual") == 1).Count();
                int totalNeg = resultsTable.AsEnumerable().Where(row => row.Field<int>("Actual") == 0).Count();
                textBox1.Text = resultsTable.Rows.Count.ToString("N");
                textBox2.Text = totalPos.ToString("N");
                textBox3.Text = totalNeg.ToString("N");

                for (decimal cutoff = 0.0M; cutoff <= 1.0M; cutoff += 0.01M)
                {
                    var assertPos = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") >= (double) cutoff);  //We need this subtable NOT just its count 
                    int truePos = assertPos.AsEnumerable().Where(row => row.Field<int>("Actual") == 1).Count();
                    int falsePos = assertPos.Count() - truePos;

                    var assertNeg = resultsTable.AsEnumerable().Where(row => row.Field<double>("Proba") < (double) cutoff);  //We need this subtable NOT just its count 
                    int trueNeg = assertNeg.AsEnumerable().Where(row => row.Field<int>("Actual") == 0).Count();
                    int falseNeg = assertNeg.Count() - trueNeg;

                    double TPR = (totalPos > 0) ? (double) truePos / totalPos : 1;
                    double TNR = (totalNeg > 0) ? (double) trueNeg / totalNeg : 1;
                    double FPR = (totalNeg > 0) ? (double) falsePos / totalNeg : 1;
                    double FNR = (totalPos > 0) ? (double) falseNeg / totalPos : 1;

                    DataRow newRow = confusionTable.NewRow();
                    newRow.ItemArray = new object[] { cutoff, TPR, TNR, FPR, FNR };
                    confusionTable.Rows.Add(newRow);
                }
                foreach (DataRow row in confusionTable.Rows)
                {
                    series1.Points.AddXY(row["Cutoff"], row["TPR"]);
                    series2.Points.AddXY(row["Cutoff"], row["TNR"]);
                    series5.Points.AddXY(row["FPR"], row["TPR"]);
                    series6.Points.AddXY(row["FPR"], row["FPR"]);
                }
                series5.Points.AddXY(1, 1); //Force upper corner in case sample doesn't have enough FP 
                series6.Points.AddXY(1, 1);
                trackBar1_Scroll(sender, e);
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
                series4.Points.AddXY(threshold, row["TPR"]);
                series4.Points.AddXY(threshold, row["TNR"]);
                series7.Points.AddXY(row["FPR"], row["TPR"]);
            }
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

