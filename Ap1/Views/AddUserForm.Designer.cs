namespace GSB_demo.Views
{
    partial class AddUserForm
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
            comboBox_SelectUserRole = new ComboBox();
            lbl_UserRole = new Label();
            txtBox_UserName = new TextBox();
            lbl_UserName = new Label();
            lbl_IdConnect = new Label();
            lbl_EmailUser = new Label();
            lbl_FirstNameUser = new Label();
            lbl_MdpUser = new Label();
            txtBox_FirstName = new TextBox();
            txtBox_Email = new TextBox();
            txt_BoxIdConnect = new TextBox();
            txtBox_MdpUser = new TextBox();
            btn_CreateUser = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(303, 34);
            label1.Name = "label1";
            label1.Size = new Size(194, 20);
            label1.TabIndex = 0;
            label1.Text = "Ajout d'un nouvel utilisateur";
            // 
            // comboBox_SelectUserRole
            // 
            comboBox_SelectUserRole.FormattingEnabled = true;
            comboBox_SelectUserRole.Location = new Point(279, 195);
            comboBox_SelectUserRole.Name = "comboBox_SelectUserRole";
            comboBox_SelectUserRole.Size = new Size(228, 28);
            comboBox_SelectUserRole.TabIndex = 1;
            // 
            // lbl_UserRole
            // 
            lbl_UserRole.AutoSize = true;
            lbl_UserRole.Location = new Point(130, 198);
            lbl_UserRole.Name = "lbl_UserRole";
            lbl_UserRole.Size = new Size(143, 20);
            lbl_UserRole.TabIndex = 2;
            lbl_UserRole.Text = "Role de l'utilisateur :";
            // 
            // txtBox_UserName
            // 
            txtBox_UserName.Location = new Point(279, 127);
            txtBox_UserName.Name = "txtBox_UserName";
            txtBox_UserName.Size = new Size(228, 27);
            txtBox_UserName.TabIndex = 3;
            // 
            // lbl_UserName
            // 
            lbl_UserName.AutoSize = true;
            lbl_UserName.Location = new Point(224, 130);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(49, 20);
            lbl_UserName.TabIndex = 4;
            lbl_UserName.Text = "Nom :";
            // 
            // lbl_IdConnect
            // 
            lbl_IdConnect.AutoSize = true;
            lbl_IdConnect.Location = new Point(91, 266);
            lbl_IdConnect.Name = "lbl_IdConnect";
            lbl_IdConnect.Size = new Size(182, 20);
            lbl_IdConnect.TabIndex = 5;
            lbl_IdConnect.Text = "Identifiant de connection :";
            // 
            // lbl_EmailUser
            // 
            lbl_EmailUser.AutoSize = true;
            lbl_EmailUser.Location = new Point(220, 232);
            lbl_EmailUser.Name = "lbl_EmailUser";
            lbl_EmailUser.Size = new Size(53, 20);
            lbl_EmailUser.TabIndex = 6;
            lbl_EmailUser.Text = "Email :";
            lbl_EmailUser.Click += label3_Click;
            // 
            // lbl_FirstNameUser
            // 
            lbl_FirstNameUser.AutoSize = true;
            lbl_FirstNameUser.Location = new Point(206, 165);
            lbl_FirstNameUser.Name = "lbl_FirstNameUser";
            lbl_FirstNameUser.Size = new Size(67, 20);
            lbl_FirstNameUser.TabIndex = 7;
            lbl_FirstNameUser.Text = "Prénom :";
            // 
            // lbl_MdpUser
            // 
            lbl_MdpUser.AutoSize = true;
            lbl_MdpUser.Location = new Point(168, 298);
            lbl_MdpUser.Name = "lbl_MdpUser";
            lbl_MdpUser.Size = new Size(105, 20);
            lbl_MdpUser.TabIndex = 8;
            lbl_MdpUser.Text = "Mot de passe :";
            // 
            // txtBox_FirstName
            // 
            txtBox_FirstName.Location = new Point(279, 162);
            txtBox_FirstName.Name = "txtBox_FirstName";
            txtBox_FirstName.Size = new Size(228, 27);
            txtBox_FirstName.TabIndex = 9;
            // 
            // txtBox_Email
            // 
            txtBox_Email.Location = new Point(279, 229);
            txtBox_Email.Name = "txtBox_Email";
            txtBox_Email.Size = new Size(228, 27);
            txtBox_Email.TabIndex = 10;
            // 
            // txt_BoxIdConnect
            // 
            txt_BoxIdConnect.Location = new Point(279, 266);
            txt_BoxIdConnect.Name = "txt_BoxIdConnect";
            txt_BoxIdConnect.Size = new Size(228, 27);
            txt_BoxIdConnect.TabIndex = 11;
            // 
            // txtBox_MdpUser
            // 
            txtBox_MdpUser.Location = new Point(279, 299);
            txtBox_MdpUser.Name = "txtBox_MdpUser";
            txtBox_MdpUser.Size = new Size(228, 27);
            txtBox_MdpUser.TabIndex = 12;
            // 
            // btn_CreateUser
            // 
            btn_CreateUser.Location = new Point(579, 361);
            btn_CreateUser.Name = "btn_CreateUser";
            btn_CreateUser.Size = new Size(142, 59);
            btn_CreateUser.TabIndex = 13;
            btn_CreateUser.Text = "Créer l'utilisateur";
            btn_CreateUser.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 450);
            Controls.Add(btn_CreateUser);
            Controls.Add(txtBox_MdpUser);
            Controls.Add(txt_BoxIdConnect);
            Controls.Add(txtBox_Email);
            Controls.Add(txtBox_FirstName);
            Controls.Add(lbl_MdpUser);
            Controls.Add(lbl_FirstNameUser);
            Controls.Add(lbl_EmailUser);
            Controls.Add(lbl_IdConnect);
            Controls.Add(lbl_UserName);
            Controls.Add(txtBox_UserName);
            Controls.Add(lbl_UserRole);
            Controls.Add(comboBox_SelectUserRole);
            Controls.Add(label1);
            Name = "AddUserForm";
            Text = "AddUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox_SelectUserRole;
        private Label lbl_UserRole;
        private TextBox txtBox_UserName;
        private Label lbl_UserName;
        private Label lbl_IdConnect;
        private Label lbl_EmailUser;
        private Label lbl_FirstNameUser;
        private Label lbl_MdpUser;
        private TextBox txtBox_FirstName;
        private TextBox txtBox_Email;
        private TextBox txt_BoxIdConnect;
        private TextBox txtBox_MdpUser;
        private Button btn_CreateUser;
    }
}