using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPortal.Common.Utils;
using TvLibrary.Interfaces;
using SetupTv;
using TvLibrary.Log;
using TvEngine.Interfaces;
using TvControl;
using TvEngine.Events;
using TvLibrary;
using TvEngine;
using DSControl_Utils;
using TvDatabase;


namespace TvEngine
{
    public class DSControl : ITvServerPlugin
    {

        #region Members
        private static string _tooldirectory = "c:\\plugins\\";
        #endregion


        #region properties

        /// <summary>
        /// returns the name of the plugin
        /// </summary>
        public string Name { get { return "DirectShow Video Control"; } }

        /// <summary>
        /// returns the version of the plugin
        /// </summary>
        public string Version { get { return "0.0.1"; } }

        /// <summary>
        /// returns the author of the plugin
        /// </summary>
        public string Author { get { return "Mr Mojo"; } }

        /// <summary>
        /// returns if the plugin should only run on the master server
        /// or also on slave servers
        /// </summary>
        public bool MasterOnly { get; }


        internal static String ToolDirectory
        {
            get { return _tooldirectory; }
            set { _tooldirectory = value; }
        }


        #endregion

        #region  methods
        /// <summary>
        /// Starts the plugin
        /// </summary>
        public void Start(IController controller)

        {
            Log.Debug("DScontrol: Plugin Starting.....");
            LoadSettings();
            ITvServerEvent events = GlobalServiceProvider.Instance.Get<ITvServerEvent>();
            events.OnTvServerEvent += new TvServerEventHandler(events_OnTvServerEvent);
            Log.Debug("DScontrol: Plugin Started");

        }

        /// <summary>
        /// Stops the plugin
        /// </summary>
        public void Stop()

        {
            Log.Debug("DScontrol: Plugin Stopping.....");
            ITvServerEvent events = GlobalServiceProvider.Instance.Get<ITvServerEvent>();
            events.OnTvServerEvent -= new TvServerEventHandler(events_OnTvServerEvent);
            Log.Debug("DScontrol: Plugin Stopped");
        }
        

        /// <summary>
        /// Handles the OnTvServerEvent event fired by the server.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> the event data.</param>
        void events_OnTvServerEvent(object sender, EventArgs eventArgs)
        {
            DSControl_Utils.Helper _WCC = new DSControl_Utils.Helper();
            TvServerEventArgs tvEvent = (TvServerEventArgs)eventArgs;
            switch (tvEvent.EventType)
            {
                ///StartZapChannel is called just before the server is going to change channels
                case TvServerEventType.StartZapChannel:
                    break;
                ///EndZapChannel is called after the server changed channels
                case TvServerEventType.EndZapChannel:
                    break;
                ///StartRecording is called just before the server is going to start recording
                case TvServerEventType.StartRecording:
                    break;
                ///RecordingStarted is called when the recording is started
                case TvServerEventType.RecordingStarted:
                    break;
                ///RecordingEnded is called when the recording has been stopped
                case TvServerEventType.RecordingEnded:
                    break;
                ////Timeshift started
                case TvServerEventType.StartTimeShifting:
                    Log.Debug("DScontrol: Plugin is setting up video controls........");
                    _WCC.RunWebCameraConfig(DSControl.ToolDirectory);
                    Log.Debug("DScontrol: Plugin setup video controls done!");
                    break;
                    
            }

        }


        /// <summary>
        /// returns the setup sections for display in SetupTv
        /// </summary>
        public SectionSettings Setup
        { get
            { return new SetupTv.Sections.DSVideoControl_Setup(); }            
        }

        internal static void LoadSettings()
        {
            try
            {
                TvBusinessLayer layer = new TvBusinessLayer();
                _tooldirectory = layer.GetSetting("DSControl_ToolDirectory").Value;
                
            }
            catch (Exception ex)
            {
                

                Log.Error("DSControl - LoadSettings(): {0}", ex.Message);
            }
        }

        internal static void SaveSettings()
        {
            try
            {
                TvBusinessLayer layer = new TvBusinessLayer();

                Setting setting = layer.GetSetting("DSControl_ToolDirectory");
                setting.Value = _tooldirectory;
                setting.Persist();

              
            }
            catch (Exception ex)
            {
                Log.Error("DSControl - SaveSettings(): {0}", ex.Message);
            }
        }

        #endregion


    }
}
    

