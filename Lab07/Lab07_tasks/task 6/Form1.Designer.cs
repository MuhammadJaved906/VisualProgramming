namespace lab07_task_06
{
    partial class Form1
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelSetTime = new System.Windows.Forms.Label();
            this.textBoxSetTime = new System.Windows.Forms.TextBox();
            this.labelTimeLeft = new System.Windows.Forms.Label();
            this.textBoxTimeLeft = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelSetTime
            // 
            this.labelSetTime.AutoSize = true;
            this.labelSetTime.Location = new System.Drawing.Point(85, 47);
            this.labelSetTime.Name = "labelSetTime";
            this.labelSetTime.Size = new System.Drawing.Size(140, 16);
            this.labelSetTime.TabIndex = 0;
            this.labelSetTime.Text = "Set Time (in seconds):";
            // 
            // textBoxSetTime
            // 
            this.textBoxSetTime.Location = new System.Drawing.Point(303, 44);
            this.textBoxSetTime.Name = "textBoxSetTime";
            this.textBoxSetTime.Size = new System.Drawing.Size(100, 22);
            this.textBoxSetTime.TabIndex = 1;
            // 
            // labelTimeLeft
            // 
            this.labelTimeLeft.AutoSize = true;
            this.labelTimeLeft.Location = new System.Drawing.Point(100, 110);
            this.labelTimeLeft.Name = "labelTimeLeft";
            this.labelTimeLeft.Size = new System.Drawing.Size(65, 16);
            this.labelTimeLeft.TabIndex = 2;
            this.labelTimeLeft.Text = "Time Left:";
            // 
            // textBoxTimeLeft
            // 
            this.textBoxTimeLeft.Location = new System.Drawing.Point(290, 107);
            this.textBoxTimeLeft.Name = "textBoxTimeLeft";
            this.textBoxTimeLeft.ReadOnly = true;
            this.textBoxTimeLeft.Size = new System.Drawing.Size(113, 22);
            this.textBoxTimeLeft.TabIndex = 3;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(189, 189);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start Countdown";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxTimeLeft);
            this.Controls.Add(this.labelTimeLeft);
            this.Controls.Add(this.textBoxSetTime);
            this.Controls.Add(this.labelSetTime);
            this.Name = "Form1";
            this.Text = "Countdown Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSetTime;
        private System.Windows.Forms.TextBox textBoxSetTime;
        private System.Windows.Forms.Label labelTimeLeft;
        private System.Windows.Forms.TextBox textBoxTimeLeft;
        private System.Windows.Forms.Button buttonStart;  // Changed from 'buttonStart_Click' to 'buttonStart'
        private System.Windows.Forms.Timer timerCountdown;
    }
}
