﻿namespace HranitelPro
{
    partial class PersonalVisit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalVisit));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clearForm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.goalList = new System.Windows.Forms.ComboBox();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.subdivisionList = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.surnameField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.patronymicField = new System.Windows.Forms.TextBox();
            this.emailField = new System.Windows.Forms.TextBox();
            this.organizationField = new System.Windows.Forms.TextBox();
            this.purposeField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.birthDateField = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadImgBtn = new System.Windows.Forms.Button();
            this.phoneField = new System.Windows.Forms.MaskedTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numberField = new System.Windows.Forms.MaskedTextBox();
            this.serialField = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "по";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цель посещения:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Подразделение:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ФИО*:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Срок действия заявки:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // clearForm
            // 
            this.clearForm.AutoSize = true;
            this.clearForm.Location = new System.Drawing.Point(409, 436);
            this.clearForm.Name = "clearForm";
            this.clearForm.Size = new System.Drawing.Size(90, 13);
            this.clearForm.TabIndex = 14;
            this.clearForm.Text = "Очистить форму";
            this.clearForm.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "с*:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.goalList);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 178);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // goalList
            // 
            this.goalList.FormattingEnabled = true;
            this.goalList.Location = new System.Drawing.Point(35, 137);
            this.goalList.Name = "goalList";
            this.goalList.Size = new System.Drawing.Size(254, 21);
            this.goalList.TabIndex = 10;
            this.goalList.SelectedIndexChanged += new System.EventHandler(this.goalList_SelectedIndexChanged);
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(187, 70);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(120, 20);
            this.dateTo.TabIndex = 1;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "";
            this.dateFrom.Location = new System.Drawing.Point(35, 70);
            this.dateFrom.MinDate = new System.DateTime(2023, 3, 19, 0, 0, 0, 0);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(116, 20);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.subdivisionList);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(350, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 178);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // subdivisionList
            // 
            this.subdivisionList.FormattingEnabled = true;
            this.subdivisionList.Location = new System.Drawing.Point(20, 44);
            this.subdivisionList.Name = "subdivisionList";
            this.subdivisionList.Size = new System.Drawing.Size(308, 21);
            this.subdivisionList.TabIndex = 9;
            this.subdivisionList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(521, 431);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(170, 23);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Оформить заявку";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // surnameField
            // 
            this.surnameField.Location = new System.Drawing.Point(88, 25);
            this.surnameField.Name = "surnameField";
            this.surnameField.Size = new System.Drawing.Size(132, 20);
            this.surnameField.TabIndex = 4;
            this.surnameField.TextChanged += new System.EventHandler(this.surnameField_TextChanged);
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(88, 51);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(132, 20);
            this.nameField.TabIndex = 5;
            this.nameField.TextChanged += new System.EventHandler(this.nameField_TextChanged);
            // 
            // patronymicField
            // 
            this.patronymicField.Location = new System.Drawing.Point(88, 77);
            this.patronymicField.Name = "patronymicField";
            this.patronymicField.Size = new System.Drawing.Size(132, 20);
            this.patronymicField.TabIndex = 6;
            this.patronymicField.TextChanged += new System.EventHandler(this.patronymicField_TextChanged);
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(88, 129);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(132, 20);
            this.emailField.TabIndex = 8;
            this.emailField.TextChanged += new System.EventHandler(this.emailField_TextChanged);
            // 
            // organizationField
            // 
            this.organizationField.Location = new System.Drawing.Point(325, 28);
            this.organizationField.Name = "organizationField";
            this.organizationField.Size = new System.Drawing.Size(132, 20);
            this.organizationField.TabIndex = 9;
            this.organizationField.TextChanged += new System.EventHandler(this.organizationField_TextChanged);
            // 
            // purposeField
            // 
            this.purposeField.Location = new System.Drawing.Point(325, 54);
            this.purposeField.Name = "purposeField";
            this.purposeField.Size = new System.Drawing.Size(132, 20);
            this.purposeField.TabIndex = 10;
            this.purposeField.TextChanged += new System.EventHandler(this.purposeField_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Фамилия*:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Имя*:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Отчество*:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Телефон:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "E-mail:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(230, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Примечание:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Организация:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(230, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Серия:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Номер:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // birthDateField
            // 
            this.birthDateField.CustomFormat = "dd/MM/yyyy";
            this.birthDateField.Location = new System.Drawing.Point(325, 80);
            this.birthDateField.MinDate = new System.DateTime(1914, 1, 1, 0, 0, 0, 0);
            this.birthDateField.Name = "birthDateField";
            this.birthDateField.Size = new System.Drawing.Size(132, 20);
            this.birthDateField.TabIndex = 11;
            this.birthDateField.ValueChanged += new System.EventHandler(this.birthDateField_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(230, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Дата рождения:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(491, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 118);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // uploadImgBtn
            // 
            this.uploadImgBtn.Location = new System.Drawing.Point(503, 137);
            this.uploadImgBtn.Name = "uploadImgBtn";
            this.uploadImgBtn.Size = new System.Drawing.Size(140, 23);
            this.uploadImgBtn.TabIndex = 26;
            this.uploadImgBtn.Text = "Загрузить фото";
            this.uploadImgBtn.UseVisualStyleBackColor = true;
            this.uploadImgBtn.Click += new System.EventHandler(this.uploadImgBtn_Click);
            // 
            // phoneField
            // 
            this.phoneField.Location = new System.Drawing.Point(88, 103);
            this.phoneField.Mask = "+7 (###) ###-##-##";
            this.phoneField.Name = "phoneField";
            this.phoneField.Size = new System.Drawing.Size(132, 20);
            this.phoneField.TabIndex = 7;
            this.phoneField.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.phoneField_MaskInputRejected);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numberField);
            this.panel3.Controls.Add(this.serialField);
            this.panel3.Controls.Add(this.phoneField);
            this.panel3.Controls.Add(this.uploadImgBtn);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.birthDateField);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.purposeField);
            this.panel3.Controls.Add(this.organizationField);
            this.panel3.Controls.Add(this.emailField);
            this.panel3.Controls.Add(this.patronymicField);
            this.panel3.Controls.Add(this.nameField);
            this.panel3.Controls.Add(this.surnameField);
            this.panel3.Location = new System.Drawing.Point(25, 196);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(666, 188);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // numberField
            // 
            this.numberField.Location = new System.Drawing.Point(325, 129);
            this.numberField.Mask = "######";
            this.numberField.Name = "numberField";
            this.numberField.Size = new System.Drawing.Size(132, 20);
            this.numberField.TabIndex = 13;
            this.numberField.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.numberField_MaskInputRejected);
            // 
            // serialField
            // 
            this.serialField.Location = new System.Drawing.Point(325, 105);
            this.serialField.Mask = "####";
            this.serialField.Name = "serialField";
            this.serialField.Size = new System.Drawing.Size(132, 20);
            this.serialField.TabIndex = 12;
            this.serialField.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.serialField_MaskInputRejected);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Прикрепить файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PersonalVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PersonalVisit";
            this.Text = "Форма записи на индивидуальное посещение";
            this.Load += new System.EventHandler(this.PersonalVisit_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PersonalVisit_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PersonalVisit_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label clearForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox surnameField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.TextBox patronymicField;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.TextBox organizationField;
        private System.Windows.Forms.TextBox purposeField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker birthDateField;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button uploadImgBtn;
        private System.Windows.Forms.MaskedTextBox phoneField;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MaskedTextBox numberField;
        private System.Windows.Forms.MaskedTextBox serialField;
        private System.Windows.Forms.ComboBox subdivisionList;
        private System.Windows.Forms.ComboBox goalList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}