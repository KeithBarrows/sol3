//using Microsoft.WindowsAPICodePack.Shell;
//using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
//using Sol3.Infrastructure.Pattern;
//using System;
//using System.Diagnostics;

//namespace Sol3.Infrastructure.Shell.Video
//{
//    public class VideoConverter : Singleton<VideoConverter>
//    {
//        public void Convert(string ffmpegPath, string inputVideoPath, string outputImagePath, double timeMilliseconds)
//        {
//            try
//            {
//                // -i input.flv -ss 00:00:14.435 -vframes 1 out.png

//                var timeStamp = $"{TimeSpan.FromMilliseconds(timeMilliseconds)}";
//                var argString = $"-i \"{inputVideoPath}\" -ss {timeStamp} -vframes 1 \"{outputImagePath}\"";

//                var process = new Process
//                {
//                    StartInfo = new ProcessStartInfo()
//                    {
//                        CreateNoWindow = true,
//                        FileName = ffmpegPath,          // or path to the ffmpeg
//                        WindowStyle = ProcessWindowStyle.Hidden,
//                        Arguments = argString           //"your arguments here"
//                    }
//                };

//                process.Start();
//                process.WaitForExit(10000); // wait for exit 10000 milliseconds
//                process.WaitForExit();
//            }
//            catch (Exception ex)
//            {
//                var msg = ex.Message;
//            }
//        }

//        public double GetVideoDurationInSeconds(string filePath) => GetVideoDurationInMilliseconds(filePath) / 1000;
//        public double GetVideoDurationInMilliseconds(string filePath)
//        {
//            long t1 = 3000;
//            var t2 = TimeSpan.FromTicks(t1);

//            try
//            {
//                var shell = ShellObject.FromParsingName(filePath);
//                IShellProperty prop = shell.Properties.System.Media.Duration;
//                t1 = (long)((ulong)prop.ValueAsObject);
//                t2 = TimeSpan.FromTicks(t1);
//                prop = null;
//                shell.Dispose();
//                shell = null;
//            }
//            catch
//            {
//            }
//            t2 = TimeSpan.FromTicks(t1);
//            return t2.TotalMilliseconds;
//        }
//    }
//}
