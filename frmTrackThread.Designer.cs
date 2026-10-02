namespace ThreadPriorityApp
{
    partial class FrmTrackThread
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatus = new Label();
            btnRun = new Button();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 133);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Thread Starts";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRun
            // 
            btnRun.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(59, 145);
            btnRun.Margin = new Padding(50, 3, 50, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(266, 81);
            btnRun.TabIndex = 1;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 250);
            Controls.Add(btnRun);
            Controls.Add(lblStatus);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ThreadPriorityApp";
            ResumeLayout(false);
        }

        #endregion

        private Label lblStatus;
        private Button btnRun;
    }
}
