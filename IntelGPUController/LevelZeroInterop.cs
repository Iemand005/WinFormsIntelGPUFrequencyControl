using System.Runtime.InteropServices;

namespace LevelZero
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FrequencyRange
    {
        public double Min;
        public double Max;
    }

    public enum LevelZeroStructureType : uint
    {
        FrequencyProperties = 0x1001
    }

    public enum FrequencyDomain : int
    {
        GPU = 0,
        Memory = 1
    }

    public enum LevelZeroBool : uint
    {
        False = 0,
        True = 1
    }

    [StructLayout(LayoutKind.Explicit, Size = 56)]
    public struct FrequencyProperties
    {
        [FieldOffset(0)] public LevelZeroStructureType StructureType;
        [FieldOffset(4)] public IntPtr NextPtr;
        [FieldOffset(8)] public FrequencyDomain Type;
        [FieldOffset(12)] public LevelZeroBool OnSubdevice;
        [FieldOffset(16)] public uint SubdeviceId;
        [FieldOffset(20)] public LevelZeroBool CanControl;
        [FieldOffset(24)] public LevelZeroBool IsThrottleEventSupported;
        [FieldOffset(32)] public double Min;
        [FieldOffset(40)] public double Max;
    }

    public struct DriverHandle { public IntPtr Handle; }
    public struct DeviceHandle { public IntPtr Handle; }
    public struct FrequencyHandle { public IntPtr Handle; }

    internal class LevelZeroInterop
    {
        [DllImport("ze_lodader.dll", EntryPoint = "zeInit")]
        public static extern int Init(int flags = 0);

        [DllImport("ze_loader.dll", EntryPoint = "zeDriverGet", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDriver(ref uint count, [In, Out, Optional] DriverHandle[]? driverHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zeDeviceGet", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDevice(DriverHandle driverHandle, ref uint count, [In, Out, Optional] DeviceHandle[]? deviceHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zesDeviceEnumFrequencyDomains", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EnumDeviceFrequencyDomains(DeviceHandle deviceHandle,  ref uint count, [In, Out, Optional] FrequencyHandle[]? frequencyHandles);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencyGetProperties", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFrequencyProperties(FrequencyHandle frequencyHandle, ref FrequencyProperties properties);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencyGetRange")]
        public static extern int GetFrequencyRange(FrequencyHandle frequencyHandle, ref FrequencyRange limits);

        [DllImport("ze_loader.dll", EntryPoint = "zesFrequencySetRange")]
        public static extern int SetFrequencyRange(FrequencyHandle frequencyHandle, ref FrequencyRange limits);
    }
}
