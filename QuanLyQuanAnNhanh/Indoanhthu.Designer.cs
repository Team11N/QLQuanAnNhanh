namespace QuanLyQuanAnNhanh
{
    partial class Indoanhthu
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpvDoanhThu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FastFoodShopDataSet = new QuanLyQuanAnNhanh.FastFoodShopDataSet();
            this.ReportDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDoanhThuTableAdapter = new QuanLyQuanAnNhanh.FastFoodShopDataSetTableAdapters.ReportDoanhThuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FastFoodShopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDoanhThuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvDoanhThu
            // 
            this.rpvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportDoanhThuBindingSource;
            this.rpvDoanhThu.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDoanhThu.LocalReport.ReportEmbeddedResource = "QuanLyQuanAnNhanh.Indoanhthu.rdlc";
            this.rpvDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.rpvDoanhThu.Name = "rpvDoanhThu";
            this.rpvDoanhThu.ServerReport.BearerToken = null;
            this.rpvDoanhThu.Size = new System.Drawing.Size(800, 450);
            this.rpvDoanhThu.TabIndex = 0;
            // 
            // FastFoodShopDataSet
            // 
            this.FastFoodShopDataSet.DataSetName = "FastFoodShopDataSet";
            this.FastFoodShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportDoanhThuBindingSource
            // 
            this.ReportDoanhThuBindingSource.DataMember = "ReportDoanhThu";
            this.ReportDoanhThuBindingSource.DataSource = this.FastFoodShopDataSet;
            // 
            // ReportDoanhThuTableAdapter
            // 
            this.ReportDoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // Indoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvDoanhThu);
            this.Name = "Indoanhthu";
            this.Text = "Indoanhthu";
            this.Load += new System.EventHandler(this.Indoanhthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FastFoodShopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDoanhThuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDoanhThu;
        private System.Windows.Forms.BindingSource ReportDoanhThuBindingSource;
        private FastFoodShopDataSet FastFoodShopDataSet;
        private FastFoodShopDataSetTableAdapters.ReportDoanhThuTableAdapter ReportDoanhThuTableAdapter;
    }
}