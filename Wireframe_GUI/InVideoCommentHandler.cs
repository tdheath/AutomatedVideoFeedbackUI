using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireframe_GUI
{
    public class InVideoCommentStruct
    {
        public string start = string.Empty;
        public string stop = string.Empty;
        public string comment = string.Empty;

        public double GetStartDouble()
        {
            return ConvertStringFormat(start);
        }

        public double GetStopDouble()
        {
            return ConvertStringFormat(stop);
        }

        private double ConvertStringFormat(string str)
        {
            double result = -1;
            if (!double.TryParse(str, out result))
            {
                //hh:mm:ss.ms
                var split = str.Split(':');
                var hourAsSec = int.Parse(split[1]) * 60 * 60;
                var minAsSec = int.Parse(split[2]) * 60;
                if (split[2].Contains('.'))
                {
                    var secs = double.Parse(split[2]);
                    result = secs + minAsSec + hourAsSec;
                }
                else
                {
                    var secs = int.Parse(split[2]);
                    result = secs + minAsSec + hourAsSec;
                }
            }

            return result;
        }
    }
    public class InVideoCommentHandler
    {
        private static InVideoCommentHandler _instance = null;
        private Dictionary<int, List<InVideoCommentStruct>> comments = null;
        private InVideoCommentHandler()
        {
            comments = new Dictionary<int, List<InVideoCommentStruct>>();
        }

        public static InVideoCommentHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InVideoCommentHandler();
                }
                return _instance;
            }
        }

        public void LoadComment(int row, string start, string end, string comment)
        {
            if (comments.ContainsKey(row))
            {
                comments[row].Add(new InVideoCommentStruct { start = start, stop = end, comment = comment });
                
            }
            else
            {
                var comlist = new List<InVideoCommentStruct>
                {
                    new InVideoCommentStruct { start = start, stop = end, comment = comment }
                };
                comments.Add(row, comlist);
            }
        }

        public bool TryGetComments(int row, out List<InVideoCommentStruct> commlist)
        {
            commlist = null;
            var hasComments = false;
            if (comments.ContainsKey(row))
            {
                hasComments = true;
                commlist = comments[row];
            }

           return hasComments;
        }
    }
}
