namespace PasswordManager
{
    partial class Form2
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.titleField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loginField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.passwordField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.webAddressField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descryptionField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textWebAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(428, 49);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1144, 299);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
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
            this.webAddressField.DisplayIndex = 4;
            this.webAddressField.Width = 187;
            // 
            // descryptionField
            // 
            this.descryptionField.DisplayIndex = 3;
            this.descryptionField.Text = "Descryption";
            this.descryptionField.Width = 208;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Old password";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(48, 58);
            this.textBoxOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(237, 22);
            this.textBoxOldPassword.TabIndex = 36;
            // 
            // radioButtonHMAC
            // 
            this.radioButtonHMAC.AutoSize = true;
            this.radioButtonHMAC.Location = new System.Drawing.Point(309, 125);
            this.radioButtonHMAC.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonHMAC.Name = "radioButtonHMAC";
            this.radioButtonHMAC.Size = new System.Drawing.Size(68, 21);
            this.radioButtonHMAC.TabIndex = 35;
            this.radioButtonHMAC.Text = "HMAC";
            this.radioButtonHMAC.UseVisualStyleBackColor = true;
            // 
            // radioButtonSHA512
            // 
            this.radioButtonSHA512.AutoSize = true;
            this.radioButtonSHA512.Checked = true;
            this.radioButtonSHA512.Location = new System.Drawing.Point(309, 58);
            this.radioButtonSHA512.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonSHA512.Name = "radioButtonSHA512";
            this.radioButtonSHA512.Size = new System.Drawing.Size(81, 21);
            this.radioButtonSHA512.TabIndex = 34;
            this.radioButtonSHA512.TabStop = true;
            this.radioButtonSHA512.Text = "SHA512";
            this.radioButtonSHA512.UseVisualStyleBackColor = true;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(58, 239);
            this.buttonChangePassword.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(201, 28);
            this.buttonChangePassword.TabIndex = 33;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Location = new System.Drawing.Point(838, 481);
            this.btnShowPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(158, 44);
            this.btnShowPassword.TabIndex = 32;
            this.btnShowPassword.Text = "Show Passwords";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(647, 392);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(445, 392);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 29;
            this.label4.Text = "Title";
            // 
            // textlogin
            // 
            this.textlogin.Location = new System.Drawing.Point(636, 440);
            this.textlogin.Margin = new System.Windows.Forms.Padding(4);
            this.textlogin.Name = "textlogin";
            this.textlogin.Size = new System.Drawing.Size(181, 22);
            this.textlogin.TabIndex = 28;
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(450, 440);
            this.textTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(132, 22);
            this.textTitle.TabIndex = 27;
            // 
            // ButtonInsert
            // 
            this.ButtonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonInsert.Location = new System.Drawing.Point(1029, 546);
            this.ButtonInsert.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonInsert.Name = "ButtonInsert";
            this.ButtonInsert.Size = new System.Drawing.Size(127, 36);
            this.ButtonInsert.TabIndex = 26;
            this.ButtonInsert.Text = "Insert";
            this.ButtonInsert.UseVisualStyleBackColor = true;
            this.ButtonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Repeat Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "New Password";
            // 
            // textBoxNewPasswordRepeat
            // 
            this.textBoxNewPasswordRepeat.Location = new System.Drawing.Point(48, 200);
            this.textBoxNewPasswordRepeat.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewPasswordRepeat.Name = "textBoxNewPasswordRepeat";
            this.textBoxNewPasswordRepeat.Size = new System.Drawing.Size(237, 22);
            this.textBoxNewPasswordRepeat.TabIndex = 23;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(48, 124);
            this.textBoxNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(237, 22);
            this.textBoxNewPassword.TabIndex = 22;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(838, 440);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(172, 22);
            this.textPassword.TabIndex = 38;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(1029, 440);
            this.textDesc.Multiline = true;
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(321, 70);
            this.textDesc.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(833, 392);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(1024, 392);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "Descryption";
            // 
            // textWebAddress
            // 
            this.textWebAddress.Location = new System.Drawing.Point(1371, 440);
            this.textWebAddress.Multiline = true;
            this.textWebAddress.Name = "textWebAddress";
            this.textWebAddress.Size = new System.Drawing.Size(235, 50);
            this.textWebAddress.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(1366, 392);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "Web Address";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 791);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader titleField;
        private System.Windows.Forms.ColumnHeader loginField;
        private System.Windows.Forms.ColumnHeader passwordField;
        private System.Windows.Forms.ColumnHeader descryptionField;
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
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader webAddressField;
        private System.Windows.Forms.TextBox textWebAddress;
        private System.Windows.Forms.Label label8;
    }
}