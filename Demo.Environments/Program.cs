using Qualita.Util.Environments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Environments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < EnvironmentSettings.Count; i++)
            {
                Console.WriteLine("Environment Ativo: {0}", EnvironmentSettings.UseEnvironKey);

                foreach (var item in EnvironmentSettings.Settings("Teste"))
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }

            

            Console.Read();
        }
    }
}
