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
            try
            {
                gpuController = new IntelGPUController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Intel GPU Controller: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            InitSlidersAndLabels();
        }

        private void UpdateFrequencyLabels()
        {
            minFreqLabel.Text = $"{minSlider.Value} MHz";
            maxFreqLabel.Text = $"{maxSlider.Value} MHz";
        }

        private void UpdateFrequencyRangeOverride(object sender, EventArgs e)
        {
            if (sender == minSlider && minSlider.Value > maxSlider.Value)
                maxSlider.Value = minSlider.Value;
            else if (sender == maxSlider && maxSlider.Value < minSlider.Value)
                minSlider.Value = maxSlider.Value;

            if (gpuController != null) gpuController.SetFrequencyRange(minSlider.Value, maxSlider.Value);
            UpdateFrequencyLabels();
        }

        private void InitSlidersAndLabels()
        {
            gpuController.GetSupportedFrequencyRange(out double minSupported, out double maxSupported);
            minSlider.Minimum = maxSlider.Minimum = (int)minSupported;
            minSlider.Maximum = maxSlider.Maximum = (int)maxSupported;

            gpuController.GetFrequencyRange(out double min, out double max);
            minSlider.Value = (int)min;
            maxSlider.Value = (int)max;
            UpdateFrequencyLabels();
        }

        private void Reset(object sender, EventArgs e)
        {
            gpuController.SetFrequencyRange(-1, -1);
            InitSlidersAndLabels();
        }

        private void EnableHardwareRange(object sender, EventArgs e)
        {
            gpuController.SetFrequencyRange(0, 0);
            InitSlidersAndLabels();
        }
    }
}
