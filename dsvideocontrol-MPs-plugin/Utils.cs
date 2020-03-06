using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSControl_Utils
{
    public class Utils
    {

        public bool RunWebCameraConfig()

        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "../Utils/webcameraconfig.exe",
                       // Arguments = $"{}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                //while (!process.StandardOutput.EndOfStream)
                //{
                //    var line = process.StandardOutput.ReadLine();
                //    Console.WriteLine(line);
                //}

                process.WaitForExit();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            
        
        
        }



    }
}
