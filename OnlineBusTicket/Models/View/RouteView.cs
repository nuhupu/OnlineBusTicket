﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBusTicket.Models.View
{
    public class RouteView
    {
        public Route route { set; get; }        
        public Bus bus { set; get; }
        public Counter counter { get; set; }
        public BlockTime block { get; set; }
        public BusDetail busDetail { get; set; }
    }
}