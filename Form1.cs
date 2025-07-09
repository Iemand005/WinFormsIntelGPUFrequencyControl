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
            trackBar1.Minimum = trackBar2.Minimum = (int)minSupported;
            trackBar1.Maximum = trackBar2.Maximum = (int)maxSupported;
            

            gpuController.GetFrequencyRange(out double min, out double max);
            trackBar1.Value = (int)min;
            trackBar2.Value = (int)max;
        }

        void SetMinSliderValue(double min)
        {

        }

        void SetMaxSliderValue(double min)
        {

        }
    }
}
