﻿namespace Functionality_Messenger_Server
{
    partial class HomeServer
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
            this.statusBox = new System.Windows.Forms.RichTextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.disposeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 12);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(374, 388);
            this.statusBox.TabIndex = 0;
            this.statusBox.Text = "";
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(12, 406);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(192, 32);
            this.listenButton.TabIndex = 1;
            this.listenButton.Text = "서버개설";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.ListenButton_Click);
            // 
            // disposeButton
            // 
            this.disposeButton.Location = new System.Drawing.Point(211, 407);
            this.disposeButton.Name = "disposeButton";
            this.disposeButton.Size = new System.Drawing.Size(175, 31);
            this.disposeButton.TabIndex = 2;
            this.disposeButton.Text = "연결 해제";
            this.disposeButton.UseVisualStyleBackColor = true;
            this.disposeButton.Click += new System.EventHandler(this.DisposeButton_Click);
            // 
            // HomeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 450);
            this.Controls.Add(this.disposeButton);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.statusBox);
            this.Name = "HomeServer";
            this.Text = "HomeServer";
            this.Load += new System.EventHandler(this.HomeServer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox statusBox;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.Button disposeButton;
    }
}