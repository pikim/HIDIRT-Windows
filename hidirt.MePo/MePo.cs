using System;
using System.Threading;

using TvControl;
using TvLibrary.Log;
using TvLibrary.Interfaces;
using TvEngine.PowerScheduler.Interfaces;
using HIDIRT;

namespace HIDIRT.MePo
{
  /// <summary>
  /// The HIDIRT plugin itself that's running in the background.
  /// </summary>
   public class hidirtMePo
   {
      #region Variables

      /// <summary>
      /// HIDIRT single instance
      /// </summary>
      private static hidirtMePo _hidirtMePo;

      /// <summary>
      /// mutex lock object to ensure only one instance of the HIDIRT object
      /// is created.
      /// </summary>
      private static readonly object _mutex = new object();

      /// <summary>
      /// Thread to connect to PowerScheduler
      /// </summary>
      private Thread _psDelayedConnectThread;

      /// <summary>
      /// Thread to poll PowerScheduler WakeupTimer
      /// </summary>
      private Thread _psPollWakeupTimer;

      #endregion

      public hidirtMePo()
      {
      }

      public static hidirtMePo Instance
      {
         get
         {
            if (_hidirtMePo == null)
            {
               lock (_mutex)
               {
                  if (_hidirtMePo == null)
                  {
                     _hidirtMePo = new hidirtMePo();
                  }
               }
            }
            return _hidirtMePo;
         }
      }

      /// <summary>
      /// Start the HIDIRT plugin
      /// </summary>
      /// <param name="controller">TVController from the tvservice</param>
      public void Start(IController controller)
      {
         Log.Debug("HIDIRT: Starting plugin.");

         this._psDelayedConnectThread = new Thread(DelayedConnectToPS);
         this._psDelayedConnectThread.Name = "DelayedConnectToPS";
         this._psDelayedConnectThread.Start();

      }

      /// <summary>
      /// Connect to PowerScheduler after some delay as it starts later
      /// </summary>
      private void DelayedConnectToPS()
      {
         Thread.Sleep(4000);

         if (GlobalServiceProvider.Instance.IsRegistered<IPowerScheduler>())
         {
            GlobalServiceProvider.Instance.Get<IPowerScheduler>().OnPowerSchedulerEvent +=
            new PowerSchedulerEventHandler(Handle_OnPowerSchedulerEvent);
            Log.Debug("HIDIRT: Registered PS-EventHandler.");
         }
      }

      private void Handle_OnPowerSchedulerEvent(PowerSchedulerEventArgs args)
      {
         switch (args.EventType)
         {
            case PowerSchedulerEventType.Elapsed:
               Log.Debug("HIDIRT: PS-EventHandler Elapsed.");

               _psPollWakeupTimer = new Thread(PollWakeupTimer);
               _psPollWakeupTimer.Name = "PollWakeupTimer";
               _psPollWakeupTimer.Start();
               break;
            default:
               break;
         }
      }

      private void PollWakeupTimer()
      {
         Boolean success = false;
         Thread.Sleep(200);

         DateTime nextWakeupTime = TvEngine.PowerScheduler.PowerScheduler.Instance.GetTimeToWakeup();
         Log.Info("HIDIRT: Next PS WakeupTime {0}.", nextWakeupTime.ToString());

         DateTime? readTime = HIDIRT.hidInterface.Instance.ReadWakeupTime();
         Log.Info("HIDIRT: Current WakeupTime {0}.", readTime.ToString());

         if (readTime != null)
         {
            DateTime currentWakeupTime = readTime ?? hidInterface.defTime;

            if (nextWakeupTime != currentWakeupTime)
            {
               success = HIDIRT.hidInterface.Instance.WriteWakeupTime(nextWakeupTime);
            }

            if (success)
            {
               Log.Info("HIDIRT: Changed WakeupTime {0}.", HIDIRT.hidInterface.Instance.ReadWakeupTime().ToString());
            }
         }
         else
         {
            Log.Info("HIDIRT: No hardware detected.");
         }
      }
   }
}
