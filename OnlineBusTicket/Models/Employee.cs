//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBusTicket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public string eId { get; set; }
        public string eUsername { get; set; }
        public string ePassword { get; set; }
        public string eName { get; set; }
        public System.DateTime eBirthday { get; set; }
        public string eAddress { get; set; }
        public string eEmail { get; set; }
        public string ePhone { get; set; }
        public int eCounterId { get; set; }
        public byte eRole { get; set; }
    
        public virtual Counter Counter { get; set; }
    }
}
