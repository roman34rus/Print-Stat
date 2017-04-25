using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EF
{
    public partial class SupplySlot
    {
        /// <summary>
        /// Возвращает Id установленного расходного материала или 0.
        /// </summary>
        public int GetSupplyId()
        {
            if (SupplyId == null)
                return 0;
            else
                return (int)SupplyId;
        }

        /// <summary>
        /// Возвращает название установленного расходного материала или "Не установлен".
        /// </summary>
        public string GetSupplyName()
        {
            if (SupplyId == null)
                return "Не установлен";
            else
                return Supply.GetFullName();
        }
    }
}
