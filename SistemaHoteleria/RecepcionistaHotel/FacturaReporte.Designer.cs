namespace SistemaHoteleria.RecepcionistaHotel
{
    partial class FacturaReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaReporte));
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaBD = new SistemaHoteleria.RecepcionistaHotel.facturaBD();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bunifuTextbox1 = new Bunifu.Framework.UI.BunifuTextbox();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1TableAdapter = new SistemaHoteleria.RecepcionistaHotel.facturaBDTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.facturaBD;
            // 
            // facturaBD
            // 
            this.facturaBD.DataSetName = "facturaBD";
            this.facturaBD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaHoteleria.RecepcionistaHotel.ReporteFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 56);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1038, 588);
            this.reportViewer1.TabIndex = 0;
            // 
            // bunifuTextbox1
            // 
            this.bunifuTextbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.bunifuTextbox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextbox1.BackgroundImage")));
            this.bunifuTextbox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTextbox1.ForeColor = System.Drawing.Color.Cyan;
            this.bunifuTextbox1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuTextbox1.Icon")));
            this.bunifuTextbox1.Location = new System.Drawing.Point(475, 8);
            this.bunifuTextbox1.Name = "bunifuTextbox1";
            this.bunifuTextbox1.Size = new System.Drawing.Size(159, 42);
            this.bunifuTextbox1.TabIndex = 4;
            this.bunifuTextbox1.text = "ID";
            this.bunifuTextbox1.OnTextChange += new System.EventHandler(this.bunifuTextbox1_OnTextChange);
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.facturaBD;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // FacturaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1038, 644);
            this.Controls.Add(this.bunifuTextbox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURA";
            this.Load += new System.EventHandler(this.FACTURA_Load);
            //((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Bunifu.Framework.UI.BunifuTextbox bunifuTextbox1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private facturaBD facturaBD;
        private facturaBDTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
    }
}