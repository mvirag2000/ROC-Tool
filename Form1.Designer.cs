namespace ROC_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ratesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.rocChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FPRBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TNRBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FNRBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TPRBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cutoffBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.precisionBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.accuracyBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.balancedBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.f1Box = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.aucBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ratesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ratesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ratesChart.Legends.Add(legend1);
            this.ratesChart.Location = new System.Drawing.Point(14, 90);
            this.ratesChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ratesChart.Name = "ratesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ratesChart.Series.Add(series1);
            this.ratesChart.Size = new System.Drawing.Size(533, 300);
            this.ratesChart.TabIndex = 2;
            this.ratesChart.Text = "chart1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(69, 396);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBar1.Maximum = 99;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(478, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // rocChart
            // 
            chartArea2.Name = "ChartArea1";
            this.rocChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.rocChart.Legends.Add(legend2);
            this.rocChart.Location = new System.Drawing.Point(749, 90);
            this.rocChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rocChart.Name = "rocChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.rocChart.Series.Add(series2);
            this.rocChart.Size = new System.Drawing.Size(428, 300);
            this.rocChart.TabIndex = 4;
            this.rocChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Positive:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Negative:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(77, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(77, 46);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(77, 66);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FPRBox
            // 
            this.FPRBox.Enabled = false;
            this.FPRBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FPRBox.Location = new System.Drawing.Point(618, 194);
            this.FPRBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FPRBox.Name = "FPRBox";
            this.FPRBox.Size = new System.Drawing.Size(76, 20);
            this.FPRBox.TabIndex = 12;
            this.FPRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(554, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "FPR:";
            this.toolTip1.SetToolTip(this.label4, "This is the rate of false positives. Note that FPR + specificity add to one.");
            // 
            // TNRBox
            // 
            this.TNRBox.Enabled = false;
            this.TNRBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNRBox.Location = new System.Drawing.Point(618, 168);
            this.TNRBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TNRBox.Name = "TNRBox";
            this.TNRBox.Size = new System.Drawing.Size(76, 20);
            this.TNRBox.TabIndex = 14;
            this.TNRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(554, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "TNR:";
            this.toolTip1.SetToolTip(this.label5, "This is the rate of true negatives, also known as specificity. A higher cutoff me" +
"ans more true negatives but also more false ones.");
            // 
            // FNRBox
            // 
            this.FNRBox.Enabled = false;
            this.FNRBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FNRBox.Location = new System.Drawing.Point(618, 142);
            this.FNRBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FNRBox.Name = "FNRBox";
            this.FNRBox.Size = new System.Drawing.Size(76, 20);
            this.FNRBox.TabIndex = 16;
            this.FNRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(554, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "FNR:";
            this.toolTip1.SetToolTip(this.label6, "This is the rate of false negatives. Note that FNR + sensitivity add to one.");
            // 
            // TPRBox
            // 
            this.TPRBox.Enabled = false;
            this.TPRBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPRBox.Location = new System.Drawing.Point(618, 116);
            this.TPRBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TPRBox.Name = "TPRBox";
            this.TPRBox.Size = new System.Drawing.Size(76, 20);
            this.TPRBox.TabIndex = 18;
            this.TPRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(554, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "TPR:";
            this.toolTip1.SetToolTip(this.label7, "This is the rate of true positives, also known as sensitivity. A lower cutoff mea" +
"ns more true postives but also more false ones.");
            // 
            // cutoffBox
            // 
            this.cutoffBox.Enabled = false;
            this.cutoffBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutoffBox.Location = new System.Drawing.Point(618, 90);
            this.cutoffBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cutoffBox.Name = "cutoffBox";
            this.cutoffBox.Size = new System.Drawing.Size(76, 20);
            this.cutoffBox.TabIndex = 20;
            this.cutoffBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(554, 93);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cutoff:";
            this.toolTip1.SetToolTip(this.label8, "This is the threshold value currently selected by the slider control. Cases scoring above the threshold are deemed positive.");
            // 
            // precisionBox
            // 
            this.precisionBox.Enabled = false;
            this.precisionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precisionBox.Location = new System.Drawing.Point(618, 220);
            this.precisionBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.precisionBox.Name = "precisionBox";
            this.precisionBox.Size = new System.Drawing.Size(76, 20);
            this.precisionBox.TabIndex = 28;
            this.precisionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(554, 223);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Precision:";
            this.toolTip1.SetToolTip(this.label9, "This is the rate of predicted positives that are correct."); 
            // 
            // accuracyBox
            // 
this.accuracyBox.Enabled = false;
            this.accuracyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracyBox.Location = new System.Drawing.Point(618, 246);
            this.accuracyBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.accuracyBox.Name = "accuracyBox";
            this.accuracyBox.Size = new System.Drawing.Size(76, 20);
            this.accuracyBox.TabIndex = 26;
            this.accuracyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(554, 249);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Accuracy:";
            this.toolTip1.SetToolTip(this.label10, "This is the intuitive rate of correct predictions, but it can be misleading if the data is imbalanced.");
            // 
            // balancedBox
            // 
            this.balancedBox.Enabled = false;
            this.balancedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancedBox.Location = new System.Drawing.Point(618, 272);
            this.balancedBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.balancedBox.Name = "balancedBox";
            this.balancedBox.Size = new System.Drawing.Size(76, 20);
            this.balancedBox.TabIndex = 24;
            this.balancedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(554, 275);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Balanced:";
            this.toolTip1.SetToolTip(this.label11, "This is the average of the true negative rate and the true positive rate, obviously the best choice for imbalanced data");
            // 
            // f1Box
            // 
            this.f1Box.Enabled = false;
            this.f1Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1Box.Location = new System.Drawing.Point(618, 298);
            this.f1Box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.f1Box.Name = "f1Box";
            this.f1Box.Size = new System.Drawing.Size(76, 20);
            this.f1Box.TabIndex = 22;
            this.f1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(554, 301);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "F1 Score:";
            this.toolTip1.SetToolTip(this.label12, "This is the harmonic mean of precision and recall, another good choice for imbalanced data");
            // 
            // aucBox
            // 
            this.aucBox.Enabled = false;
            this.aucBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aucBox.Location = new System.Drawing.Point(239, 26);
            this.aucBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.aucBox.Name = "aucBox";
            this.aucBox.Size = new System.Drawing.Size(76, 20);
            this.aucBox.TabIndex = 30;
            this.aucBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(172, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "ROC AUC:";
            this.toolTip1.SetToolTip(this.label13, "This is the area under the ROC curve. It measures the overall utility of the model, regardless of the threshold.");
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 450);
            this.Controls.Add(this.aucBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.precisionBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.accuracyBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.balancedBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.f1Box);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cutoffBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TPRBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.FNRBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TNRBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FPRBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rocChart);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.ratesChart);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataVisualization.Charting.Chart ratesChart;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart rocChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox FPRBox;
        private System.Windows.Forms.TextBox TNRBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FNRBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TPRBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cutoffBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox precisionBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox accuracyBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox balancedBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox f1Box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox aucBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

