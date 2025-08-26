namespace GSB_demo.Views
{
    partial class FraisForm
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
            LigneFraisForfaitDG = new DataGridView();
            btnAddFraisForfait = new Button();
            btn_AddFraisHF = new Button();
            ligneFraisHFDG = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            FraisForfaitStatus = new Label();
            TotalPriceFraisForfait = new Label();
            TotalPriceFraisHorsForfait = new Label();
            FraisHorsForfaitStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)LigneFraisForfaitDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ligneFraisHFDG).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(479, 29);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 0;
            label1.Text = "Fiche de frais";
            // 
            // LigneFraisForfaitDG
            // 
            LigneFraisForfaitDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LigneFraisForfaitDG.Location = new Point(59, 101);
            LigneFraisForfaitDG.Name = "LigneFraisForfaitDG";
            LigneFraisForfaitDG.RowHeadersWidth = 51;
            LigneFraisForfaitDG.Size = new Size(418, 391);
            LigneFraisForfaitDG.TabIndex = 1;
            // 
            // btnAddFraisForfait
            // 
            btnAddFraisForfait.Location = new Point(168, 581);
            btnAddFraisForfait.Name = "btnAddFraisForfait";
            btnAddFraisForfait.Size = new Size(137, 56);
            btnAddFraisForfait.TabIndex = 2;
            btnAddFraisForfait.Text = "Ajouter un frais forfait";
            btnAddFraisForfait.UseVisualStyleBackColor = true;
            btnAddFraisForfait.Click += btnAddFraisForfait_Click;
            // 
            // btn_AddFraisHF
            // 
            btn_AddFraisHF.Location = new Point(744, 571);
            btn_AddFraisHF.Name = "btn_AddFraisHF";
            btn_AddFraisHF.Size = new Size(137, 56);
            btn_AddFraisHF.TabIndex = 3;
            btn_AddFraisHF.Text = "Ajouter un frais hors forfait";
            btn_AddFraisHF.UseVisualStyleBackColor = true;
            btn_AddFraisHF.Click += btn_AddFraisHF_Click;
            // 
            // ligneFraisHFDG
            // 
            ligneFraisHFDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ligneFraisHFDG.Location = new Point(606, 101);
            ligneFraisHFDG.Name = "ligneFraisHFDG";
            ligneFraisHFDG.RowHeadersWidth = 51;
            ligneFraisHFDG.Size = new Size(396, 391);
            ligneFraisHFDG.TabIndex = 4;
            ligneFraisHFDG.CellContentClick += ligneFraisHFDG_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 68);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 5;
            label2.Text = "Liste des frais forfait";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(706, 68);
            label3.Name = "label3";
            label3.Size = new Size(175, 20);
            label3.TabIndex = 6;
            label3.Text = "Liste des frais hors forfait";
            // 
            // FraisForfaitStatus
            // 
            FraisForfaitStatus.AutoSize = true;
            FraisForfaitStatus.Location = new Point(59, 543);
            FraisForfaitStatus.Name = "FraisForfaitStatus";
            FraisForfaitStatus.Size = new Size(59, 20);
            FraisForfaitStatus.TabIndex = 7;
            FraisForfaitStatus.Text = "Statut : ";
            // 
            // TotalPriceFraisForfait
            // 
            TotalPriceFraisForfait.AutoSize = true;
            TotalPriceFraisForfait.Location = new Point(59, 510);
            TotalPriceFraisForfait.Name = "TotalPriceFraisForfait";
            TotalPriceFraisForfait.Size = new Size(75, 20);
            TotalPriceFraisForfait.TabIndex = 8;
            TotalPriceFraisForfait.Text = "Prix total :";
            // 
            // TotalPriceFraisHorsForfait
            // 
            TotalPriceFraisHorsForfait.AutoSize = true;
            TotalPriceFraisHorsForfait.Location = new Point(606, 510);
            TotalPriceFraisHorsForfait.Name = "TotalPriceFraisHorsForfait";
            TotalPriceFraisHorsForfait.Size = new Size(75, 20);
            TotalPriceFraisHorsForfait.TabIndex = 10;
            TotalPriceFraisHorsForfait.Text = "Prix total :";
            // 
            // FraisHorsForfaitStatus
            // 
            FraisHorsForfaitStatus.AutoSize = true;
            FraisHorsForfaitStatus.Location = new Point(606, 543);
            FraisHorsForfaitStatus.Name = "FraisHorsForfaitStatus";
            FraisHorsForfaitStatus.Size = new Size(59, 20);
            FraisHorsForfaitStatus.TabIndex = 9;
            FraisHorsForfaitStatus.Text = "Statut : ";
            // 
            // FraisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 679);
            Controls.Add(TotalPriceFraisHorsForfait);
            Controls.Add(FraisHorsForfaitStatus);
            Controls.Add(TotalPriceFraisForfait);
            Controls.Add(FraisForfaitStatus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ligneFraisHFDG);
            Controls.Add(btn_AddFraisHF);
            Controls.Add(btnAddFraisForfait);
            Controls.Add(LigneFraisForfaitDG);
            Controls.Add(label1);
            Name = "FraisForm";
            Text = "FraisForfaitForm";
            ((System.ComponentModel.ISupportInitialize)LigneFraisForfaitDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)ligneFraisHFDG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView LigneFraisForfaitDG;
        private Button btnAddFraisForfait;
        private Button btn_AddFraisHF;
        private DataGridView ligneFraisHFDG;
        private Label label2;
        private Label label3;
        private Label FraisForfaitStatus;
        private Label TotalPriceFraisForfait;
        private Label TotalPriceFraisHorsForfait;
        private Label FraisHorsForfaitStatus;
    }
}