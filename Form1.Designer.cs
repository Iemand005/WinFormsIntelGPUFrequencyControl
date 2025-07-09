namespace WinFormsIntelGPUFrequencyControl
{
    partial class Form1
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
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            trackBar2 = new TrackBar();
            maxFreqLabel = new Label();
            minFreqLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.Location = new Point(12, 114);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(776, 56);
            trackBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 91);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 1;
            label1.Text = "Max";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 3;
            label2.Text = "Min";
            // 
            // trackBar2
            // 
            trackBar2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar2.Location = new Point(12, 32);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(776, 56);
            trackBar2.TabIndex = 2;
            // 
            // maxFreqLabel
            // 
            maxFreqLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxFreqLabel.AutoSize = true;
            maxFreqLabel.Location = new Point(736, 91);
            maxFreqLabel.Name = "maxFreqLabel";
            maxFreqLabel.Size = new Size(52, 20);
            maxFreqLabel.TabIndex = 4;
            maxFreqLabel.Text = "0 MHz";
            // 
            // minFreqLabel
            // 
            minFreqLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minFreqLabel.AutoSize = true;
            minFreqLabel.Location = new Point(738, 9);
            minFreqLabel.Name = "minFreqLabel";
            minFreqLabel.Size = new Size(52, 20);
            minFreqLabel.TabIndex = 5;
            minFreqLabel.Text = "0 MHz";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(minFreqLabel);
            Controls.Add(maxFreqLabel);
            Controls.Add(label2);
            Controls.Add(trackBar2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private TrackBar trackBar2;
        private Label maxFreqLabel;
        private Label minFreqLabel;
    }
}
