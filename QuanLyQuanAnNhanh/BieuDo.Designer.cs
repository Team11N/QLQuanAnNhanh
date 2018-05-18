namespace QuanLyQuanAnNhanh
{
    partial class BieuDo
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
            this.charDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.charDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // charDoanhThu
            // 
            chartArea1.AxisX.Title = "Tháng";
            chartArea1.AxisY.Title = "Tổng tiền (VND)";
            chartArea1.Name = "TongTien";
            this.charDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.charDoanhThu.Legends.Add(legend1);
            this.charDoanhThu.Location = new System.Drawing.Point(1, 2);
            this.charDoanhThu.Name = "charDoanhThu";
            series1.ChartArea = "TongTien";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            series1.XValueMember = "Tháng";
            series1.YValueMembers = "Tổng tiền";
            this.charDoanhThu.Series.Add(series1);
            this.charDoanhThu.Size = new System.Drawing.Size(800, 446);
            this.charDoanhThu.TabIndex = 0;
            this.charDoanhThu.Text = "Doanh Thu";
            // 
            // BieuDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.charDoanhThu);
            this.Name = "BieuDo";
            this.Text = "BieuDo";
            this.Load += new System.EventHandler(this.BieuDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.charDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart charDoanhThu;
    }
}