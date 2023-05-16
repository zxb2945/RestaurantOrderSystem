using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Services
{
    class MockOrderService : IOrderSevice
    {
        public void PlaceOrder(List<string> dishes)
        {
            //可以把菜单输出到txt，或者也可以输出到短信，数据库等等
            string orderFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Order.txt");
            System.IO.File.WriteAllLines(orderFileName, dishes.ToArray());
        }
    }
}
