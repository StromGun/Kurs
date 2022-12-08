using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty_Salon.Entities
{
    partial class Order
    {
        //public decimal Summa
        //{
        //    get => Services.Price;
        //}

        public string GetServices
        {
            get
            {
                return string.Join(",", OrderServices);
            }
        }
    }
}
