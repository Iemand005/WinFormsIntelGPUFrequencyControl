using LevelZero;

namespace WinFormsIntelGPUFrequencyControl
{
    public partial class Form1 : Form
    {
        private IntelGPUController gpuController;

        private bool hasMinSliderMoved = false;
        private bool hasMaxSliderMoved = false;

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

            if (sender == minSlider) hasMinSliderMoved = true;
            if (sender == maxSlider) hasMaxSliderMoved = true;

            if (gpuController != null) gpuController.SetFrequencyRange(hasMinSliderMoved ? minSlider.Value : 0, hasMaxSliderMoved ? maxSlider.Value : 0);
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

            hasMinSliderMoved = false;
            hasMaxSliderMoved = false;
        }

        private void Reset()
        {
            gpuController.SetFrequencyRange(-1, -1);
            InitSlidersAndLabels();
        }

        private void EnableHardwareRange()
        {
            gpuController.SetFrequencyRange(0, 0);
            InitSlidersAndLabels();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            EnableHardwareRange();
        }
    }
}
