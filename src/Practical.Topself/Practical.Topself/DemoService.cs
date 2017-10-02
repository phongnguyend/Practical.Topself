using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.Topself
{
    public class DemoService
    {
        private BackgroundWorker _worker;

        public DemoService()
        {
            _worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine(e.Cancelled);
            Console.WriteLine(e.Error);
            Console.WriteLine(e.Result);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string input = "";
            while (!_worker.CancellationPending)
            {
                input = Console.ReadLine();
                Console.WriteLine(input);
                Console.WriteLine(_worker.CancellationPending);

                if (input == "cancel")
                {
                    _worker.CancelAsync();
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("Service is starting.");
            _worker.RunWorkerAsync();
        }

        public void Stop()
        {
            _worker.CancelAsync();
            Console.WriteLine("Service was stopped.");
        }
    }
}
