using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Models.View
{
    public class EmployeeView
    {
        public Employee employee { set; get; }
        public Counter counter { set; get; }
    }
}