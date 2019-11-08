using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicket.Models
{
    //Contrain class
    public class tbBlockTimeMetadata
    {
        [Required]
        public int StartPlace;
        [Required]
        public int Destination;
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]
        public DateTime StartTime;
        [Required]
        [Display(Name ="Price")]
        public float btPrice;
    }

    

    
}