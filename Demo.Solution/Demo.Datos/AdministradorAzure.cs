using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace Demo.Datos
{
    public class AdministradorAzure
    {
        private CloudQueueClient clientQueueAzure;

        public AdministradorAzure()
        {
            CloudStorageAccount cuentaAlmacenamientoAzure = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["DemoStorage"].ConnectionString);
            clientQueueAzure = new CloudQueueClient(new Uri(cuentaAlmacenamientoAzure.QueueEndpoint.AbsoluteUri), cuentaAlmacenamientoAzure.Credentials);
        }

        public void AgregaMensajeCola(string mensaje)
        {
            var referenciaQueue = clientQueueAzure.GetQueueReference("demoqueue");
            referenciaQueue.AddMessage(new CloudQueueMessage(mensaje));
        }

        public string RecuperarMensajeCola()
        {
            var referenciaQueue = clientQueueAzure.GetQueueReference("demoqueue");
            var queueMessage = referenciaQueue.GetMessage();
            return queueMessage.AsString;

        }
    }
}
