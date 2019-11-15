using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    
    public class tbRouteMetadata
    {
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime date;
    }

    public class tbEmployeeMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "ID")]
        public string eId;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
        [Display(Name = "Username")]
        public string eUsername;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 30 characters")]
        [Display(Name = "Password")]
        public string ePassword;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [Display(Name = "Fullname")]
        public string eName;

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime eBirthday;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 30 characters")]
        [Display(Name = "Address")]
        public string eAddress;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "Email")]
        public string eEmail;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, ErrorMessage = "Phone is a 10-digit number.")]
        [Display(Name = "Phone Number")]
        public string ePhone;

        [Range(1, 3, ErrorMessage = "Counter must be between 1 and 3")]
        [Display(Name = "Counter")]
        public int eCounterId;

        [Range(0, 2, ErrorMessage = "0: Deactive, 1: Admin, 2: Employee")]
        [Display(Name = "Role")]
        public byte eRole;
    }

    public class tbAccountMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int aId;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
        [Display(Name = "Username")]
        public string aUsername;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 30 characters")]
        [Display(Name = "Password")]
        public string aPassword;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [Display(Name = "Fullname")]
        public string aName;

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime aBirthday;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "Email")]
        public string aEmail;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, ErrorMessage = "Phone is a 10-digit number.")]
        [Display(Name = "Phone Number")]
        public string aPhone;
    }

    public class tbCustomerMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int cId;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [Display(Name = "Fullname")]
        public string cName;

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime cBirthday;


        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, ErrorMessage = "Phone is a 10-digit number.")]
        [Display(Name = "Phone Number")]
        public string cPhone;
    }

}