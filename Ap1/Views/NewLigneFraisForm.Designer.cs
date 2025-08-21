namespace GSB_demo.Views
{
    partial class NewLigneFraisForm
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
            label1 = new Label();
            listeFraisDefini = new ComboBox();
            label2 = new Label();
            choixNombreFrais = new NumericUpDown();
            btnAddLigneFrais = new Button();
            ((System.ComponentModel.ISupportInitialize)choixNombreFrais).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 19);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 0;
            label1.Text = "Ajout de frais forfait ";
            // 
            // listeFraisDefini
            // 
            listeFraisDefini.FormattingEnabled = true;
            listeFraisDefini.Location = new Point(157, 104);
            listeFraisDefini.Name = "listeFraisDefini";
            listeFraisDefini.Size = new Size(151, 28);
            listeFraisDefini.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 108);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Ajouter un frais :";
            // 
            // choixNombreFrais
            // 
            choixNombreFrais.Location = new Point(335, 106);
            choixNombreFrais.Name = "choixNombreFrais";
            choixNombreFrais.Size = new Size(91, 27);
            choixNombreFrais.TabIndex = 4;
            choixNombreFrais.ValueChanged += choixNombreFrais_ValueChanged;
            // 
            // btnAddLigneFrais
            // 
            btnAddLigneFrais.Location = new Point(335, 297);
            btnAddLigneFrais.Name = "btnAddLigneFrais";
            btnAddLigneFrais.Size = new Size(133, 49);
            btnAddLigneFrais.TabIndex = 5;
            btnAddLigneFrais.Text = "Ajouter à la fiche";
            btnAddLigneFrais.UseVisualStyleBackColor = true;
            btnAddLigneFrais.Click += btnAddLigneFrais_Click;
            // 
            // NewLigneFraisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 387);
            Controls.Add(btnAddLigneFrais);
            Controls.Add(choixNombreFrais);
            Controls.Add(label2);
            Controls.Add(listeFraisDefini);
            Controls.Add(label1);
            Name = "NewLigneFraisForm";
            Text = "NewFicheFrais";
            ((System.ComponentModel.ISupportInitialize)choixNombreFrais).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox listeFraisDefini;
        private Label label2;
        private NumericUpDown choixNombreFrais;
        private Button btnAddLigneFrais;
    }
}