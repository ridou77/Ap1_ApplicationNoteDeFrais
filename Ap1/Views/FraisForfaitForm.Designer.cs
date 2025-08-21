namespace GSB_demo.Views
{
    partial class FraisForfaitForm
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
            button1 = new Button();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            FraisForfaitStatus = new Label();
            TotalPriceFraisForfait = new Label();
            TotalPriceFraisHorsForfait = new Label();
            FraisHorsForfaitStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)LigneFraisForfaitDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            label1.Click += label1_Click;
            // 
            // LigneFraisForfaitDG
            // 
            LigneFraisForfaitDG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LigneFraisForfaitDG.Location = new Point(59, 101);
            LigneFraisForfaitDG.Name = "LigneFraisForfaitDG";
            LigneFraisForfaitDG.RowHeadersWidth = 51;
            LigneFraisForfaitDG.Size = new Size(418, 391);
            LigneFraisForfaitDG.TabIndex = 1;
            LigneFraisForfaitDG.CellContentClick += LigneFraisForfaitDG_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(168, 581);
            button1.Name = "button1";
            button1.Size = new Size(137, 56);
            button1.TabIndex = 2;
            button1.Text = "Ajouter un frais forfait";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(744, 571);
            button2.Name = "button2";
            button2.Size = new Size(137, 56);
            button2.TabIndex = 3;
            button2.Text = "Ajouter un frais hors forfait";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(606, 101);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(396, 391);
            dataGridView2.TabIndex = 4;
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
            // FraisForfaitForm
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
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(LigneFraisForfaitDG);
            Controls.Add(label1);
            Name = "FraisForfaitForm";
            Text = "FraisForfaitForm";
            ((System.ComponentModel.ISupportInitialize)LigneFraisForfaitDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView LigneFraisForfaitDG;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView2;
        private Label label2;
        private Label label3;
        private Label FraisForfaitStatus;
        private Label TotalPriceFraisForfait;
        private Label TotalPriceFraisHorsForfait;
        private Label FraisHorsForfaitStatus;
    }
}