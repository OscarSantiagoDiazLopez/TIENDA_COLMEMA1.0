namespace WinFormsTienda
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            buttonREFRESCAR = new Button();
            lblMonto = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BackColor = Color.Transparent;
            chart1.BorderlineColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(190, 35);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(387, 401);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // buttonREFRESCAR
            // 
            buttonREFRESCAR.BackColor = Color.Orange;
            buttonREFRESCAR.FlatStyle = FlatStyle.Flat;
            buttonREFRESCAR.Font = new Font("Sitka Heading", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            buttonREFRESCAR.Location = new Point(634, 127);
            buttonREFRESCAR.Name = "buttonREFRESCAR";
            buttonREFRESCAR.Size = new Size(122, 48);
            buttonREFRESCAR.TabIndex = 1;
            buttonREFRESCAR.Text = "REFRESCAR";
            buttonREFRESCAR.UseVisualStyleBackColor = false;
            buttonREFRESCAR.Click += buttonREFRESCAR_Click;
            // 
            // lblMonto
            // 
            lblMonto.BackColor = Color.Transparent;
            lblMonto.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonto.Location = new Point(610, 206);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(178, 110);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "MONTO QUE HAN GASTADO LOS USUARIO EN TOTAL:";
            lblMonto.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._________________6_;
            ClientSize = new Size(800, 451);
            Controls.Add(lblMonto);
            Controls.Add(buttonREFRESCAR);
            Controls.Add(chart1);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VENTAS";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button buttonREFRESCAR;
        private Label lblMonto;
    }
}