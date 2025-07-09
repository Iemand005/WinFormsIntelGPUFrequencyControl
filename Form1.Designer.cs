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
            minSlider = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            maxSlider = new TrackBar();
            maxFreqLabel = new Label();
            minFreqLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)minSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxSlider).BeginInit();
            SuspendLayout();
            // 
            // minSlider
            // 
            minSlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            minSlider.Location = new Point(12, 24);
            minSlider.Margin = new Padding(3, 2, 3, 2);
            minSlider.Name = "minSlider";
            minSlider.Size = new Size(676, 45);
            minSlider.TabIndex = 0;
            minSlider.Scroll += UpdateFrequencyRangeOverride;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 68);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 1;
            label1.Text = "Max";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 7);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 3;
            label2.Text = "Min";
            // 
            // maxSlider
            // 
            maxSlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            maxSlider.Location = new Point(12, 85);
            maxSlider.Margin = new Padding(3, 2, 3, 2);
            maxSlider.Name = "maxSlider";
            maxSlider.Size = new Size(676, 45);
            maxSlider.TabIndex = 2;
            maxSlider.Scroll += UpdateFrequencyRangeOverride;
            // 
            // maxFreqLabel
            // 
            maxFreqLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxFreqLabel.AutoSize = true;
            maxFreqLabel.Location = new Point(644, 68);
            maxFreqLabel.Name = "maxFreqLabel";
            maxFreqLabel.Size = new Size(41, 15);
            maxFreqLabel.TabIndex = 4;
            maxFreqLabel.Text = "0 MHz";
            // 
            // minFreqLabel
            // 
            minFreqLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minFreqLabel.AutoSize = true;
            minFreqLabel.Location = new Point(646, 7);
            minFreqLabel.Name = "minFreqLabel";
            minFreqLabel.Size = new Size(41, 15);
            minFreqLabel.TabIndex = 5;
            minFreqLabel.Text = "0 MHz";
            // 
            // button1
            // 
            button1.Location = new Point(12, 135);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += resetButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(93, 135);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Unlock";
            button2.UseVisualStyleBackColor = true;
            button2.Click += unlockButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(minFreqLabel);
            Controls.Add(maxFreqLabel);
            Controls.Add(label2);
            Controls.Add(maxSlider);
            Controls.Add(label1);
            Controls.Add(minSlider);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)minSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar minSlider;
        private Label label1;
        private Label label2;
        private TrackBar maxSlider;
        private Label maxFreqLabel;
        private Label minFreqLabel;
        private Button button1;
        private Button button2;
    }
}
