using System;
using TvControl;
using TvEngine;

namespace HIDIRT.MePo
{
    /// <summary>
    /// base class for tv-server plugins
    /// </summary>
    public class hidirtPlugin : ITvServerPlugin
    {
        #region ITvServerPlugin implementation

        /// <summary>
        /// returns the name of the plugin
        /// </summary>
        public string Name
        {
            get { return "HIDIRT-plugin"; }
        }

        /// <summary>
        /// returns the version of the plugin
        /// </summary>
        public string Version
        {
            get { return "0.2"; }
        }

        /// <summary>
        /// returns the author of the plugin
        /// </summary>
        public string Author
        {
            get { return "myscha"; }
        }

        /// <summary>
        /// returns if the plugin should only run on the master server or also on slave servers
        /// </summary>
        public bool MasterOnly
        {
            get { return true; }
        }

        /// <summary>
        /// starts the plugin
        /// </summary>
        public void Start(IController controller)
        {
            hidirtMePo.Instance.Start(controller);
        }

        /// <summary>
        /// stops the plugin
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// returns the setup sections for display in SetupTv
        /// </summary>
        public SetupTv.SectionSettings Setup
        {
            get { return new hidirtSetupControl(); }
        }

        #endregion
    }
}
