namespace Functional_Messeenger_Client
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.Send_button = new System.Windows.Forms.Button();
            this.Myschedule_date = new System.Windows.Forms.DateTimePicker();
            this.Sharing_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(12, 42);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(416, 433);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 495);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(316, 28);
            this.textBox.TabIndex = 1;
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(334, 495);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(94, 28);
            this.Send_button.TabIndex = 2;
            this.Send_button.Text = "보내기";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // Myschedule_date
            // 
            this.Myschedule_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Myschedule_date.Location = new System.Drawing.Point(118, 8);
            this.Myschedule_date.Name = "Myschedule_date";
            this.Myschedule_date.Size = new System.Drawing.Size(200, 28);
            this.Myschedule_date.TabIndex = 3;
            // 
            // Sharing_button
            // 
            this.Sharing_button.Location = new System.Drawing.Point(326, 1);
            this.Sharing_button.Name = "Sharing_button";
            this.Sharing_button.Size = new System.Drawing.Size(102, 39);
            this.Sharing_button.TabIndex = 4;
            this.Sharing_button.Text = "공유하기";
            this.Sharing_button.UseVisualStyleBackColor = true;
            this.Sharing_button.Click += new System.EventHandler(this.Sharing_button_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 544);
            this.Controls.Add(this.Sharing_button);
            this.Controls.Add(this.Myschedule_date);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.ChatBox);
            this.Name = "Client";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.DateTimePicker Myschedule_date;
        private System.Windows.Forms.Button Sharing_button;
    }
}

