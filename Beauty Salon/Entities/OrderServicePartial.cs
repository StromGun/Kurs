using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty_Salon.Entities
{
    partial class OrderService
    {

        public string GetServiceName
        {
            get => string.Join(",", Service.Name);
        }
    }
}
