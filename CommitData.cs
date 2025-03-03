using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitTracker
{
    public class CommitData
    {
        public string UserName { get; set; }
        public int CommitCount { get; set; }
        public DateTime CommitDate { get; set; }
        public string Project { get; set; }
    }
}
