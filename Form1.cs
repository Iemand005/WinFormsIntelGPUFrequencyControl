using LevelZero;

namespace WinFormsIntelGPUFrequencyControl
{
    public partial class Form1 : Form
    {
        private IntelGPUController gpuController;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gpuController = new IntelGPUController();
            gpuController.GetSupportedFrequencyRange(out double minSupported, out double maxSupported);
            minSlider.Minimum = maxSlider.Minimum = (int)minSupported;
            minSlider.Maximum = maxSlider.Maximum = (int)maxSupported;

            gpuController.GetFrequencyRange(out double min, out double max);
            minSlider.Value = (int)min;
            maxSlider.Value = (int)max;
            UpdateFrequencyLabels();
        }

        private void UpdateFrequencyLabels()
        {
            minFreqLabel.Text = $"{minSlider.Value} MHz";
            maxFreqLabel.Text = $"{maxSlider.Value} MHz";
        }

        private void UpdateFrequencyRangeOverride(object sender, EventArgs e)
        {
            if (minSlider.Value > maxSlider.Value)
                maxSlider.Value = minSlider.Value;
            else if (minSlider.Value < maxSlider.Value)
                minSlider.Value = maxSlider.Value;

            gpuController.SetFrequencyRange(minSlider.Value, maxSlider.Value);
            UpdateFrequencyLabels();
        }
    }
}
