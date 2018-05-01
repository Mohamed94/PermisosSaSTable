using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MigracionXMLTableStorage.Models
{
    public class ModeloHome
    {
        public void CrearTabla()
        {
            String claves = CloudConfigurationManager.GetSetting("cuentastorage");
            CloudStorageAccount cuenta = CloudStorageAccount.Parse(claves);
            CloudTableClient cliente = cuenta.CreateCloudTableClient();
            CloudTable tabla = cliente.GetTableReference("TablaCoches");
            tabla.CreateIfNotExists();
            Stream contenidoxml =
                this.GetType().Assembly.GetManifestResourceStream("MigracionXMLTableStorage.coches.xml");
            XDocument xdoc = XDocument.Load(contenidoxml);
            var consulta = from datos in xdoc.Root.Descendants("coche")
                           select new Coches
                           {
                               IdCoche = datos.Element("idcoche").Value,
                               Marcar = datos.Element("marca").Value,
                               Modelo = datos.Element("modelo").Value,
                               Tipo = datos.Element("tipo").Value,
                               Coste = datos.Element("coste").Value
                           };
            foreach (var alumno in consulta)
            {
                TableOperation insertOperation = TableOperation.Insert(alumno);
                tabla.Execute(insertOperation);
            }
        }
    }
}