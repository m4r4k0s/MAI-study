namespace wmp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sizeD = new System.Windows.Forms.Panel();
            this.moovingP = new System.Windows.Forms.Panel();
            this.sizeR = new System.Windows.Forms.Panel();
            this.sizeL = new System.Windows.Forms.Panel();
            this.DockTop = new System.Windows.Forms.Panel();
            this.DockBottom = new System.Windows.Forms.Panel();
            this.DockLeft = new System.Windows.Forms.Panel();
            this.DockRight = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.sizeD);
            this.groupBox1.Controls.Add(this.moovingP);
            this.groupBox1.Controls.Add(this.sizeR);
            this.groupBox1.Controls.Add(this.sizeL);
            this.groupBox1.Location = new System.Drawing.Point(67, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(267, 431);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(4, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 412);
            this.textBox1.TabIndex = 4;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);
            // 
            // sizeD
            // 
            this.sizeD.BackColor = System.Drawing.SystemColors.Control;
            this.sizeD.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.sizeD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sizeD.Location = new System.Drawing.Point(4, 427);
            this.sizeD.Margin = new System.Windows.Forms.Padding(4);
            this.sizeD.Name = "sizeD";
            this.sizeD.Size = new System.Drawing.Size(259, 4);
            this.sizeD.TabIndex = 3;
            this.sizeD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeD_MouseDown);
            this.sizeD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sizeD_MouseUp);
            // 
            // moovingP
            // 
            this.moovingP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moovingP.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.moovingP.Location = new System.Drawing.Point(0, 0);
            this.moovingP.Margin = new System.Windows.Forms.Padding(4);
            this.moovingP.Name = "moovingP";
            this.moovingP.Size = new System.Drawing.Size(266, 30);
            this.moovingP.TabIndex = 2;
            this.moovingP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moovingP_MouseDown);
            this.moovingP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moovingP_MouseUp);
            // 
            // sizeR
            // 
            this.sizeR.BackColor = System.Drawing.SystemColors.Control;
            this.sizeR.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.sizeR.Dock = System.Windows.Forms.DockStyle.Right;
            this.sizeR.Location = new System.Drawing.Point(263, 15);
            this.sizeR.Margin = new System.Windows.Forms.Padding(4);
            this.sizeR.Name = "sizeR";
            this.sizeR.Size = new System.Drawing.Size(4, 416);
            this.sizeR.TabIndex = 1;
            this.sizeR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeR_MouseDown);
            this.sizeR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sizeR_MouseUp);
            // 
            // sizeL
            // 
            this.sizeL.BackColor = System.Drawing.SystemColors.Control;
            this.sizeL.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.sizeL.Dock = System.Windows.Forms.DockStyle.Left;
            this.sizeL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sizeL.Location = new System.Drawing.Point(0, 15);
            this.sizeL.Margin = new System.Windows.Forms.Padding(4);
            this.sizeL.Name = "sizeL";
            this.sizeL.Size = new System.Drawing.Size(4, 416);
            this.sizeL.TabIndex = 0;
            this.sizeL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizeL_MouseDown);
            this.sizeL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sizeL_MouseUp);
            // 
            // DockTop
            // 
            this.DockTop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DockTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DockTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.DockTop.Location = new System.Drawing.Point(0, 0);
            this.DockTop.Margin = new System.Windows.Forms.Padding(4);
            this.DockTop.Name = "DockTop";
            this.DockTop.Size = new System.Drawing.Size(1067, 61);
            this.DockTop.TabIndex = 1;
            // 
            // DockBottom
            // 
            this.DockBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DockBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DockBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DockBottom.Location = new System.Drawing.Point(0, 493);
            this.DockBottom.Margin = new System.Windows.Forms.Padding(4);
            this.DockBottom.Name = "DockBottom";
            this.DockBottom.Size = new System.Drawing.Size(1067, 61);
            this.DockBottom.TabIndex = 2;
            // 
            // DockLeft
            // 
            this.DockLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DockLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DockLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.DockLeft.Location = new System.Drawing.Point(0, 61);
            this.DockLeft.Margin = new System.Windows.Forms.Padding(4);
            this.DockLeft.Name = "DockLeft";
            this.DockLeft.Size = new System.Drawing.Size(66, 432);
            this.DockLeft.TabIndex = 3;
            // 
            // DockRight
            // 
            this.DockRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DockRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DockRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.DockRight.Location = new System.Drawing.Point(1001, 61);
            this.DockRight.Margin = new System.Windows.Forms.Padding(4);
            this.DockRight.Name = "DockRight";
            this.DockRight.Size = new System.Drawing.Size(66, 432);
            this.DockRight.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DockRight);
            this.Controls.Add(this.DockLeft);
            this.Controls.Add(this.DockBottom);
            this.Controls.Add(this.DockTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "wmp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel sizeD;
        private System.Windows.Forms.Panel moovingP;
        private System.Windows.Forms.Panel sizeR;
        private System.Windows.Forms.Panel sizeL;
        private System.Windows.Forms.Panel DockTop;
        private System.Windows.Forms.Panel DockBottom;
        private System.Windows.Forms.Panel DockLeft;
        private System.Windows.Forms.Panel DockRight;
        private System.Windows.Forms.TextBox textBox1;
    }
}

