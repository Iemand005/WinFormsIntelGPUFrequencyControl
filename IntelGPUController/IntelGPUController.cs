using LevelZero;
using System.Runtime;

namespace LevelZero
{
    public class IntelGPUController
    {
        private DriverHandle[] _drivers;
        private DeviceHandle[] _devices;
        private FrequencyHandle[] _freqHandles;

        public IntelGPUController()
        {
            int result = LevelZeroInterop.Init(1);
            if (result != 0)
                throw new Exception("Failed to initialize Level Zero.");

            uint driverCount = 0;
            result = LevelZeroInterop.GetDriver(ref driverCount, null);
            if (result != 0 || driverCount == 0)
                throw new Exception("No drivers found.");

            _drivers = new DriverHandle[driverCount];
            result = LevelZeroInterop.GetDriver(ref driverCount, _drivers);
            if (result != 0)
                throw new Exception("Failed to get drivers.");

            uint deviceCount = 0;
            result = LevelZeroInterop.GetDevice(_drivers[0], ref deviceCount);
            if (result != 0 || deviceCount == 0)
                throw new Exception("No devices found.");

            _devices = new DeviceHandle[deviceCount];
            result = LevelZeroInterop.GetDevice(_drivers[0], ref deviceCount, _devices);
            if (result != 0)
                throw new Exception("Failed to get devices.");


            uint freqDomainCount = 0;
            result = LevelZeroInterop.EnumDeviceFrequencyDomains(_devices[0], ref freqDomainCount);
            if (result != 0 || freqDomainCount == 0)
                throw new Exception("No frequency domains found.");
            _freqHandles = new FrequencyHandle[freqDomainCount];
            result = LevelZeroInterop.EnumDeviceFrequencyDomains(_devices[0], ref freqDomainCount, _freqHandles);
            if (result != 0)
                throw new Exception("Failed to enumerate frequency domains.");
        }

        public void GetSupportedFrequencyRange(out double min, out double max)
        {
            foreach (var handle in _freqHandles)
            {
                FrequencyProperties properties = new FrequencyProperties();
                int result = LevelZeroInterop.GetFrequencyProperties(handle, ref properties);
                if (result != 0)
                    throw new Exception("Failed to get frequency properties.");
                min = properties.Min;
                max = properties.Max;
                return;
            }
            throw new Exception("Frequency domain not found.");
        }

        public void GetFrequencyRange(out double min, out double max)
        {
            foreach (var handle in _freqHandles)
            {
                FrequencyRange range = new FrequencyRange();
                int result = LevelZeroInterop.GetFrequencyRange(handle, ref range);
                if (result != 0)
                    throw new Exception("Failed to get frequency range.");
                min = range.Min;
                max = range.Max;
                return;
            }
            throw new Exception("Frequency domain not found.");
        }

        public void SetFrequencyRange(double min, double max)
        {
            foreach (var handle in _freqHandles)
            {
                FrequencyRange range = new FrequencyRange { Min = min, Max = max };
                int result = LevelZeroInterop.SetFrequencyRange(handle, ref range);
                if (result != 0)
                    throw new Exception("Failed to set frequency range.");
            }
        }

        public void SetFrequencyRange(int min, int max)
        {
            SetFrequencyRange((double)min, max);
        }
    }
}
