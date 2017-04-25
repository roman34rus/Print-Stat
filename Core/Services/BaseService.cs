using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EF;

namespace Core.Services
{
    public class BaseService
    {
        internal Context context = new Context();

        // Обходное решение для устранения ошибки "Не удалось загрузить тип поставщика Entity Framework
        // "System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"".
        private void FixEntityFrameworkProviderLoadingError()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
