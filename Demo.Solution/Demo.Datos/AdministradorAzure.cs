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
    public class DemoLog : TableEntity
    {
        public string mensaje { get; set; }
        public DemoLog(string nombreTabla,string mensaje)
        {
            this.PartitionKey = nombreTabla;
            this.RowKey = Guid.NewGuid().ToString();
            this.mensaje = mensaje;
        }
    }
    public class AdministradorAzure
    {
        private CloudStorageAccount cuentaAlmacenamientoAzure;
        private CloudQueueClient clientQueueAzure;
        private CloudTableClient clienteTablaAzure;

        public AdministradorAzure()
        {
            cuentaAlmacenamientoAzure = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["DemoStorage"].ConnectionString);
            clientQueueAzure = new CloudQueueClient(new Uri(cuentaAlmacenamientoAzure.QueueEndpoint.AbsoluteUri), cuentaAlmacenamientoAzure.Credentials);
            clienteTablaAzure = new CloudTableClient(new Uri(cuentaAlmacenamientoAzure.TableEndpoint.AbsoluteUri),cuentaAlmacenamientoAzure.Credentials);
        }

        public void AgregarRegistroLog(string mensajeLog)
        {
            string nombreTabla = "DemoLog";
            DemoLog demoLog = new DemoLog(nombreTabla, mensajeLog);
            CloudTable tablaLog = clienteTablaAzure.GetTableReference(nombreTabla);

            TableOperation insertOperation = TableOperation.InsertOrMerge(demoLog);
            tablaLog.Execute(insertOperation);
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
