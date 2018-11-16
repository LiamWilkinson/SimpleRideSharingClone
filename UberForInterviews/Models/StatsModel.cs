using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberForInterviews.Models
{
    public class StatsModel
    {
        public StatsModel(string status, int count)
        {
            this.status = status;
            this.count = count;
        }

        public int count { get; }
        public string status { get; }
    }
}