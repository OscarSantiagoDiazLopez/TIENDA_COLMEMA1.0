namespace WinFormsTienda
{
    partial class OpcionPago
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
            buttonOXXO = new Button();
            buttonTARJETA = new Button();
            buttonEFECTIVO = new Button();
            SuspendLayout();
            // 
            // buttonOXXO
            // 
            buttonOXXO.BackColor = Color.FromArgb(255, 128, 0);
            buttonOXXO.Font = new Font("Sitka Heading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOXXO.Location = new Point(154, 860);
            buttonOXXO.Name = "buttonOXXO";
            buttonOXXO.Size = new Size(351, 66);
            buttonOXXO.TabIndex = 0;
            buttonOXXO.Text = "PAGAR";
            buttonOXXO.UseVisualStyleBackColor = false;
            buttonOXXO.Click += buttonOXXO_Click;
            // 
            // buttonTARJETA
            // 
            buttonTARJETA.BackColor = Color.FromArgb(255, 128, 0);
            buttonTARJETA.Font = new Font("Sitka Heading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTARJETA.Location = new Point(800, 860);
            buttonTARJETA.Name = "buttonTARJETA";
            buttonTARJETA.Size = new Size(351, 66);
            buttonTARJETA.TabIndex = 1;
            buttonTARJETA.Text = "PAGAR";
            buttonTARJETA.UseVisualStyleBackColor = false;
            buttonTARJETA.Click += buttonTARJETA_Click;
            // 
            // buttonEFECTIVO
            // 
            buttonEFECTIVO.BackColor = Color.FromArgb(255, 128, 0);
            buttonEFECTIVO.Font = new Font("Sitka Heading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEFECTIVO.Location = new Point(1396, 860);
            buttonEFECTIVO.Name = "buttonEFECTIVO";
            buttonEFECTIVO.Size = new Size(351, 66);
            buttonEFECTIVO.TabIndex = 2;
            buttonEFECTIVO.Text = "PAGAR";
            buttonEFECTIVO.UseVisualStyleBackColor = false;
            // 
            // OpcionPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._______________;
            ClientSize = new Size(1370, 749);
            Controls.Add(buttonEFECTIVO);
            Controls.Add(buttonTARJETA);
            Controls.Add(buttonOXXO);
            Name = "OpcionPago";
            Text = "OpcionPago";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOXXO;
        private Button buttonTARJETA;
        private Button buttonEFECTIVO;
    }
}