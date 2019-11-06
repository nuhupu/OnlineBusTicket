using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static OnlineBusTicket.Models.BlockTime;

namespace OnlineBusTicket.Models
{
    public class BlockTimeData
    {
        SRCTravelAgenciesEntities context ;
        public BlockTimeData()
        {
            context = new SRCTravelAgenciesEntities();
        }

        public List<BlockTime> GetAllBlockTimes() { return context.BlockTimes.ToList(); }
    }
}