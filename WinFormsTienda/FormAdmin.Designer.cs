namespace WinFormsTienda
{
    partial class FormAdmin
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
            buttonLOGOUT = new Button();
            textBoxNombre = new TextBox();
            textBoxID = new TextBox();
            textBoxIMAGEN = new TextBox();
            textBoxNOMPRO = new TextBox();
            textBoxDESCRIPCION = new TextBox();
            textBoxPRECIO = new TextBox();
            textBoxEXISTENCIAS = new TextBox();
            buttonINSERTAR = new Button();
            buttonREFRESCAR = new Button();
            LIMPIAR = new Button();
            buttonELIMINAR = new Button();
            buttonVENTAS = new Button();
            dataGridView1 = new DataGridView();
            textBoxVENTAS = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonLOGOUT
            // 
            buttonLOGOUT.BackColor = Color.Red;
            buttonLOGOUT.FlatStyle = FlatStyle.Flat;
            buttonLOGOUT.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLOGOUT.ForeColor = Color.Black;
            buttonLOGOUT.Location = new Point(49, 965);
            buttonLOGOUT.Name = "buttonLOGOUT";
            buttonLOGOUT.Size = new Size(265, 63);
            buttonLOGOUT.TabIndex = 13;
            buttonLOGOUT.Text = "LOGOUT";
            buttonLOGOUT.UseVisualStyleBackColor = false;
            buttonLOGOUT.Click += buttonLOGOUT_Click;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Rockwell", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNombre.Location = new Point(475, 49);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.ReadOnly = true;
            textBoxNombre.Size = new Size(404, 31);
            textBoxNombre.TabIndex = 24;
            // 
            // textBoxID
            // 
            textBoxID.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxID.Location = new Point(409, 344);
            textBoxID.Name = "textBoxID";
            textBoxID.PlaceholderText = "ID";
            textBoxID.Size = new Size(279, 43);
            textBoxID.TabIndex = 26;
            textBoxID.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxIMAGEN
            // 
            textBoxIMAGEN.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxIMAGEN.Location = new Point(409, 463);
            textBoxIMAGEN.Name = "textBoxIMAGEN";
            textBoxIMAGEN.PlaceholderText = "Imagen";
            textBoxIMAGEN.Size = new Size(279, 43);
            textBoxIMAGEN.TabIndex = 27;
            textBoxIMAGEN.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNOMPRO
            // 
            textBoxNOMPRO.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNOMPRO.Location = new Point(409, 404);
            textBoxNOMPRO.Name = "textBoxNOMPRO";
            textBoxNOMPRO.PlaceholderText = "Nombre Producto";
            textBoxNOMPRO.Size = new Size(279, 43);
            textBoxNOMPRO.TabIndex = 28;
            textBoxNOMPRO.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxDESCRIPCION
            // 
            textBoxDESCRIPCION.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDESCRIPCION.Location = new Point(409, 524);
            textBoxDESCRIPCION.Name = "textBoxDESCRIPCION";
            textBoxDESCRIPCION.PlaceholderText = "Descripcion";
            textBoxDESCRIPCION.Size = new Size(279, 43);
            textBoxDESCRIPCION.TabIndex = 29;
            textBoxDESCRIPCION.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxPRECIO
            // 
            textBoxPRECIO.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPRECIO.Location = new Point(409, 587);
            textBoxPRECIO.Name = "textBoxPRECIO";
            textBoxPRECIO.PlaceholderText = "Precio";
            textBoxPRECIO.Size = new Size(279, 43);
            textBoxPRECIO.TabIndex = 30;
            textBoxPRECIO.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxEXISTENCIAS
            // 
            textBoxEXISTENCIAS.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEXISTENCIAS.Location = new Point(409, 645);
            textBoxEXISTENCIAS.Name = "textBoxEXISTENCIAS";
            textBoxEXISTENCIAS.PlaceholderText = "Existencias";
            textBoxEXISTENCIAS.Size = new Size(279, 43);
            textBoxEXISTENCIAS.TabIndex = 31;
            textBoxEXISTENCIAS.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonINSERTAR
            // 
            buttonINSERTAR.BackColor = Color.Blue;
            buttonINSERTAR.FlatStyle = FlatStyle.Popup;
            buttonINSERTAR.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            buttonINSERTAR.ForeColor = Color.Transparent;
            buttonINSERTAR.Location = new Point(49, 404);
            buttonINSERTAR.Name = "buttonINSERTAR";
            buttonINSERTAR.Size = new Size(265, 63);
            buttonINSERTAR.TabIndex = 32;
            buttonINSERTAR.Text = "INSERTAR";
            buttonINSERTAR.UseVisualStyleBackColor = false;
            buttonINSERTAR.Click += buttonINSERTAR_Click;
            // 
            // buttonREFRESCAR
            // 
            buttonREFRESCAR.BackColor = Color.SeaGreen;
            buttonREFRESCAR.FlatStyle = FlatStyle.Popup;
            buttonREFRESCAR.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            buttonREFRESCAR.ForeColor = Color.Transparent;
            buttonREFRESCAR.Location = new Point(49, 892);
            buttonREFRESCAR.Name = "buttonREFRESCAR";
            buttonREFRESCAR.Size = new Size(265, 63);
            buttonREFRESCAR.TabIndex = 33;
            buttonREFRESCAR.Text = "ACTUALIZAR";
            buttonREFRESCAR.UseVisualStyleBackColor = false;
            buttonREFRESCAR.Click += buttonREFRESCAR_Click;
            // 
            // LIMPIAR
            // 
            LIMPIAR.BackColor = Color.FromArgb(64, 64, 64);
            LIMPIAR.FlatStyle = FlatStyle.Popup;
            LIMPIAR.Font = new Font("Rockwell", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LIMPIAR.ForeColor = SystemColors.ButtonHighlight;
            LIMPIAR.Location = new Point(485, 775);
            LIMPIAR.Name = "LIMPIAR";
            LIMPIAR.Size = new Size(135, 52);
            LIMPIAR.TabIndex = 34;
            LIMPIAR.Text = "LIMPIAR";
            LIMPIAR.UseVisualStyleBackColor = false;
            LIMPIAR.Click += button1_Click;
            // 
            // buttonELIMINAR
            // 
            buttonELIMINAR.BackColor = Color.Green;
            buttonELIMINAR.FlatStyle = FlatStyle.Popup;
            buttonELIMINAR.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            buttonELIMINAR.ForeColor = Color.Transparent;
            buttonELIMINAR.Location = new Point(49, 477);
            buttonELIMINAR.Name = "buttonELIMINAR";
            buttonELIMINAR.Size = new Size(265, 63);
            buttonELIMINAR.TabIndex = 35;
            buttonELIMINAR.Text = "ELIMINAR";
            buttonELIMINAR.UseVisualStyleBackColor = false;
            buttonELIMINAR.Click += buttonELIMINAR_Click;
            // 
            // buttonVENTAS
            // 
            buttonVENTAS.BackColor = Color.Crimson;
            buttonVENTAS.FlatStyle = FlatStyle.Popup;
            buttonVENTAS.Font = new Font("Rockwell", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            buttonVENTAS.ForeColor = Color.Transparent;
            buttonVENTAS.Location = new Point(49, 625);
            buttonVENTAS.Name = "buttonVENTAS";
            buttonVENTAS.Size = new Size(265, 63);
            buttonVENTAS.TabIndex = 37;
            buttonVENTAS.Text = "VENTAS";
            buttonVENTAS.UseVisualStyleBackColor = false;
            buttonVENTAS.Click += buttonVENTAS_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(731, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1120, 433);
            dataGridView1.TabIndex = 38;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxVENTAS
            // 
            textBoxVENTAS.Font = new Font("Rockwell", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxVENTAS.Location = new Point(409, 708);
            textBoxVENTAS.Name = "textBoxVENTAS";
            textBoxVENTAS.PlaceholderText = "Ventas";
            textBoxVENTAS.Size = new Size(279, 43);
            textBoxVENTAS.TabIndex = 39;
            textBoxVENTAS.TextAlign = HorizontalAlignment.Center;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._________________3_;
            ClientSize = new Size(1386, 788);
            Controls.Add(textBoxVENTAS);
            Controls.Add(dataGridView1);
            Controls.Add(buttonVENTAS);
            Controls.Add(buttonELIMINAR);
            Controls.Add(LIMPIAR);
            Controls.Add(buttonREFRESCAR);
            Controls.Add(buttonINSERTAR);
            Controls.Add(textBoxEXISTENCIAS);
            Controls.Add(textBoxPRECIO);
            Controls.Add(textBoxDESCRIPCION);
            Controls.Add(textBoxNOMPRO);
            Controls.Add(textBoxIMAGEN);
            Controls.Add(textBoxID);
            Controls.Add(textBoxNombre);
            Controls.Add(buttonLOGOUT);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAdmin";
            Text = "FormAdmin";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLOGOUT;
        private TextBox textBoxNombre;
        private TextBox textBoxID;
        private TextBox textBoxIMAGEN;
        private TextBox textBoxNOMPRO;
        private TextBox textBoxDESCRIPCION;
        private TextBox textBoxPRECIO;
        private TextBox textBoxEXISTENCIAS;
        private Button buttonINSERTAR;
        private Button buttonREFRESCAR;
        private Button LIMPIAR;
        private Button buttonELIMINAR;
        private Button buttonVENTAS;
        private DataGridView dataGridView1;
        private TextBox textBoxVENTAS;
    }
}