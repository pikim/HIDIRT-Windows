
///<summary>
///
/// Class:
/// TextWriterTraceListenerWithTime
///
/// Purpose:
/// Adds the time to the TextWriterTraceListener class.
///
/// Originally taken from:
/// https://github.com/tig/JPG-Corruptor/blob/master/JPGCorrupt/TextWriterTraceListenerWithTime.cs
///
/// Extended by:
/// Michael Kipp
///
///</summary>

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

//namespace tbd
   /// <summary>
   /// Summary description for TextWriterTraceListenerWithTime.
   /// </summary>
   ///

   public class TextWriterTraceListenerWithTime : TextWriterTraceListener
   {
      private static readonly TextWriterTraceListenerWithTime instance = new TextWriterTraceListenerWithTime("hidirt.log");

      public static TextWriterTraceListenerWithTime GetInstance
      {
         get { return instance; }
      }

      Int32 traceEventTypeLength;
      private Int32 TraceEventTypeLength()
      {
         Int32 length = 0;
         foreach (var name in TraceEventType.GetNames(typeof(TraceEventType)))
         {
            if (name.Length > length)
            {
               length = name.Length;
            }
         }
         return length;
      }

      public TextWriterTraceListenerWithTime()
      : base()
      {
      }

      public TextWriterTraceListenerWithTime(Stream stream)
      : base(stream)
      {
      }

      public TextWriterTraceListenerWithTime(string path)
      : base(path)
      {
         traceEventTypeLength = TraceEventTypeLength();
      }

      public TextWriterTraceListenerWithTime(TextWriter writer)
      : base(writer)
      {
      }

      public TextWriterTraceListenerWithTime(Stream stream, string name)
      : base(stream, name)
      {
      }

      public TextWriterTraceListenerWithTime(string path, string name)
      : base(path, name)
      {
      }

      public TextWriterTraceListenerWithTime(TextWriter writer, string name)
      : base(writer, name)
      {
      }

      public override void Write(string message)
      {
         base.Write(DateTime.Now.ToString());
         base.Write(" ");
         base.Write(message);
      }

      public override void WriteLine(string message)
      {
         base.Write(DateTime.Now.ToString());
         base.Write(" ");
         base.WriteLine(message);
      }

      public override void TraceData(TraceEventCache eventCache, String source, TraceEventType eventType, int id, object data)
      {
         if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            return;
         WriteLine("["+eventType.ToString().PadRight(traceEventTypeLength)+"] "+source+": "+data.ToString());
      }

      public override void TraceData(TraceEventCache eventCache, String source, TraceEventType eventType, int id, params object[] data)
      {
         if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, data))
            return;

         StringBuilder sb = new StringBuilder();
         if (data != null)
         {
            for (Int32 i=0; i<data.Length; i++)
            {
               if (i != 0)
               {
                  sb.Append(", ");
               }
               if (data[i] != null)
               {
                  sb.Append(data[i].ToString());
               }
            }
         }

         WriteLine("["+eventType.ToString().PadRight(traceEventTypeLength)+"] "+source+": "+sb.ToString());
      }

      public override void TraceEvent(TraceEventCache eventCache, String source, TraceEventType eventType, int id)
      {
         TraceEvent(eventCache, source, eventType, id, String.Empty);
      }

      public override void TraceEvent(TraceEventCache eventCache, String source, TraceEventType eventType, int id, string message)
      {
         if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
            return;
         WriteLine("["+eventType.ToString().PadRight(traceEventTypeLength)+"] "+source+": "+message);
      }

      public override void TraceEvent(TraceEventCache eventCache, String source, TraceEventType eventType, int id, string format, params object[] args)
      {
         if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, format, args, null, null))
            return;

         if (args != null)
            WriteLine("["+eventType.ToString().PadRight(traceEventTypeLength)+"] "+source+": "+String.Format(format, args));
         else
            WriteLine(format);
      }
   }
