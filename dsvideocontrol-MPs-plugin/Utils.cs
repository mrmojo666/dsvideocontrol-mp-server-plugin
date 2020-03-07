using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvLibrary.Log;

namespace DSControl_Utils
{
    public class Helper
    {

        public void RunWebCameraConfig(string tooldirectory)

        {
            Log.Debug("DScontrol: started the RunWebCameraConfig");
            try
            {
                //Process process = new Process();
                //Log.Debug("DScontrol: New process id {0}", process.Id);
                //process.StartInfo = new ProcessStartInfo
                ProcessStartInfo StartInfo = new ProcessStartInfo
                {
                    FileName =  tooldirectory + "webcameraconfig.exe",
                    // Arguments = $"{}",
                    WorkingDirectory = tooldirectory,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                    
            };
                Log.Debug("DScontrol: New process StartInfo {0} {1} configured", StartInfo.WorkingDirectory, StartInfo.FileName);

                try
                {
                   Process process = Process.Start(StartInfo);
                    
                    Log.Debug("DScontrol: Process started");


                    //while (process.StandardOutput.EndOfStream)
                    //{
                    //    //var line = process.StandardOutput.ReadLine();
                    //    Log.Debug("DScontrol: {0}", process.StandardOutput.ReadToEnd());
                    //}
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    Log.Debug("DScontrol: {0}", output);
                    Log.Info("DScontrol: WebCamera config applied");
                }
                catch (Exception e)
                {

                    Log.Error("DScontrol: Process NOT started error:{0}", e.Message);
                }
                
                
            }
            catch (Exception e)
            {
                
                Log.Error("DScontrol: WebCamera process not created error:{0}", e.Message);
            }

            
        
        
        }



    }
}
