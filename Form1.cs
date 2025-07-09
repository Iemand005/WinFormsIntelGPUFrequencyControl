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
            SetMinSliderValue(min);
            SetMaxSliderValue(max);

        }

        void SetMinSliderValue(double min)
        {
            minSlider.Value = (int)min;
        }

        void SetMaxSliderValue(double max)
        {
            maxSlider.Value = (int)max;
        }

        private void minSlider_Scroll(object sender, EventArgs e)
        {

        }

        private void maxSlider_Scroll(object sender, EventArgs e)
        {

        }
    }
}
