using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using System.IO;

namespace WebApiAuthors.Business.Services.Core
{
    public class FileService : IHostedService
    {
        private IHostingEnvironment Environment;
        private readonly string fileName = "file.txt";
        private Timer timer;
        public FileService(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            WriteFile("Proceso iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            WriteFile("Proceso finalizado");
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            WriteFile("Proceso en ejecución"+DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
        private void WriteFile(string message)
        {
            var path = $@"D:\Temp\AuthorApi\{fileName}";
            using(StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
