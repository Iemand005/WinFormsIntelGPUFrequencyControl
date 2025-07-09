using System.Runtime.InteropServices;

namespace LevelZero
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FrequencyRange
    {
        public double Min;
        public double Max;
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct FrequencyProperties
    //{
    //    public uint stype;
    //    public IntPtr nextPointer;
    //    public int type;
    //    public bool onSubdevice;
    //    //public ulong subdeviceId;
    //    public bool canControl;
    //    //public bool isThrottleEventSupported;
    //    public double min;
    //    public double max;
    //}

    public enum ze_structure_type_t : uint
    {
        ZE_STRUCTURE_TYPE_FREQ_PROPERTIES = 0x1001
    }

    public enum zes_freq_domain_t : int
    {
        ZES_FREQ_DOMAIN_GPU = 0,
        ZES_FREQ_DOMAIN_MEMORY = 1
    }

    public enum ze_bool_t : uint
    {
        ZE_BOOL_FALSE = 0,
        ZE_BOOL_TRUE = 1
    }

    [StructLayout(LayoutKind.Explicit, Size = 56)]
    public struct FrequencyProperties
    {
        [FieldOffset(0)] public ze_structure_type_t stype;
        [FieldOffset(4)] public IntPtr pNext;
        [FieldOffset(8)] public zes_freq_domain_t type;
        [FieldOffset(12)] public ze_bool_t onSubdevice;
        [FieldOffset(16)] public uint subdeviceId;
        [FieldOffset(20)] public ze_bool_t canControl;
        [FieldOffset(24)] public ze_bool_t isThrottleEventSupported;
        [FieldOffset(32)] public double min;
        [FieldOffset(40)] public double max;
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
