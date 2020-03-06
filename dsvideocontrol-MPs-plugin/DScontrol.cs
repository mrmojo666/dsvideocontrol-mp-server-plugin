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

namespace DSControl_Plugin
{
    public class Dscontrol : ITvServerPlugin
    {

        #region properties

        /// <summary>
        /// returns the name of the plugin
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// returns the version of the plugin
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// returns the author of the plugin
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// returns if the plugin should only run on the master server
        /// or also on slave servers
        /// </summary>
        public bool MasterOnly { get; }

        #endregion

        #region  methods

        /// <summary>
        /// Starts the plugin
        /// </summary>
        public void Start(IController controller)

        {
            ITvServerEvent events = GlobalServiceProvider.Instance.Get<ITvServerEvent>();
            events.OnTvServerEvent += new TvServerEventHandler(events_OnTvServerEvent);

        }

        /// <summary>
        /// Stops the plugin
        /// </summary>
        public void Stop()

        {
            ITvServerEvent events = GlobalServiceProvider.Instance.Get<ITvServerEvent>();
            events.OnTvServerEvent -= new TvServerEventHandler(events_OnTvServerEvent);
        }


        /// <summary>
        /// Handles the OnTvServerEvent event fired by the server.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> the event data.</param>
        public void events_OnTvServerEvent(object sender, EventArgs eventArgs)
        {
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
                case TvServerEventType.EndTimeShifting:
                    {
                        bool result =  DSControl_Utils.Utils.           Utils.RunWebCameraConfig();
                        break;
                    }
            }

        }


            /// <summary>
            /// returns the setup sections for display in SetupTv
            /// </summary>
           public  SetupTv.SectionSettings Setup { get; }

        #endregion


    }
}
    

