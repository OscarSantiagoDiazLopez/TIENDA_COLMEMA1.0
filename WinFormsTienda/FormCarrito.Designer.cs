namespace WinFormsTienda
{
    partial class FormCarrito
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvCarrito = new DataGridView();
            lblTotal = new Label();
            lblTotalImpuesto = new Label();
            txtNumeroTarjeta = new TextBox();
            txtFechaVencimiento = new TextBox();
            txtCVC = new TextBox();
            lblNTARJETA = new Label();
            lblVENCIMIENTO = new Label();
            lblCVC = new Label();
            PAGAR = new Button();
            RECIBO = new Button();
            CANCELAR = new Button();
            cbMetodoPago = new ComboBox();
            txtEfectivo = new TextBox();
            txtCambio = new TextBox();
            lblEfectivo = new Label();
            lblCambio = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(12, 12);
            dgvCarrito.Name = "dgvCarrito";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.RowTemplate.Height = 29;
            dgvCarrito.Size = new Size(576, 293);
            dgvCarrito.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Sitka Small", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.Location = new Point(31, 328);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(74, 28);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: ";
            // 
            // lblTotalImpuesto
            // 
            lblTotalImpuesto.AutoSize = true;
            lblTotalImpuesto.BackColor = Color.Transparent;
            lblTotalImpuesto.Font = new Font("Sitka Small", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalImpuesto.Location = new Point(301, 328);
            lblTotalImpuesto.Name = "lblTotalImpuesto";
            lblTotalImpuesto.Size = new Size(202, 28);
            lblTotalImpuesto.TabIndex = 2;
            lblTotalImpuesto.Text = "Total con impuesto:";
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Location = new Point(43, 463);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.PlaceholderText = "16 DIGITOS";
            txtNumeroTarjeta.Size = new Size(169, 27);
            txtNumeroTarjeta.TabIndex = 3;
            txtNumeroTarjeta.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFechaVencimiento
            // 
            txtFechaVencimiento.Location = new Point(270, 463);
            txtFechaVencimiento.Name = "txtFechaVencimiento";
            txtFechaVencimiento.PlaceholderText = "MM/YY";
            txtFechaVencimiento.Size = new Size(85, 27);
            txtFechaVencimiento.TabIndex = 4;
            txtFechaVencimiento.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCVC
            // 
            txtCVC.Location = new Point(421, 463);
            txtCVC.Name = "txtCVC";
            txtCVC.PlaceholderText = "3 DIGITOS";
            txtCVC.Size = new Size(78, 27);
            txtCVC.TabIndex = 5;
            txtCVC.TextAlign = HorizontalAlignment.Center;
            // 
            // lblNTARJETA
            // 
            lblNTARJETA.BackColor = Color.Transparent;
            lblNTARJETA.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNTARJETA.ForeColor = Color.Black;
            lblNTARJETA.Location = new Point(31, 430);
            lblNTARJETA.Name = "lblNTARJETA";
            lblNTARJETA.Size = new Size(192, 29);
            lblNTARJETA.TabIndex = 6;
            lblNTARJETA.Text = "NUMERO DE TARJETA";
            lblNTARJETA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVENCIMIENTO
            // 
            lblVENCIMIENTO.BackColor = Color.Transparent;
            lblVENCIMIENTO.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblVENCIMIENTO.Location = new Point(252, 434);
            lblVENCIMIENTO.Name = "lblVENCIMIENTO";
            lblVENCIMIENTO.Size = new Size(117, 27);
            lblVENCIMIENTO.TabIndex = 7;
            lblVENCIMIENTO.Text = "VENCIMIENTO";
            lblVENCIMIENTO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCVC
            // 
            lblCVC.BackColor = Color.Transparent;
            lblCVC.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCVC.Location = new Point(421, 434);
            lblCVC.Name = "lblCVC";
            lblCVC.Size = new Size(78, 27);
            lblCVC.TabIndex = 8;
            lblCVC.Text = "CVC";
            lblCVC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PAGAR
            // 
            PAGAR.Location = new Point(130, 528);
            PAGAR.Name = "PAGAR";
            PAGAR.Size = new Size(94, 29);
            PAGAR.TabIndex = 9;
            PAGAR.Text = "PAGAR";
            PAGAR.UseVisualStyleBackColor = true;
            PAGAR.Click += PAGAR_Click;
            // 
            // RECIBO
            // 
            RECIBO.BackColor = Color.Peru;
            RECIBO.Location = new Point(130, 528);
            RECIBO.Name = "RECIBO";
            RECIBO.Size = new Size(94, 29);
            RECIBO.TabIndex = 10;
            RECIBO.Text = "RECIBO";
            RECIBO.UseVisualStyleBackColor = false;
            RECIBO.Click += RECIBO_Click;
            // 
            // CANCELAR
            // 
            CANCELAR.BackColor = Color.Red;
            CANCELAR.FlatStyle = FlatStyle.Flat;
            CANCELAR.ForeColor = Color.White;
            CANCELAR.Location = new Point(326, 528);
            CANCELAR.Name = "CANCELAR";
            CANCELAR.Size = new Size(94, 29);
            CANCELAR.TabIndex = 12;
            CANCELAR.Text = "CANCELAR";
            CANCELAR.UseVisualStyleBackColor = false;
            CANCELAR.Click += CANCELAR_Click;
            // 
            // cbMetodoPago
            // 
            cbMetodoPago.FormattingEnabled = true;
            cbMetodoPago.Location = new Point(31, 386);
            cbMetodoPago.Name = "cbMetodoPago";
            cbMetodoPago.Size = new Size(151, 28);
            cbMetodoPago.TabIndex = 13;
            // 
            // txtEfectivo
            // 
            txtEfectivo.Location = new Point(214, 464);
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.PlaceholderText = "EFECTIVO";
            txtEfectivo.Size = new Size(141, 27);
            txtEfectivo.TabIndex = 14;
            txtEfectivo.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCambio
            // 
            txtCambio.Location = new Point(326, 463);
            txtCambio.Name = "txtCambio";
            txtCambio.Size = new Size(141, 27);
            txtCambio.TabIndex = 15;
            // 
            // lblEfectivo
            // 
            lblEfectivo.AutoSize = true;
            lblEfectivo.Location = new Point(146, 494);
            lblEfectivo.Name = "lblEfectivo";
            lblEfectivo.Size = new Size(50, 20);
            lblEfectivo.TabIndex = 16;
            lblEfectivo.Text = "label1";
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(370, 494);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(50, 20);
            lblCambio.TabIndex = 17;
            lblCambio.Text = "label1";
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._________________6_;
            ClientSize = new Size(600, 619);
            Controls.Add(lblCambio);
            Controls.Add(lblEfectivo);
            Controls.Add(txtCambio);
            Controls.Add(txtEfectivo);
            Controls.Add(cbMetodoPago);
            Controls.Add(CANCELAR);
            Controls.Add(RECIBO);
            Controls.Add(PAGAR);
            Controls.Add(lblCVC);
            Controls.Add(lblVENCIMIENTO);
            Controls.Add(lblNTARJETA);
            Controls.Add(txtCVC);
            Controls.Add(txtFechaVencimiento);
            Controls.Add(txtNumeroTarjeta);
            Controls.Add(lblTotalImpuesto);
            Controls.Add(lblTotal);
            Controls.Add(dgvCarrito);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCarrito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCarrito";
            Load += FormCarrito_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCarrito;
        private Label lblTotal;
        private Label lblTotalImpuesto;
        private TextBox txtNumeroTarjeta;
        private TextBox txtFechaVencimiento;
        private TextBox txtCVC;
        private Label lblNTARJETA;
        private Label lblVENCIMIENTO;
        private Label lblCVC;
        private Button PAGAR;
        private Button RECIBO;
        private Button CANCELAR;
        private ComboBox cbMetodoPago;
        private TextBox txtEfectivo;
        private TextBox txtCambio;
        private Label lblEfectivo;
        private Label lblCambio;
    }
}