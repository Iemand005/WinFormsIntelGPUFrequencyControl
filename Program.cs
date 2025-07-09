using LevelZero;

namespace WinFormsIntelGPUFrequencyControl
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            int result = LevelZeroInterop.Init(1);

            uint driverCount = 0;
            result = LevelZeroInterop.GetDriver(ref driverCount, null);
            if (driverCount > 0)
            {
                DriverHandle[] drivers = new DriverHandle[driverCount];
                result = LevelZeroInterop.GetDriver(ref driverCount, drivers);

                uint deviceCount = 0;
                result = LevelZeroInterop.GetDevice(drivers[0], ref deviceCount);

                DeviceHandle[] devices = new DeviceHandle[deviceCount];
                result = LevelZeroInterop.GetDevice(drivers[0], ref deviceCount, devices);

                uint freqDomainCount = 0;
                result = LevelZeroInterop.EnumDeviceFrequencyDomains(devices[0], ref freqDomainCount, null);

                FrequencyHandle[] freqHandles = new FrequencyHandle[freqDomainCount];
                result = LevelZeroInterop.EnumDeviceFrequencyDomains(devices[0], ref freqDomainCount, freqHandles);

                foreach (FrequencyHandle frequencyHandle in freqHandles)
                {
                    FrequencyProperties properties = new FrequencyProperties();
                    result = LevelZeroInterop.GetFrequencyProperties(frequencyHandle, ref properties);

                    FrequencyRange range = new FrequencyRange();
                    result = LevelZeroInterop.GetFrequencyRange(frequencyHandle, ref range);

                    range.Min = -1;
                    range.Max = 200;

                    result = LevelZeroInterop.SetFrequencyRange(frequencyHandle, ref range);
                }
            }



            //bool good = LevelZeroInterop.ZesFrequencyGetRange();

            Application.Run(new Form1());
        }
    }
}