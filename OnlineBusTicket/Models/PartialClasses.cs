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
}