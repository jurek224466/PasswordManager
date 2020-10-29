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
            this.descryptionField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataModificationField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddPassword = new System.Windows.Forms.Button();
            this.btnChangeValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleField,
            this.loginField,
            this.passwordField,
            this.descryptionField,
            this.dataModificationField});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(425, 124);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1209, 629);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // descryptionField
            // 
            this.descryptionField.Text = "Descryption";
            this.descryptionField.Width = 208;
            // 
            // dataModificationField
            // 
            this.dataModificationField.Text = "Date Modification";
            this.dataModificationField.Width = 133;
            // 
            // btnAddPassword
            // 
            this.btnAddPassword.Location = new System.Drawing.Point(47, 59);
            this.btnAddPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPassword.Name = "btnAddPassword";
            this.btnAddPassword.Size = new System.Drawing.Size(100, 28);
            this.btnAddPassword.TabIndex = 1;
            this.btnAddPassword.Text = "Add";
            this.btnAddPassword.UseVisualStyleBackColor = true;
            this.btnAddPassword.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChangeValue
            // 
            this.btnChangeValue.Location = new System.Drawing.Point(47, 112);
            this.btnChangeValue.Name = "btnChangeValue";
            this.btnChangeValue.Size = new System.Drawing.Size(100, 34);
            this.btnChangeValue.TabIndex = 2;
            this.btnChangeValue.Text = "Change";
            this.btnChangeValue.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 791);
            this.Controls.Add(this.btnChangeValue);
            this.Controls.Add(this.btnAddPassword);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Password Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader titleField;
        private System.Windows.Forms.ColumnHeader loginField;
        private System.Windows.Forms.ColumnHeader passwordField;
        private System.Windows.Forms.ColumnHeader descryptionField;
        private System.Windows.Forms.ColumnHeader dataModificationField;
        private System.Windows.Forms.Button btnAddPassword;
        private System.Windows.Forms.Button btnChangeValue;
    }
}