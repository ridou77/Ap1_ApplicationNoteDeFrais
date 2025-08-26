namespace GSB_demo.Views
{
    partial class NewLigneFraisHFForm
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
            lbl_LigneFraisHorsForfait = new Label();
            Btn_AddLigneFraisHF = new Button();
            PriceNumericUpDown = new NumericUpDown();
            PriceLbl = new Label();
            NameLigneFraisHFTxtBox = new TextBox();
            lbl_NameFraisHF = new Label();
            dtp_NewLigneFraisHF = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // lbl_LigneFraisHorsForfait
            // 
            lbl_LigneFraisHorsForfait.AutoSize = true;
            lbl_LigneFraisHorsForfait.Location = new Point(153, 36);
            lbl_LigneFraisHorsForfait.Name = "lbl_LigneFraisHorsForfait";
            lbl_LigneFraisHorsForfait.Size = new Size(177, 20);
            lbl_LigneFraisHorsForfait.TabIndex = 0;
            lbl_LigneFraisHorsForfait.Text = "Nouveau frais hors forfait";
            // 
            // Btn_AddLigneFraisHF
            // 
            Btn_AddLigneFraisHF.Location = new Point(313, 180);
            Btn_AddLigneFraisHF.Name = "Btn_AddLigneFraisHF";
            Btn_AddLigneFraisHF.Size = new Size(142, 57);
            Btn_AddLigneFraisHF.TabIndex = 1;
            Btn_AddLigneFraisHF.Text = "Ajouter un frais hors forfait";
            Btn_AddLigneFraisHF.UseVisualStyleBackColor = true;
            Btn_AddLigneFraisHF.Click += Btn_AddLigneFraisHF_Click;
            // 
            // PriceNumericUpDown
            // 
            PriceNumericUpDown.Location = new Point(336, 110);
            PriceNumericUpDown.Name = "PriceNumericUpDown";
            PriceNumericUpDown.Size = new Size(96, 27);
            PriceNumericUpDown.TabIndex = 2;
            // 
            // PriceLbl
            // 
            PriceLbl.AutoSize = true;
            PriceLbl.Location = new Point(438, 112);
            PriceLbl.Name = "PriceLbl";
            PriceLbl.Size = new Size(17, 20);
            PriceLbl.TabIndex = 3;
            PriceLbl.Text = "€";
            // 
            // NameLigneFraisHFTxtBox
            // 
            NameLigneFraisHFTxtBox.Location = new Point(205, 110);
            NameLigneFraisHFTxtBox.Name = "NameLigneFraisHFTxtBox";
            NameLigneFraisHFTxtBox.Size = new Size(125, 27);
            NameLigneFraisHFTxtBox.TabIndex = 4;
            // 
            // lbl_NameFraisHF
            // 
            lbl_NameFraisHF.AutoSize = true;
            lbl_NameFraisHF.Location = new Point(20, 112);
            lbl_NameFraisHF.Name = "lbl_NameFraisHF";
            lbl_NameFraisHF.Size = new Size(179, 20);
            lbl_NameFraisHF.TabIndex = 5;
            lbl_NameFraisHF.Text = "Nom du frais hors forfait :";
            // 
            // dtp_NewLigneFraisHF
            // 
            dtp_NewLigneFraisHF.Location = new Point(205, 75);
            dtp_NewLigneFraisHF.Name = "dtp_NewLigneFraisHF";
            dtp_NewLigneFraisHF.Size = new Size(250, 27);
            dtp_NewLigneFraisHF.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 80);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 7;
            label1.Text = "Ajouter la date du frais :";
            // 
            // NewLigneFraisHFForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 275);
            Controls.Add(label1);
            Controls.Add(dtp_NewLigneFraisHF);
            Controls.Add(lbl_NameFraisHF);
            Controls.Add(NameLigneFraisHFTxtBox);
            Controls.Add(PriceLbl);
            Controls.Add(PriceNumericUpDown);
            Controls.Add(Btn_AddLigneFraisHF);
            Controls.Add(lbl_LigneFraisHorsForfait);
            Name = "NewLigneFraisHFForm";
            Text = "NewLigneFraisHFForm";
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_LigneFraisHorsForfait;
        private Button Btn_AddLigneFraisHF;
        private NumericUpDown PriceNumericUpDown;
        private Label PriceLbl;
        private TextBox NameLigneFraisHFTxtBox;
        private Label lbl_NameFraisHF;
        private DateTimePicker dtp_NewLigneFraisHF;
        private Label label1;
    }
}