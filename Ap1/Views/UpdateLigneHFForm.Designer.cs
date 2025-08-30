namespace GSB_demo.Views
{
    partial class UpdateLigneHFForm
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
            textBox_MajHF = new TextBox();
            lbl_MajHF = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            btn_MajHF = new Button();
            lbl_StatutHF = new Label();
            comboBox_StatutHF = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBox_MajHF
            // 
            textBox_MajHF.Location = new Point(237, 165);
            textBox_MajHF.Name = "textBox_MajHF";
            textBox_MajHF.Size = new Size(125, 27);
            textBox_MajHF.TabIndex = 0;
            // 
            // lbl_MajHF
            // 
            lbl_MajHF.AutoSize = true;
            lbl_MajHF.Location = new Point(33, 168);
            lbl_MajHF.Name = "lbl_MajHF";
            lbl_MajHF.Size = new Size(198, 20);
            lbl_MajHF.TabIndex = 1;
            lbl_MajHF.Text = "Modifier le frais hors forfait :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 45);
            label2.Name = "label2";
            label2.Size = new Size(289, 20);
            label2.TabIndex = 2;
            label2.Text = "Mise à jour d'une ligne de frais hors forfait";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(368, 165);
            numericUpDown1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 3;
            // 
            // btn_MajHF
            // 
            btn_MajHF.Location = new Point(375, 255);
            btn_MajHF.Name = "btn_MajHF";
            btn_MajHF.Size = new Size(143, 65);
            btn_MajHF.TabIndex = 4;
            btn_MajHF.Text = "Mettre à jour le frais hors forfait";
            btn_MajHF.UseVisualStyleBackColor = true;
            btn_MajHF.Click += btn_MajHF_Click;
            // 
            // lbl_StatutHF
            // 
            lbl_StatutHF.AutoSize = true;
            lbl_StatutHF.Location = new Point(68, 198);
            lbl_StatutHF.Name = "lbl_StatutHF";
            lbl_StatutHF.Size = new Size(163, 20);
            lbl_StatutHF.TabIndex = 5;
            lbl_StatutHF.Text = "Modification du statut :";
            // 
            // comboBox_StatutHF
            // 
            comboBox_StatutHF.FormattingEnabled = true;
            comboBox_StatutHF.Location = new Point(237, 198);
            comboBox_StatutHF.Name = "comboBox_StatutHF";
            comboBox_StatutHF.Size = new Size(151, 28);
            comboBox_StatutHF.TabIndex = 6;
            // 
            // UpdateLigneHFForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 332);
            Controls.Add(comboBox_StatutHF);
            Controls.Add(lbl_StatutHF);
            Controls.Add(btn_MajHF);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(lbl_MajHF);
            Controls.Add(textBox_MajHF);
            Name = "UpdateLigneHFForm";
            Text = "UpdateLigneHFForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_MajHF;
        private Label lbl_MajHF;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button btn_MajHF;
        private Label lbl_StatutHF;
        private ComboBox comboBox_StatutHF;
    }
}