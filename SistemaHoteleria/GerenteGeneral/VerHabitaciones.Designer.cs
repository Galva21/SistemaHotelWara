namespace SistemaHoteleria.GerenteGeneral
{
    partial class VerHabitaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerHabitaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbLogoWaraForm = new System.Windows.Forms.PictureBox();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.cbPrecioMenos = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.tipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaHotelWaraDataSet = new SistemaHoteleria.SistemaHotelWaraDataSet();
            this.bunifuCustomLabel16 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dgvHabitaciones = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtFiltroId = new Bunifu.Framework.UI.BunifuTextbox();
            this.lblTitulo = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tipoTableAdapter = new SistemaHoteleria.SistemaHotelWaraDataSetTableAdapters.TipoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoWaraForm)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaHotelWaraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SEA GARDENS", 100F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(446, 735);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 121);
            this.label1.TabIndex = 122;
            this.label1.Text = "WARA";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SEA GARDENS", 42F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(561, 684);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 51);
            this.label2.TabIndex = 120;
            this.label2.Text = "HOTEL";
            // 
            // pbLogoWaraForm
            // 
            this.pbLogoWaraForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogoWaraForm.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoWaraForm.Image")));
            this.pbLogoWaraForm.Location = new System.Drawing.Point(287, 684);
            this.pbLogoWaraForm.Name = "pbLogoWaraForm";
            this.pbLogoWaraForm.Size = new System.Drawing.Size(153, 172);
            this.pbLogoWaraForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoWaraForm.TabIndex = 121;
            this.pbLogoWaraForm.TabStop = false;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.cbPrecioMenos);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.cbFiltroTipo);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel16);
            this.bunifuCards1.Controls.Add(this.dgvHabitaciones);
            this.bunifuCards1.Controls.Add(this.txtFiltroId);
            this.bunifuCards1.Controls.Add(this.lblTitulo);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(30, 30);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1003, 632);
            this.bunifuCards1.TabIndex = 125;
            // 
            // cbPrecioMenos
            // 
            this.cbPrecioMenos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrecioMenos.FormattingEnabled = true;
            this.cbPrecioMenos.Items.AddRange(new object[] {
            "5000",
            "2000",
            "1000",
            "500",
            "200",
            "100"});
            this.cbPrecioMenos.Location = new System.Drawing.Point(771, 119);
            this.cbPrecioMenos.Name = "cbPrecioMenos";
            this.cbPrecioMenos.Size = new System.Drawing.Size(114, 21);
            this.cbPrecioMenos.TabIndex = 1;
            this.cbPrecioMenos.SelectedIndexChanged += new System.EventHandler(this.cbPrecioMenos_SelectedIndexChanged);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(648, 121);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(113, 16);
            this.bunifuCustomLabel1.TabIndex = 151;
            this.bunifuCustomLabel1.Text = "PRECIO MENOS DE";
            // 
            // cbFiltroTipo
            // 
            this.cbFiltroTipo.DataSource = this.tipoBindingSource;
            this.cbFiltroTipo.DisplayMember = "idTipo";
            this.cbFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroTipo.FormattingEnabled = true;
            this.cbFiltroTipo.Location = new System.Drawing.Point(513, 119);
            this.cbFiltroTipo.Name = "cbFiltroTipo";
            this.cbFiltroTipo.Size = new System.Drawing.Size(114, 21);
            this.cbFiltroTipo.TabIndex = 0;
            this.cbFiltroTipo.ValueMember = "idTipo";
            this.cbFiltroTipo.SelectedIndexChanged += new System.EventHandler(this.cbFiltroTipo_SelectedIndexChanged);
            // 
            // tipoBindingSource
            // 
            this.tipoBindingSource.DataMember = "Tipo";
            this.tipoBindingSource.DataSource = this.sistemaHotelWaraDataSet;
            // 
            // sistemaHotelWaraDataSet
            // 
            this.sistemaHotelWaraDataSet.DataSetName = "SistemaHotelWaraDataSet";
            this.sistemaHotelWaraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bunifuCustomLabel16
            // 
            this.bunifuCustomLabel16.AutoSize = true;
            this.bunifuCustomLabel16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuCustomLabel16.Location = new System.Drawing.Point(390, 121);
            this.bunifuCustomLabel16.Name = "bunifuCustomLabel16";
            this.bunifuCustomLabel16.Size = new System.Drawing.Size(113, 16);
            this.bunifuCustomLabel16.TabIndex = 149;
            this.bunifuCustomLabel16.Text = "TIPO HABITACION";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHabitaciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHabitaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHabitaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHabitaciones.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHabitaciones.DoubleBuffered = true;
            this.dgvHabitaciones.EnableHeadersVisualStyles = false;
            this.dgvHabitaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvHabitaciones.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgvHabitaciones.HeaderForeColor = System.Drawing.Color.Honeydew;
            this.dgvHabitaciones.Location = new System.Drawing.Point(0, 191);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHabitaciones.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitaciones.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitaciones.Size = new System.Drawing.Size(1003, 438);
            this.dgvHabitaciones.TabIndex = 148;
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtFiltroId.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtFiltroId.BackgroundImage")));
            this.txtFiltroId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtFiltroId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFiltroId.Icon = ((System.Drawing.Image)(resources.GetObject("txtFiltroId.Icon")));
            this.txtFiltroId.Location = new System.Drawing.Point(204, 113);
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Size = new System.Drawing.Size(153, 32);
            this.txtFiltroId.TabIndex = 4;
            this.txtFiltroId.text = "ID...";
            this.txtFiltroId.OnTextChange += new System.EventHandler(this.txtFiltroId_OnTextChange);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(203, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(674, 32);
            this.lblTitulo.TabIndex = 125;
            this.lblTitulo.Text = "INGRESE LOS DATOS DE LA NUEVA HABITACION";
            // 
            // tipoTableAdapter
            // 
            this.tipoTableAdapter.ClearBeforeFill = true;
            // 
            // VerHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1071, 876);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbLogoWaraForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerHabitaciones";
            this.Text = "NuevoRegistro";
            this.Load += new System.EventHandler(this.VerHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoWaraForm)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaHotelWaraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbLogoWaraForm;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTitulo;
        private System.Windows.Forms.ComboBox cbFiltroTipo;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel16;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvHabitaciones;
        private Bunifu.Framework.UI.BunifuTextbox txtFiltroId;
        private SistemaHotelWaraDataSet sistemaHotelWaraDataSet;
        private System.Windows.Forms.BindingSource tipoBindingSource;
        private SistemaHotelWaraDataSetTableAdapters.TipoTableAdapter tipoTableAdapter;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.ComboBox cbPrecioMenos;
    }
}