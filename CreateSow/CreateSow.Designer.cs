namespace CreateSowNamespace
{
    partial class CreateSow
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
            this.textBoxProjectTitle = new System.Windows.Forms.TextBox();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bCreateSow = new System.Windows.Forms.Button();
            this.checkBoxTestPlan = new System.Windows.Forms.CheckBox();
            this.checkBoxEmails = new System.Windows.Forms.CheckBox();
            this.checkBoxTSoW = new System.Windows.Forms.CheckBox();
            this.checkBoxPlan = new System.Windows.Forms.CheckBox();
            this.projectDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.FunctionalSpecNumberLabel = new System.Windows.Forms.Label();
            this.fsNumbertextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxProjectTitle
            // 
            this.textBoxProjectTitle.Location = new System.Drawing.Point(107, 39);
            this.textBoxProjectTitle.Name = "textBoxProjectTitle";
            this.textBoxProjectTitle.Size = new System.Drawing.Size(273, 20);
            this.textBoxProjectTitle.TabIndex = 0;
            this.textBoxProjectTitle.TextChanged += new System.EventHandler(this.textBoxProjectTitle_TextChanged);
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(107, 81);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(273, 20);
            this.textBoxCustomer.TabIndex = 1;
            this.textBoxCustomer.Text = "TrakM8";
            this.textBoxCustomer.WordWrap = false;
            this.textBoxCustomer.TextChanged += new System.EventHandler(this.textBoxCustomer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer";
            // 
            // bCreateSow
            // 
            this.bCreateSow.Location = new System.Drawing.Point(466, 94);
            this.bCreateSow.Name = "bCreateSow";
            this.bCreateSow.Size = new System.Drawing.Size(75, 23);
            this.bCreateSow.TabIndex = 7;
            this.bCreateSow.Text = "Create";
            this.bCreateSow.UseVisualStyleBackColor = true;
            this.bCreateSow.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxTestPlan
            // 
            this.checkBoxTestPlan.AutoSize = true;
            this.checkBoxTestPlan.Location = new System.Drawing.Point(107, 111);
            this.checkBoxTestPlan.Name = "checkBoxTestPlan";
            this.checkBoxTestPlan.Size = new System.Drawing.Size(68, 17);
            this.checkBoxTestPlan.TabIndex = 10;
            this.checkBoxTestPlan.Text = "TestPlan";
            this.checkBoxTestPlan.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmails
            // 
            this.checkBoxEmails.AutoSize = true;
            this.checkBoxEmails.Location = new System.Drawing.Point(107, 134);
            this.checkBoxEmails.Name = "checkBoxEmails";
            this.checkBoxEmails.Size = new System.Drawing.Size(56, 17);
            this.checkBoxEmails.TabIndex = 11;
            this.checkBoxEmails.Text = "Emails";
            this.checkBoxEmails.UseVisualStyleBackColor = true;
            // 
            // checkBoxTSoW
            // 
            this.checkBoxTSoW.AutoSize = true;
            this.checkBoxTSoW.Location = new System.Drawing.Point(107, 158);
            this.checkBoxTSoW.Name = "checkBoxTSoW";
            this.checkBoxTSoW.Size = new System.Drawing.Size(165, 17);
            this.checkBoxTSoW.TabIndex = 12;
            this.checkBoxTSoW.Text = "Technical Statement of Work";
            this.checkBoxTSoW.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlan
            // 
            this.checkBoxPlan.AutoSize = true;
            this.checkBoxPlan.Location = new System.Drawing.Point(107, 180);
            this.checkBoxPlan.Name = "checkBoxPlan";
            this.checkBoxPlan.Size = new System.Drawing.Size(47, 17);
            this.checkBoxPlan.TabIndex = 13;
            this.checkBoxPlan.Text = "Plan";
            this.checkBoxPlan.UseVisualStyleBackColor = true;
            // 
            // projectDescriptionTextBox
            // 
            this.projectDescriptionTextBox.Location = new System.Drawing.Point(24, 262);
            this.projectDescriptionTextBox.Multiline = true;
            this.projectDescriptionTextBox.Name = "projectDescriptionTextBox";
            this.projectDescriptionTextBox.Size = new System.Drawing.Size(541, 20);
            this.projectDescriptionTextBox.TabIndex = 14;
            this.projectDescriptionTextBox.Text = "Enter a Short (one line) Project Description Here ";
            this.projectDescriptionTextBox.TextChanged += new System.EventHandler(this.projectDescriptionTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Project Description ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 93);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Project Expected Due Date";
            // 
            // FunctionalSpecNumberLabel
            // 
            this.FunctionalSpecNumberLabel.AutoSize = true;
            this.FunctionalSpecNumberLabel.Location = new System.Drawing.Point(21, 384);
            this.FunctionalSpecNumberLabel.Name = "FunctionalSpecNumberLabel";
            this.FunctionalSpecNumberLabel.Size = new System.Drawing.Size(171, 13);
            this.FunctionalSpecNumberLabel.TabIndex = 19;
            this.FunctionalSpecNumberLabel.Text = "Allocated Functional Spec Number";
            // 
            // fsNumbertextbox
            // 
            this.fsNumbertextbox.Location = new System.Drawing.Point(198, 381);
            this.fsNumbertextbox.Name = "fsNumbertextbox";
            this.fsNumbertextbox.ReadOnly = true;
            this.fsNumbertextbox.Size = new System.Drawing.Size(99, 20);
            this.fsNumbertextbox.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bCreateSow);
            this.panel1.Location = new System.Drawing.Point(12, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 137);
            this.panel1.TabIndex = 20;
            // 
            // CreateSow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 416);
            this.Controls.Add(this.FunctionalSpecNumberLabel);
            this.Controls.Add(this.fsNumbertextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projectDescriptionTextBox);
            this.Controls.Add(this.checkBoxPlan);
            this.Controls.Add(this.checkBoxTSoW);
            this.Controls.Add(this.checkBoxEmails);
            this.Controls.Add(this.checkBoxTestPlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.textBoxProjectTitle);
            this.Controls.Add(this.panel1);
            this.Name = "CreateSow";
            this.Text = "New Statement Of Work";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProjectTitle;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCreateSow;
        private System.Windows.Forms.CheckBox checkBoxTestPlan;
        private System.Windows.Forms.CheckBox checkBoxEmails;
        private System.Windows.Forms.CheckBox checkBoxTSoW;
        private System.Windows.Forms.CheckBox checkBoxPlan;
        private System.Windows.Forms.TextBox projectDescriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FunctionalSpecNumberLabel;
        private System.Windows.Forms.TextBox fsNumbertextbox;
        private System.Windows.Forms.Panel panel1;
    }
}

