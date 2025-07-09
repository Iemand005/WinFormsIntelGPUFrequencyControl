using System.Runtime.InteropServices;

namespace LevelZero
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FrequencyRange
    {
        public double Min;
        public double Max;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FrequencyProperties
    {
        public uint stype;
        public IntPtr nextPointer;
        public int type;
        public bool onSubdevice;
        //public ulong subdeviceId;
        public bool canControl;
        //public bool isThrottleEventSupported;
        public double min;
        public double max;
    }

    public struct DriverHandle { public IntPtr Handle; }
    public struct DeviceHandle { public IntPtr Handle; }
    public struct FrequencyHandle { public IntPtr Handle; }

    internal class LevelZeroInterop
    {
        [DllImport("ze_loader.dll", EntryPoint = "zeInit")]
        public static extern int Init(int flags = 0);

        [DllImport("ze_loader.dll", EntryPoint = "zeDriverGet", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDriver(ref uint count, [In, Out, Optional] DriverHandle[]? driverHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zeDeviceGet", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDevice(DriverHandle driverHandle, ref uint count, [In, Out, Optional] DeviceHandle[]? deviceHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zesDeviceEnumFrequencyDomains", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EnumDeviceFrequencyDomains(DeviceHandle deviceHandle,  ref uint count, [In, Out] FrequencyHandle[] frequencyHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencyGetProperties", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFrequencyProperties(FrequencyHandle frequencyHandle, ref FrequencyProperties properties);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencyGetRange")]
        public static extern int GetFrequencyRange(FrequencyHandle frequencyHandle, ref FrequencyRange limits);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencySetRange")]
        public static extern int SetFrequencyRange(FrequencyHandle frequencyHandle, ref FrequencyRange limits);
    }
}
