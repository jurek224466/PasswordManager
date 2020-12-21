
namespace PasswordManager
{
    partial class MainWindow
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
            this.label8 = new System.Windows.Forms.Label();
            this.textWebAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.radioButtonHMAC = new System.Windows.Forms.RadioButton();
            this.radioButtonSHA512 = new System.Windows.Forms.RadioButton();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textlogin = new System.Windows.Forms.TextBox();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.ButtonInsert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewPasswordRepeat = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.titleField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.passwordField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.webAddressField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descryptionField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(1017, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Web Address";
            // 
            // textWebAddress
            // 
            this.textWebAddress.Location = new System.Drawing.Point(1021, 371);
            this.textWebAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textWebAddress.Multiline = true;
            this.textWebAddress.Name = "textWebAddress";
            this.textWebAddress.Size = new System.Drawing.Size(177, 41);
            this.textWebAddress.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(761, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Descryption";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(618, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "Password";
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(765, 371);
            this.textDesc.Margin = new System.Windows.Forms.Padding(2);
            this.textDesc.Multiline = true;
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(242, 58);
            this.textDesc.TabIndex = 63;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(621, 371);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(130, 20);
            this.textPassword.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Old password";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(29, 60);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(179, 20);
            this.textBoxOldPassword.TabIndex = 60;
            // 
            // radioButtonHMAC
            // 
            this.radioButtonHMAC.AutoSize = true;
            this.radioButtonHMAC.Checked = true;
            this.radioButtonHMAC.Location = new System.Drawing.Point(225, 115);
            this.radioButtonHMAC.Name = "radioButtonHMAC";
            this.radioButtonHMAC.Size = new System.Drawing.Size(56, 17);
            this.radioButtonHMAC.TabIndex = 59;
            this.radioButtonHMAC.TabStop = true;
            this.radioButtonHMAC.Text = "HMAC";
            this.radioButtonHMAC.UseVisualStyleBackColor = true;
            // 
            // radioButtonSHA512
            // 
            this.radioButtonSHA512.AutoSize = true;
            this.radioButtonSHA512.Location = new System.Drawing.Point(225, 60);
            this.radioButtonSHA512.Name = "radioButtonSHA512";
            this.radioButtonSHA512.Size = new System.Drawing.Size(65, 17);
            this.radioButtonSHA512.TabIndex = 58;
            this.radioButtonSHA512.Text = "SHA512";
            this.radioButtonSHA512.UseVisualStyleBackColor = true;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(29, 201);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(151, 23);
            this.buttonChangePassword.TabIndex = 57;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Location = new System.Drawing.Point(621, 404);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(118, 36);
            this.btnShowPassword.TabIndex = 56;
            this.btnShowPassword.Text = "Show Passwords";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(478, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 55;
            this.label5.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(327, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Title";
            // 
            // textlogin
            // 
            this.textlogin.Location = new System.Drawing.Point(470, 371);
            this.textlogin.Name = "textlogin";
            this.textlogin.Size = new System.Drawing.Size(137, 20);
            this.textlogin.TabIndex = 53;
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(331, 371);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(100, 20);
            this.textTitle.TabIndex = 52;
            // 
            // ButtonInsert
            // 
            this.ButtonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonInsert.Location = new System.Drawing.Point(765, 457);
            this.ButtonInsert.Name = "ButtonInsert";
            this.ButtonInsert.Size = new System.Drawing.Size(95, 29);
            this.ButtonInsert.TabIndex = 51;
            this.ButtonInsert.Text = "Insert";
            this.ButtonInsert.UseVisualStyleBackColor = true;
            this.ButtonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Repeat Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "New Password";
            // 
            // textBoxNewPasswordRepeat
            // 
            this.textBoxNewPasswordRepeat.Location = new System.Drawing.Point(29, 175);
            this.textBoxNewPasswordRepeat.Name = "textBoxNewPasswordRepeat";
            this.textBoxNewPasswordRepeat.Size = new System.Drawing.Size(179, 20);
            this.textBoxNewPasswordRepeat.TabIndex = 48;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(29, 114);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(179, 20);
            this.textBoxNewPassword.TabIndex = 47;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleField,
            this.loginField,
            this.passwordField,
            this.webAddressField,
            this.descryptionField});
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(314, 53);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(859, 244);
            this.listView1.TabIndex = 46;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseWaitCursor = true;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // titleField
            // 
            this.titleField.Text = "Title";
            this.titleField.Width = 308;
            // 
            // loginField
            // 
            this.loginField.Text = "Login";
            this.loginField.Width = 155;
            // 
            // passwordField
            // 
            this.passwordField.Text = "Password";
            this.passwordField.Width = 78;
            // 
            // webAddressField
            // 
            this.webAddressField.Text = "Web Address";
            this.webAddressField.Width = 187;
            // 
            // descryptionField
            // 
            this.descryptionField.Text = "Descryption";
            this.descryptionField.Width = 208;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(29, 240);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(35, 13);
            this.errorLabel.TabIndex = 68;
            this.errorLabel.Text = "label9";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 668);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textWebAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOldPassword);
            this.Controls.Add(this.radioButtonHMAC);
            this.Controls.Add(this.radioButtonSHA512);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textlogin);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.ButtonInsert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewPasswordRepeat);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.listView1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textWebAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.RadioButton radioButtonHMAC;
        private System.Windows.Forms.RadioButton radioButtonSHA512;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textlogin;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Button ButtonInsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewPasswordRepeat;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader titleField;
        private System.Windows.Forms.ColumnHeader loginField;
        private System.Windows.Forms.ColumnHeader passwordField;
        private System.Windows.Forms.ColumnHeader webAddressField;
        private System.Windows.Forms.ColumnHeader descryptionField;
        private System.Windows.Forms.Label errorLabel;
    }
}