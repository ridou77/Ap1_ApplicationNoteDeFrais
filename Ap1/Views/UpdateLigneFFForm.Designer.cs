namespace GSB_demo.Views
{
    partial class UpdateLigneFFForm
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
            comboBox_MajFF = new ComboBox();
            lbl_MajFF = new Label();
            numericUpDown_MajFF = new NumericUpDown();
            btn_MajFF = new Button();
            label1 = new Label();
            comboBox_StatusModif = new ComboBox();
            lbl_ModifStatut = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_MajFF).BeginInit();
            SuspendLayout();
            // 
            // comboBox_MajFF
            // 
            comboBox_MajFF.FormattingEnabled = true;
            comboBox_MajFF.Location = new Point(148, 163);
            comboBox_MajFF.Name = "comboBox_MajFF";
            comboBox_MajFF.Size = new Size(151, 28);
            comboBox_MajFF.TabIndex = 1;
            // 
            // lbl_MajFF
            // 
            lbl_MajFF.AutoSize = true;
            lbl_MajFF.Location = new Point(21, 166);
            lbl_MajFF.Name = "lbl_MajFF";
            lbl_MajFF.Size = new Size(121, 20);
            lbl_MajFF.TabIndex = 2;
            lbl_MajFF.Text = "Modifier le frais :";
            // 
            // numericUpDown_MajFF
            // 
            numericUpDown_MajFF.Location = new Point(315, 164);
            numericUpDown_MajFF.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown_MajFF.Name = "numericUpDown_MajFF";
            numericUpDown_MajFF.Size = new Size(150, 27);
            numericUpDown_MajFF.TabIndex = 3;
            // 
            // btn_MajFF
            // 
            btn_MajFF.Location = new Point(327, 234);
            btn_MajFF.Name = "btn_MajFF";
            btn_MajFF.Size = new Size(125, 50);
            btn_MajFF.TabIndex = 4;
            btn_MajFF.Text = "Mettre à jour la ligne de frais forfait";
            btn_MajFF.UseVisualStyleBackColor = true;
            btn_MajFF.Click += btn_MajFF_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 33);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 5;
            label1.Text = "Mise à jour d'un frais forfait";
            // 
            // comboBox_StatusModif
            // 
            comboBox_StatusModif.FormattingEnabled = true;
            comboBox_StatusModif.Location = new Point(148, 197);
            comboBox_StatusModif.Name = "comboBox_StatusModif";
            comboBox_StatusModif.Size = new Size(151, 28);
            comboBox_StatusModif.TabIndex = 6;
            // 
            // lbl_ModifStatut
            // 
            lbl_ModifStatut.AutoSize = true;
            lbl_ModifStatut.Location = new Point(12, 200);
            lbl_ModifStatut.Name = "lbl_ModifStatut";
            lbl_ModifStatut.Size = new Size(130, 20);
            lbl_ModifStatut.TabIndex = 7;
            lbl_ModifStatut.Text = "Modifier le statut :";
            // 
            // UpdateLigneFFForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 328);
            Controls.Add(lbl_ModifStatut);
            Controls.Add(comboBox_StatusModif);
            Controls.Add(label1);
            Controls.Add(btn_MajFF);
            Controls.Add(numericUpDown_MajFF);
            Controls.Add(lbl_MajFF);
            Controls.Add(comboBox_MajFF);
            Name = "UpdateLigneFFForm";
            Text = "UpdateLigneFFForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_MajFF).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_MajFF;
        private Label lbl_MajFF;
        private NumericUpDown numericUpDown_MajFF;
        private Button btn_MajFF;
        private Label label1;
        private ComboBox comboBox_StatusModif;
        private Label lbl_ModifStatut;
    }
}