using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Practical.Topself
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.Service<DemoService>(service =>
                {
                    service.ConstructUsing(s => new DemoService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                c.RunAsLocalSystem();
                c.StartAutomatically();
                c.SetDescription("My Simple Service");
                c.SetDisplayName("My Simple Service");
                c.SetServiceName("My Simple Service");
                c.EnableServiceRecovery(x =>
                {
                    //First failure
                    x.RestartService(1);
                    //Second failure
                    x.RestartService(1);
                    //Subsequent failures
                    x.RestartService(1);
                });

                //Service Dependencies
                //https://topshelf.readthedocs.io/en/latest/configuration/config_api.html#service-dependencies
            });
        }
    }
}
