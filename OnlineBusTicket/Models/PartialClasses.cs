using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBusTicket.Models
{
    [MetadataType(typeof(tbBlockTimeMetadata))]
    public partial class BlockTime{ }

    [MetadataType(typeof(tbRouteMetadata))]
    public partial class Route { }
    [MetadataType(typeof(tbEmployeeMetadata))]
    public partial class Employee { }

    [MetadataType(typeof(tbAccountMetadata))]
    public partial class Account { }

    [MetadataType(typeof(tbCustomerMetadata))]
    public partial class Customer { }
}