namespace PhoneBook
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.photoButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.workPhoneTextBox = new System.Windows.Forms.TextBox();
            this.homePhoneTextBox = new System.Windows.Forms.TextBox();
            this.mobilePhoneTextBox = new System.Windows.Forms.TextBox();
            this.eMailLabel = new System.Windows.Forms.Label();
            this.workPhoneLabel = new System.Windows.Forms.Label();
            this.homePhoneLabel = new System.Windows.Forms.Label();
            this.mobPhoneLabel = new System.Windows.Forms.Label();
            this.surNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MidNameTextBox = new System.Windows.Forms.TextBox();
            this.midNameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.personsListBox = new System.Windows.Forms.ListBox();
            this.groupsComboBox = new System.Windows.Forms.ComboBox();
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.deleteButton);
            this.photoGroupBox.Controls.Add(this.addButton);
            this.photoGroupBox.Controls.Add(this.saveButton);
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Controls.Add(this.photoButton);
            this.photoGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.photoGroupBox.Location = new System.Drawing.Point(319, 12);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Size = new System.Drawing.Size(263, 522);
            this.photoGroupBox.TabIndex = 2;
            this.photoGroupBox.TabStop = false;
            this.photoGroupBox.Text = "Фото";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 481);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(251, 31);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить ";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 444);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(251, 31);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить нового";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(6, 407);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(251, 31);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить изменения";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.Location = new System.Drawing.Point(6, 26);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(251, 296);
            this.photoPictureBox.TabIndex = 1;
            this.photoPictureBox.TabStop = false;
            // 
            // photoButton
            // 
            this.photoButton.Location = new System.Drawing.Point(6, 369);
            this.photoButton.Name = "photoButton";
            this.photoButton.Size = new System.Drawing.Size(251, 32);
            this.photoButton.TabIndex = 0;
            this.photoButton.Text = "Выбрать фото";
            this.photoButton.UseVisualStyleBackColor = true;
            this.photoButton.Click += new System.EventHandler(this.photoButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addrTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.emailTextBox);
            this.groupBox2.Controls.Add(this.workPhoneTextBox);
            this.groupBox2.Controls.Add(this.homePhoneTextBox);
            this.groupBox2.Controls.Add(this.mobilePhoneTextBox);
            this.groupBox2.Controls.Add(this.eMailLabel);
            this.groupBox2.Controls.Add(this.workPhoneLabel);
            this.groupBox2.Controls.Add(this.homePhoneLabel);
            this.groupBox2.Controls.Add(this.mobPhoneLabel);
            this.groupBox2.Controls.Add(this.surNameTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.MidNameTextBox);
            this.groupBox2.Controls.Add(this.midNameLabel);
            this.groupBox2.Controls.Add(this.nameTextBox);
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(588, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 528);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация";
            // 
            // addrTextBox
            // 
            this.addrTextBox.Location = new System.Drawing.Point(10, 421);
            this.addrTextBox.Multiline = true;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.Size = new System.Drawing.Size(286, 101);
            this.addrTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Адрес:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(10, 369);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(286, 27);
            this.emailTextBox.TabIndex = 13;
            // 
            // workPhoneTextBox
            // 
            this.workPhoneTextBox.Location = new System.Drawing.Point(10, 310);
            this.workPhoneTextBox.Name = "workPhoneTextBox";
            this.workPhoneTextBox.Size = new System.Drawing.Size(286, 27);
            this.workPhoneTextBox.TabIndex = 12;
            // 
            // homePhoneTextBox
            // 
            this.homePhoneTextBox.Location = new System.Drawing.Point(10, 258);
            this.homePhoneTextBox.Name = "homePhoneTextBox";
            this.homePhoneTextBox.Size = new System.Drawing.Size(286, 27);
            this.homePhoneTextBox.TabIndex = 11;
            // 
            // mobilePhoneTextBox
            // 
            this.mobilePhoneTextBox.Location = new System.Drawing.Point(10, 206);
            this.mobilePhoneTextBox.Name = "mobilePhoneTextBox";
            this.mobilePhoneTextBox.Size = new System.Drawing.Size(286, 27);
            this.mobilePhoneTextBox.TabIndex = 10;
            // 
            // eMailLabel
            // 
            this.eMailLabel.AutoSize = true;
            this.eMailLabel.Location = new System.Drawing.Point(6, 347);
            this.eMailLabel.Name = "eMailLabel";
            this.eMailLabel.Size = new System.Drawing.Size(49, 19);
            this.eMailLabel.TabIndex = 9;
            this.eMailLabel.Text = "email:";
            // 
            // workPhoneLabel
            // 
            this.workPhoneLabel.AutoSize = true;
            this.workPhoneLabel.Location = new System.Drawing.Point(6, 288);
            this.workPhoneLabel.Name = "workPhoneLabel";
            this.workPhoneLabel.Size = new System.Drawing.Size(133, 19);
            this.workPhoneLabel.TabIndex = 8;
            this.workPhoneLabel.Text = "Рабочий телефон:";
            // 
            // homePhoneLabel
            // 
            this.homePhoneLabel.AutoSize = true;
            this.homePhoneLabel.Location = new System.Drawing.Point(6, 236);
            this.homePhoneLabel.Name = "homePhoneLabel";
            this.homePhoneLabel.Size = new System.Drawing.Size(150, 19);
            this.homePhoneLabel.TabIndex = 7;
            this.homePhoneLabel.Text = "Домашний телефон:";
            // 
            // mobPhoneLabel
            // 
            this.mobPhoneLabel.AutoSize = true;
            this.mobPhoneLabel.Location = new System.Drawing.Point(6, 182);
            this.mobPhoneLabel.Name = "mobPhoneLabel";
            this.mobPhoneLabel.Size = new System.Drawing.Size(158, 19);
            this.mobPhoneLabel.TabIndex = 6;
            this.mobPhoneLabel.Text = "Мобильный телефон:";
            // 
            // surNameTextBox
            // 
            this.surNameTextBox.Location = new System.Drawing.Point(10, 152);
            this.surNameTextBox.Name = "surNameTextBox";
            this.surNameTextBox.Size = new System.Drawing.Size(286, 27);
            this.surNameTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фамилия:";
            // 
            // MidNameTextBox
            // 
            this.MidNameTextBox.Location = new System.Drawing.Point(10, 100);
            this.MidNameTextBox.Name = "MidNameTextBox";
            this.MidNameTextBox.Size = new System.Drawing.Size(286, 27);
            this.MidNameTextBox.TabIndex = 3;
            // 
            // midNameLabel
            // 
            this.midNameLabel.AutoSize = true;
            this.midNameLabel.Location = new System.Drawing.Point(6, 78);
            this.midNameLabel.Name = "midNameLabel";
            this.midNameLabel.Size = new System.Drawing.Size(75, 19);
            this.midNameLabel.TabIndex = 2;
            this.midNameLabel.Text = "Отчество:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(10, 48);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(286, 27);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 19);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.personsListBox);
            this.groupBox1.Controls.Add(this.groupsComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 516);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы";
            // 
            // personsListBox
            // 
            this.personsListBox.FormattingEnabled = true;
            this.personsListBox.ItemHeight = 19;
            this.personsListBox.Location = new System.Drawing.Point(6, 59);
            this.personsListBox.Name = "personsListBox";
            this.personsListBox.Size = new System.Drawing.Size(289, 441);
            this.personsListBox.TabIndex = 1;
            this.personsListBox.SelectedIndexChanged += new System.EventHandler(this.personsListBox_SelectedIndexChanged);
            // 
            // groupsComboBox
            // 
            this.groupsComboBox.FormattingEnabled = true;
            this.groupsComboBox.Location = new System.Drawing.Point(6, 26);
            this.groupsComboBox.Name = "groupsComboBox";
            this.groupsComboBox.Size = new System.Drawing.Size(289, 27);
            this.groupsComboBox.TabIndex = 0;
            this.groupsComboBox.SelectedIndexChanged += new System.EventHandler(this.groupsComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.photoGroupBox);
            this.MaximumSize = new System.Drawing.Size(920, 580);
            this.Name = "MainForm";
            this.Text = "Телефонная книга";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.Button photoButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox personsListBox;
        private System.Windows.Forms.ComboBox groupsComboBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Label midNameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MidNameTextBox;
        private System.Windows.Forms.Label homePhoneLabel;
        private System.Windows.Forms.Label mobPhoneLabel;
        private System.Windows.Forms.TextBox surNameTextBox;
        private System.Windows.Forms.Label workPhoneLabel;
        private System.Windows.Forms.Label eMailLabel;
        private System.Windows.Forms.TextBox homePhoneTextBox;
        private System.Windows.Forms.TextBox mobilePhoneTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox workPhoneTextBox;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

