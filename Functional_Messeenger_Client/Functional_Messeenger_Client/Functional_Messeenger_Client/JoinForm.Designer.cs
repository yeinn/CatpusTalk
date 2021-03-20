namespace Functional_Messeenger_Client
{
    partial class JoinForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tryJoinButton = new System.Windows.Forms.Button();
            this.idCheckBox = new System.Windows.Forms.Button();
            this.checkPwBox = new System.Windows.Forms.TextBox();
            this.pwbox = new System.Windows.Forms.TextBox();
            this.idbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tryJoinButton);
            this.groupBox1.Controls.Add(this.idCheckBox);
            this.groupBox1.Controls.Add(this.checkPwBox);
            this.groupBox1.Controls.Add(this.pwbox);
            this.groupBox1.Controls.Add(this.idbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "회원가입";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tryJoinButton
            // 
            this.tryJoinButton.Location = new System.Drawing.Point(359, 163);
            this.tryJoinButton.Name = "tryJoinButton";
            this.tryJoinButton.Size = new System.Drawing.Size(93, 32);
            this.tryJoinButton.TabIndex = 7;
            this.tryJoinButton.Text = "가입하기";
            this.tryJoinButton.UseVisualStyleBackColor = true;
            this.tryJoinButton.Click += new System.EventHandler(this.tryJoinButton_Click);
            // 
            // idCheckBox
            // 
            this.idCheckBox.Location = new System.Drawing.Point(359, 45);
            this.idCheckBox.Name = "idCheckBox";
            this.idCheckBox.Size = new System.Drawing.Size(93, 36);
            this.idCheckBox.TabIndex = 6;
            this.idCheckBox.Text = "중복확인";
            this.idCheckBox.UseVisualStyleBackColor = true;
            this.idCheckBox.Click += new System.EventHandler(this.idCheckBox_Click);
            // 
            // checkPwBox
            // 
            this.checkPwBox.Location = new System.Drawing.Point(123, 129);
            this.checkPwBox.Name = "checkPwBox";
            this.checkPwBox.Size = new System.Drawing.Size(329, 28);
            this.checkPwBox.TabIndex = 5;
            // 
            // pwbox
            // 
            this.pwbox.Location = new System.Drawing.Point(80, 94);
            this.pwbox.Name = "pwbox";
            this.pwbox.Size = new System.Drawing.Size(372, 28);
            this.pwbox.TabIndex = 4;
            // 
            // idbox
            // 
            this.idbox.Location = new System.Drawing.Point(67, 49);
            this.idbox.Name = "idbox";
            this.idbox.Size = new System.Drawing.Size(285, 28);
            this.idbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "PW 확인 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "PW : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID : ";
            // 
            // JoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 249);
            this.Controls.Add(this.groupBox1);
            this.Name = "JoinForm";
            this.Text = "JoinForm";
            this.Load += new System.EventHandler(this.JoinForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tryJoinButton;
        private System.Windows.Forms.Button idCheckBox;
        private System.Windows.Forms.TextBox checkPwBox;
        private System.Windows.Forms.TextBox pwbox;
        private System.Windows.Forms.TextBox idbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}