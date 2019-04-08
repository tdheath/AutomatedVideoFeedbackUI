using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireframe_GUI
{
    public class TimeUpdateStack
    {
        private static TimeUpdateStack _instance = null;
        private Stack<int> rowid;
        private Stack<string> timeSeg;

        private TimeUpdateStack()
        {
            rowid = new Stack<int>();
            timeSeg = new Stack<string>();
        }

        public static TimeUpdateStack Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new TimeUpdateStack();
                }
                return _instance;
            }
        }

        public void PushUpdate(int row, string start, string end)
        {
            var time = PadString(start) + '-' + PadString(end);
            rowid.Push(row);
            timeSeg.Push(time);
        }

        public bool IsStackEmpty()
        {
            return rowid.Count == 0;
        }

        public int PopUpdate(out string seg)
        {
            seg = timeSeg.Pop();
            return rowid.Pop();
        }

        private string PadString(string str)
        {
            var newstring = string.Empty;

            string[] split = str.Split('.');
            newstring = split[0].PadLeft(3, '0') + "." + split[1].PadRight(2, '0');

            return newstring;
        }
    }
}
