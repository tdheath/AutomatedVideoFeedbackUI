using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Wireframe_GUI
{
    static class VideoClipCreator
    {
        private static string ffmpeg = Environment.CurrentDirectory + "\\ffmpeg.exe";
        public static void CreateClip(string videopath, double start, double stop, string clippath)
        {
            if(!File.Exists(clippath))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ffmpeg,
                        Arguments = string.Format(" -i {0} -ss {1} -to {2} -c copy {3} -pix_fmt yuv420p", videopath, start.ToString(), stop.ToString(), clippath),
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                //               var args = string.Format(" -i {0} -ss {1} -to {2} -c copy {3} -pix_fmt yuv420p", videopath, start.ToString(), stop.ToString(), clippath);
                //               Process.Start(ffmpeg, args);
                proc.Start();


                using (StreamWriter commfile = new StreamWriter(Environment.CurrentDirectory + "\\log.txt"))
                {
                    commfile.WriteLine(proc.StandardOutput.ReadToEnd());
                }
            }
        }

        public static string AddTextToClip(string videopath, string clippath, string name, double start, double stop, string comment)
        {
            string temp = clippath + name + "temp_" + start.ToString() +".wmv";
            //CreateClip(videopath, start, stop, temp);
            var args = string.Format("-i {0} -ss {1} -to {2} - vf drawtext = \"fontfile=C\\:/Windows/Fonts/arial.ttf:fontsize=20: fontcolor=red:x=10:y=10:text='{3}'\"  {4}", videopath, start.ToString(), stop.ToString(),comment, temp);
            System.Diagnostics.Process.Start(ffmpeg, args);

            return temp;
        }

        public static void CreateClipWithText(string videopath, string export, double start, double stop, List<InVideoCommentStruct> commlist)
        {
            if(!File.Exists(export))
            {
                var temp = export.Replace(".wmv", "_temp.wmv");
                CreateClip(videopath, start, stop, temp);

                string args = string.Format("-i {0} -vf \"drawbox=y=ih/PHI:color=black@0.4:width=iw:height=48:t=fill", temp);
                foreach (var comm in commlist)
                {
                    double textstart = comm.GetStartDouble() - start;
                    double textstop = comm.GetStopDouble() - start;
                    args += string.Format(", drawtext=fontfile=/Windows/Fonts/arial.ttf:text='{0}':fontcolor=white:fontsize=24:x=(w-tw)/2:y=(h/PHI)+th:'enable=between(t,{1},{2})'", comm.comment, textstart.ToString(), textstop.ToString());
                }
                args += string.Format("\" {0}", export);

                bool filefree = false;
                while (!filefree)
                {
                    try
                    {
                        File.ReadAllBytes(temp);
                        filefree = true;
                    }
                    catch (IOException)
                    { }
                }


                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ffmpeg,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                //System.Diagnostics.Process.Start(ffmpeg, args);
                proc.Start();

                using (StreamWriter commfile = new StreamWriter(Environment.CurrentDirectory + "\\log_incom.txt"))
                {
                    commfile.WriteLine(proc.StandardOutput.ReadToEnd());
                }

                File.Delete(temp);
            }
        }
    }
}
