namespace Functional_Messeenger_Client
{
    partial class Calender
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.schedule_box = new System.Windows.Forms.RichTextBox();
            this.Save_button = new System.Windows.Forms.Button();
            this.Erase_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(28, 18);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // schedule_box
            // 
            this.schedule_box.Location = new System.Drawing.Point(350, 18);
            this.schedule_box.Name = "schedule_box";
            this.schedule_box.Size = new System.Drawing.Size(396, 331);
            this.schedule_box.TabIndex = 1;
            this.schedule_box.Text = "";
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(28, 304);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(94, 35);
            this.Save_button.TabIndex = 2;
            this.Save_button.Text = "저장하기";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Erase_button
            // 
            this.Erase_button.Location = new System.Drawing.Point(128, 304);
            this.Erase_button.Name = "Erase_button";
            this.Erase_button.Size = new System.Drawing.Size(97, 35);
            this.Erase_button.TabIndex = 3;
            this.Erase_button.Text = "지우기";
            this.Erase_button.UseVisualStyleBackColor = true;
            this.Erase_button.Click += new System.EventHandler(this.Erase_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(231, 304);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(94, 35);
            this.Exit_button.TabIndex = 4;
            this.Exit_button.Text = "나가기";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 368);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Erase_button);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.schedule_box);
            this.Controls.Add(this.monthCalendar);
            this.Name = "Calender";
            this.Text = "Calender";
            this.Load += new System.EventHandler(this.Calender_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.RichTextBox schedule_box;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button Erase_button;
        private System.Windows.Forms.Button Exit_button;
    }
}