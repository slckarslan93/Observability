using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    public class ServiceTwo
    {
        public async Task<int> WriteToFile(string text)
        {
            using (var activty = ActivitySourceProvider.Source.StartActivity())
            {
                await File.WriteAllTextAsync("myFile.txt", text);

                return (await File.ReadAllTextAsync("myFile.txt")).Length;
            }


        }
    }
}
