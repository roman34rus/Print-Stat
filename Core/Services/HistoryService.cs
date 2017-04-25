using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class HistoryService : BaseService
    {
        public List<History> GetByPrinterId(int printerId)
        {
            return context.HistorySet.Where(x => x.PrinterId == printerId).ToList();
        }

        public List<History> GetBySupplyId(int supplyId)
        {
            return context.HistorySet.Where(x => x.SupplyId == supplyId).ToList();
        }
    }
}
