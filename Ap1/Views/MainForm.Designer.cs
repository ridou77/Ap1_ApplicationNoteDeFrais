namespace GSB_demo.Views
{
    partial class MainForm
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblConnectedUser = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            btnExit = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvFicheFrais = new DataGridView();
            btn_AddUser = new Button();
            btn_AddTypeFrais = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFicheFrais).BeginInit();
            SuspendLayout();
            // 
            // lblConnectedUser
            // 
            lblConnectedUser.AutoSize = true;
            lblConnectedUser.Location = new Point(887, 12);
            lblConnectedUser.Name = "lblConnectedUser";
            lblConnectedUser.Size = new Size(0, 20);
            lblConnectedUser.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(559, 192);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(191, 31);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Nouvelle Fiche de frais";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(756, 192);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(121, 31);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Modifier";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(756, 439);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(121, 31);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(432, 192);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(121, 31);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Actualiser";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(345, 513);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(121, 53);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Déconnexion";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(473, 513);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(121, 53);
            btnExit.TabIndex = 6;
            btnExit.Text = "Quitter";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(183, 165);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 31);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Rechercher";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(63, 169);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(114, 27);
            txtSearch.TabIndex = 8;
            // 
            // dgvFicheFrais
            // 
            dgvFicheFrais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFicheFrais.Location = new Point(63, 231);
            dgvFicheFrais.Margin = new Padding(3, 4, 3, 4);
            dgvFicheFrais.Name = "dgvFicheFrais";
            dgvFicheFrais.RowHeadersVisible = false;
            dgvFicheFrais.RowHeadersWidth = 51;
            dgvFicheFrais.Size = new Size(814, 200);
            dgvFicheFrais.TabIndex = 9;
            dgvFicheFrais.CellContentClick += dgvFicheFrais_CellContentClick;
            dgvFicheFrais.DoubleClick += dgvFicheFrais_DoubleClick;
            dgvFicheFrais.KeyDown += txtSearch_KeyDown;
            // 
            // btn_AddUser
            // 
            btn_AddUser.Location = new Point(752, 37);
            btn_AddUser.Name = "btn_AddUser";
            btn_AddUser.Size = new Size(125, 69);
            btn_AddUser.TabIndex = 10;
            btn_AddUser.Text = "Ajouter un utilisateur";
            btn_AddUser.UseVisualStyleBackColor = true;
            btn_AddUser.Click += btn_AddUser_Click;
            // 
            // btn_AddTypeFrais
            // 
            btn_AddTypeFrais.Location = new Point(623, 37);
            btn_AddTypeFrais.Name = "btn_AddTypeFrais";
            btn_AddTypeFrais.Size = new Size(123, 69);
            btn_AddTypeFrais.TabIndex = 11;
            btn_AddTypeFrais.Text = "Ajouter un nouveau type de frais";
            btn_AddTypeFrais.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btn_AddTypeFrais);
            Controls.Add(btn_AddUser);
            Controls.Add(dgvFicheFrais);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnExit);
            Controls.Add(btnLogout);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lblConnectedUser);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgvFicheFrais).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConnectedUser;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh ;
        private Button btnLogout;
        private Button btnExit;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvFicheFrais;
        private Button btn_AddUser;
        private Button btn_AddTypeFrais;
    }
}