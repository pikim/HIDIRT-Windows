using System;
using System.Runtime.InteropServices;

namespace HIDIRT
{
    public class NativeW32Time
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemTime(out SYSTEMTIME lpSystemTime);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        static extern bool FileTimeToSystemTime(ref System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime,
            out SYSTEMTIME lpSystemTime);
        
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        static extern bool SystemTimeToFileTime(ref SYSTEMTIME lpSystemTime,
            out System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            [MarshalAs(UnmanagedType.U2)]
            public short wYear;
            [MarshalAs(UnmanagedType.U2)]
            public short wMonth;
            [MarshalAs(UnmanagedType.U2)]
            public short wDayOfWeek;
            [MarshalAs(UnmanagedType.U2)]
            public short wDay;
            [MarshalAs(UnmanagedType.U2)]
            public short wHour;
            [MarshalAs(UnmanagedType.U2)]
            public short wMinute;
            [MarshalAs(UnmanagedType.U2)]
            public short wSecond;
            [MarshalAs(UnmanagedType.U2)]
            public short wMillisecond;

            public void FromDateTime(DateTime dt)
            {
                dt = dt.ToUniversalTime();
                wYear = (short)dt.Year;
                wMonth = (short)dt.Month;
                wDayOfWeek = (short)dt.DayOfWeek;
                wDay = (short)dt.Day;
                wHour = (short)dt.Hour;
                wMinute = (short)dt.Minute;
                wSecond = (short)dt.Second;
                wMillisecond = (short)dt.Millisecond;
            }

            public DateTime ToDateTime()
            {
                return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond,
                                    wMillisecond, DateTimeKind.Utc);
            }

            public override string ToString()
            {
                return String.Format("{0},{1},{2},{3},{4},{5},{6}",
                    wYear, wMonth, wDay, wHour, wMinute, wSecond, wMillisecond);
            }

//            public void FromString()
//            {
//
//            }
        }

        public static DateTime GetSystemTime()
        {
            SYSTEMTIME time = new SYSTEMTIME();
            GetSystemTime(out time);
            return time.ToDateTime();
        }

        public static Boolean SetSystemTime(DateTime SystemTime)
        {
            SYSTEMTIME time = new SYSTEMTIME();
            time.FromDateTime(SystemTime);
            return SetSystemTime(ref time);
        }
    }
    
  [StructLayout(LayoutKind.Sequential, Pack=2)]
  public struct SystemTime
  {
    public ushort Year;
    public ushort Month;
    public ushort DayOfWeek;
    public ushort Day;
    public ushort Hour;
    public ushort Minute;
    public ushort Second;
    public ushort Milliseconds;
    
    public SystemTime(DateTime dt)
    {
      dt = dt.ToUniversalTime();
      Year = Convert.ToUInt16(dt.Year);
      Month = Convert.ToUInt16(dt.Month);
      DayOfWeek = Convert.ToUInt16(dt.DayOfWeek);
      Day = Convert.ToUInt16(dt.Day);
      Hour = Convert.ToUInt16(dt.Hour);
      Minute = Convert.ToUInt16(dt.Minute);
      Second = Convert.ToUInt16(dt.Second);
      Milliseconds = Convert.ToUInt16(dt.Millisecond);
    }
    
    public SystemTime(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0, ushort millisecond = 0)
    {
      Year = year;
      Month = month;
      Day = day;
      Hour = hour;
      Minute = minute;
      Second = second;
      Milliseconds = millisecond;
      DayOfWeek = 0;
    }
    
    public static implicit operator DateTime(SystemTime st)
    {
      if (st.Year == 0 || st == MinValue)
        return DateTime.MinValue;
      if (st == MaxValue)
        return DateTime.MaxValue;
      return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second, st.Milliseconds, DateTimeKind.Local);
    }
    
    public static bool operator ==(SystemTime s1, SystemTime s2)
    {
      return (s1.Year == s2.Year && s1.Month == s2.Month && s1.Day == s2.Day && s1.Hour == s2.Hour && s1.Minute == s2.Minute && s1.Second == s2.Second && s1.Milliseconds == s2.Milliseconds);
    }
    
    public static bool operator !=(SystemTime s1, SystemTime s2)
    {
      return !(s1 == s2);
    }
    
    public static readonly SystemTime MinValue, MaxValue;
    
    static SystemTime()
    {
      MinValue = new SystemTime(1601, 1, 1);
      MaxValue = new SystemTime(30827, 12, 31, 23, 59, 59, 999);
    }
    
    public override bool Equals(object obj)
    {
      if (obj is SystemTime)
        return ((SystemTime)obj) == this;
      return base.Equals(obj);
    }
    
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}
