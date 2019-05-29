using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogFilter
{
    public class LogClass
    {
        private IList<string> lines;
        private IList<string> filteredLines;
        public void AddLog(string log)
        {
            lines.Add(log);
            filteredLines.Add(log);
        }

        public IEnumerable<string> FilteredLines
        {
            get
            {
                return filteredLines;
            }

        }

        public void FilterForLogNotContains(string filter)
        {
            filteredLines = filteredLines.Where(e => !e.Contains(filter)).ToList();
        }

        public LogClass()
        {
            lines = new List<string>();
            filteredLines = new List<string>();
        }
    }
}
