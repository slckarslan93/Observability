using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    public class ServiceHelper
    {
        public async Task Work1()
        {
            using (var activty = ActivitySourceProvider.Source.StartActivity())
            {

                var serviceOne = new ServiceOne();

                Console.WriteLine($"google response lenght:{await serviceOne.MakeRequestToGoogle()}");

                Console.WriteLine("Work1 tamamlandı.");
            }

        }
    }
}
