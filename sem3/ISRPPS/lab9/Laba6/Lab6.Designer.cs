namespace Laba6
{
    partial class Lab6
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
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.fontSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.setLabelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(14, 14);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(290, 212);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // fontSizeTrackBar
            // 
            this.fontSizeTrackBar.Location = new System.Drawing.Point(74, 233);
            this.fontSizeTrackBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fontSizeTrackBar.Name = "fontSizeTrackBar";
            this.fontSizeTrackBar.Size = new System.Drawing.Size(169, 45);
            this.fontSizeTrackBar.TabIndex = 1;
            this.fontSizeTrackBar.Scroll += new System.EventHandler(this.FontSizeTrackBar_Scroll);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(284, 245);
            this.fontSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(20, 15);
            this.fontSizeLabel.TabIndex = 8;
            this.fontSizeLabel.Text = "px";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(14, 245);
            this.fontLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(59, 15);
            this.fontLabel.TabIndex = 7;
            this.fontLabel.Text = "Font size: ";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(152, 299);
            this.checkBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(102, 19);
            this.checkBox.TabIndex = 6;
            this.checkBox.Text = "disable button";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clearButton.Location = new System.Drawing.Point(14, 292);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(98, 30);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // setLabelButton
            // 
            this.setLabelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.setLabelButton.Location = new System.Drawing.Point(14, 331);
            this.setLabelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setLabelButton.Name = "setLabelButton";
            this.setLabelButton.Size = new System.Drawing.Size(98, 29);
            this.setLabelButton.TabIndex = 9;
            this.setLabelButton.Text = "set label";
            this.setLabelButton.UseVisualStyleBackColor = false;
            this.setLabelButton.Click += new System.EventHandler(this.SetLabelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(119, 336);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label";
            // 
            // Lab6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setLabelButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.fontSizeTrackBar);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Lab6";
            this.Text = "Lab6";
            this.Load += new System.EventHandler(this.Lab6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.TrackBar fontSizeTrackBar;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button setLabelButton;
        private System.Windows.Forms.Label label1;
    }
}


