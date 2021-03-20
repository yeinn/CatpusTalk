namespace Functional_Messeenger_Client
{
    partial class Home
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
            this.LogoutButton = new System.Windows.Forms.Button();
            this.UpdateFriendsList = new System.Windows.Forms.Button();
            this.Addfriend = new System.Windows.Forms.Button();
            this.friendIDbox = new System.Windows.Forms.TextBox();
            this.StartChatting = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Open_calender_button = new System.Windows.Forms.Button();
            this.progress1 = new System.Windows.Forms.ProgressBar();
            this.Dday_setEnd = new System.Windows.Forms.DateTimePicker();
            this.subject_box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.start_time = new System.Windows.Forms.Label();
            this.end_time = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.Label();
            this.Dday_label = new System.Windows.Forms.Label();
            this.progress2 = new System.Windows.Forms.ProgressBar();
            this.Dday_setEnd2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.subject_box2 = new System.Windows.Forms.TextBox();
            this.start_time2 = new System.Windows.Forms.Label();
            this.subject2 = new System.Windows.Forms.Label();
            this.end_time2 = new System.Windows.Forms.Label();
            this.Dday_label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.LogoutButton.FlatAppearance.BorderSize = 0;
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("함초롬바탕 확장", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LogoutButton.ForeColor = System.Drawing.Color.Red;
            this.LogoutButton.Location = new System.Drawing.Point(772, 36);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(98, 41);
            this.LogoutButton.TabIndex = 0;
            this.LogoutButton.Text = "로그아웃";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // UpdateFriendsList
            // 
            this.UpdateFriendsList.Location = new System.Drawing.Point(222, 180);
            this.UpdateFriendsList.Name = "UpdateFriendsList";
            this.UpdateFriendsList.Size = new System.Drawing.Size(80, 31);
            this.UpdateFriendsList.TabIndex = 2;
            this.UpdateFriendsList.Text = "최신화";
            this.UpdateFriendsList.UseVisualStyleBackColor = true;
            this.UpdateFriendsList.Click += new System.EventHandler(this.UpdateFriendsList_Click);
            // 
            // Addfriend
            // 
            this.Addfriend.Location = new System.Drawing.Point(222, 111);
            this.Addfriend.Name = "Addfriend";
            this.Addfriend.Size = new System.Drawing.Size(89, 28);
            this.Addfriend.TabIndex = 3;
            this.Addfriend.Text = "친구추가";
            this.Addfriend.UseVisualStyleBackColor = true;
            this.Addfriend.Click += new System.EventHandler(this.Addfriend_Click);
            // 
            // friendIDbox
            // 
            this.friendIDbox.Location = new System.Drawing.Point(222, 77);
            this.friendIDbox.Name = "friendIDbox";
            this.friendIDbox.Size = new System.Drawing.Size(193, 28);
            this.friendIDbox.TabIndex = 4;
            // 
            // StartChatting
            // 
            this.StartChatting.Location = new System.Drawing.Point(222, 145);
            this.StartChatting.Name = "StartChatting";
            this.StartChatting.Size = new System.Drawing.Size(89, 29);
            this.StartChatting.TabIndex = 5;
            this.StartChatting.Text = "채팅하기";
            this.StartChatting.UseVisualStyleBackColor = true;
            this.StartChatting.Click += new System.EventHandler(this.StartChatting_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_down);
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_move);
            this.tableLayoutPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_up);
            // 
            // Open_calender_button
            // 
            this.Open_calender_button.Location = new System.Drawing.Point(677, 38);
            this.Open_calender_button.Name = "Open_calender_button";
            this.Open_calender_button.Size = new System.Drawing.Size(89, 41);
            this.Open_calender_button.TabIndex = 7;
            this.Open_calender_button.Text = "달력";
            this.Open_calender_button.UseVisualStyleBackColor = true;
            this.Open_calender_button.Click += new System.EventHandler(this.Open_calender_button_Click);
            // 
            // progress1
            // 
            this.progress1.BackColor = System.Drawing.SystemColors.Control;
            this.progress1.Location = new System.Drawing.Point(222, 350);
            this.progress1.Name = "progress1";
            this.progress1.Size = new System.Drawing.Size(281, 26);
            this.progress1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress1.TabIndex = 8;
            // 
            // Dday_setEnd
            // 
            this.Dday_setEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dday_setEnd.Location = new System.Drawing.Point(390, 290);
            this.Dday_setEnd.Name = "Dday_setEnd";
            this.Dday_setEnd.Size = new System.Drawing.Size(162, 28);
            this.Dday_setEnd.TabIndex = 9;
            // 
            // subject_box
            // 
            this.subject_box.Location = new System.Drawing.Point(222, 290);
            this.subject_box.Name = "subject_box";
            this.subject_box.Size = new System.Drawing.Size(162, 28);
            this.subject_box.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(558, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "D-day 설정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start_time
            // 
            this.start_time.AutoSize = true;
            this.start_time.Location = new System.Drawing.Point(179, 379);
            this.start_time.Name = "start_time";
            this.start_time.Size = new System.Drawing.Size(54, 18);
            this.start_time.TabIndex = 12;
            this.start_time.Text = "label1";
            // 
            // end_time
            // 
            this.end_time.AutoSize = true;
            this.end_time.Location = new System.Drawing.Point(476, 379);
            this.end_time.Name = "end_time";
            this.end_time.Size = new System.Drawing.Size(54, 18);
            this.end_time.TabIndex = 13;
            this.end_time.Text = "label2";
            // 
            // subject
            // 
            this.subject.AutoSize = true;
            this.subject.Location = new System.Drawing.Point(219, 324);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(54, 18);
            this.subject.TabIndex = 14;
            this.subject.Text = "label3";
            // 
            // Dday_label
            // 
            this.Dday_label.AutoSize = true;
            this.Dday_label.Location = new System.Drawing.Point(510, 354);
            this.Dday_label.Name = "Dday_label";
            this.Dday_label.Size = new System.Drawing.Size(54, 18);
            this.Dday_label.TabIndex = 15;
            this.Dday_label.Text = "label1";
            // 
            // progress2
            // 
            this.progress2.BackColor = System.Drawing.SystemColors.Control;
            this.progress2.Location = new System.Drawing.Point(222, 476);
            this.progress2.Name = "progress2";
            this.progress2.Size = new System.Drawing.Size(281, 26);
            this.progress2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress2.TabIndex = 16;
            // 
            // Dday_setEnd2
            // 
            this.Dday_setEnd2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dday_setEnd2.Location = new System.Drawing.Point(390, 419);
            this.Dday_setEnd2.Name = "Dday_setEnd2";
            this.Dday_setEnd2.Size = new System.Drawing.Size(162, 28);
            this.Dday_setEnd2.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(558, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 28);
            this.button2.TabIndex = 18;
            this.button2.Text = "D-day 설정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // subject_box2
            // 
            this.subject_box2.Location = new System.Drawing.Point(222, 419);
            this.subject_box2.Name = "subject_box2";
            this.subject_box2.Size = new System.Drawing.Size(162, 28);
            this.subject_box2.TabIndex = 19;
            // 
            // start_time2
            // 
            this.start_time2.AutoSize = true;
            this.start_time2.Location = new System.Drawing.Point(179, 505);
            this.start_time2.Name = "start_time2";
            this.start_time2.Size = new System.Drawing.Size(54, 18);
            this.start_time2.TabIndex = 20;
            this.start_time2.Text = "label1";
            // 
            // subject2
            // 
            this.subject2.AutoSize = true;
            this.subject2.Location = new System.Drawing.Point(219, 455);
            this.subject2.Name = "subject2";
            this.subject2.Size = new System.Drawing.Size(54, 18);
            this.subject2.TabIndex = 21;
            this.subject2.Text = "label3";
            // 
            // end_time2
            // 
            this.end_time2.AutoSize = true;
            this.end_time2.Location = new System.Drawing.Point(476, 505);
            this.end_time2.Name = "end_time2";
            this.end_time2.Size = new System.Drawing.Size(54, 18);
            this.end_time2.TabIndex = 22;
            this.end_time2.Text = "label2";
            // 
            // Dday_label2
            // 
            this.Dday_label2.AutoSize = true;
            this.Dday_label2.Location = new System.Drawing.Point(509, 479);
            this.Dday_label2.Name = "Dday_label2";
            this.Dday_label2.Size = new System.Drawing.Size(54, 18);
            this.Dday_label2.TabIndex = 23;
            this.Dday_label2.Text = "label1";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 566);
            this.ControlBox = false;
            this.Controls.Add(this.Dday_label2);
            this.Controls.Add(this.end_time2);
            this.Controls.Add(this.subject2);
            this.Controls.Add(this.start_time2);
            this.Controls.Add(this.subject_box2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Dday_setEnd2);
            this.Controls.Add(this.progress2);
            this.Controls.Add(this.Dday_label);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.end_time);
            this.Controls.Add(this.start_time);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subject_box);
            this.Controls.Add(this.Dday_setEnd);
            this.Controls.Add(this.progress1);
            this.Controls.Add(this.Open_calender_button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StartChatting);
            this.Controls.Add(this.friendIDbox);
            this.Controls.Add(this.Addfriend);
            this.Controls.Add(this.UpdateFriendsList);
            this.Controls.Add(this.LogoutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button UpdateFriendsList;
        private System.Windows.Forms.Button Addfriend;
        private System.Windows.Forms.TextBox friendIDbox;
        private System.Windows.Forms.Button StartChatting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Open_calender_button;
        private System.Windows.Forms.ProgressBar progress1;
        private System.Windows.Forms.DateTimePicker Dday_setEnd;
        private System.Windows.Forms.TextBox subject_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label start_time;
        private System.Windows.Forms.Label end_time;
        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.Label Dday_label;
        private System.Windows.Forms.ProgressBar progress2;
        private System.Windows.Forms.DateTimePicker Dday_setEnd2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox subject_box2;
        private System.Windows.Forms.Label start_time2;
        private System.Windows.Forms.Label subject2;
        private System.Windows.Forms.Label end_time2;
        private System.Windows.Forms.Label Dday_label2;
    }
}