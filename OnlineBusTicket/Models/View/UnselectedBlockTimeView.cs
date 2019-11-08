using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBusTicket.Models.View
{
    public class UnselectedBlockTimeView
    {
        public BlockTime block { set; get; }
        public BusSchedule schedule { get; set; }
    }
}