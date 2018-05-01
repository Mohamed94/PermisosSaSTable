using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace ClienteTablaCoches.Models
{
    public class ModeloCoches
    {
        public String GetToken(String marca)
        {
            String url = "http://localhost:63404/api/gettoken/" + marca;
            WebClient cliente = new WebClient();
            cliente.Headers["content-type"] = "application/xml";
            String datosxml = cliente.DownloadString(url);
            XDocument docxml = XDocument.Parse(datosxml);
            XElement elem = (XElement)docxml.FirstNode;
            String key = elem.Value;
            return key;
        }
        public CloudTable GetTabla(String marca)
        {
            String token = GetToken(marca);
            String uri = "https://storagetajamarmo.table.core.windows.net/";
            Uri tablauri = new Uri(uri);
            StorageCredentials credenciales =
                new StorageCredentials(token);
            CloudTableClient cliente = new CloudTableClient(tablauri, credenciales);
            CloudTable tabla = cliente.GetTableReference("TablaCoches");
            return tabla;
        }
        public List<Coches> BuscarMarca(String marca)
        {

            CloudTable tabla = GetTabla(marca);
            TableQuery<Coches> consulta = new TableQuery<Coches>();

            var coches = tabla.ExecuteQuery(consulta);
            if (coches.Count() == 0)
            {
                return null;
            }
            else
            {
                return coches.ToList();
            }
        }
        public void EliminarCoche(String id, String marca)
        {

            CloudTable tabla = GetTabla(marca);
            TableQuery<Coches> query = new TableQuery<Coches>()
                   .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id));

            foreach (var item in tabla.ExecuteQuery(query))
            {
                var oper = TableOperation.Delete(item);
                tabla.Execute(oper);
            }
        }
        //public void InsertarCoche(String marca, String idcoche, String modelo, String tipo, String coste)
        //{

        //    CloudTable tabla = GetTabla(marca);
        //    Coches cochenuevo = new Coches()
        //    {
        //        PartitionKey=idcoche,
        //        RowKey=marca,
        //        Modelo=modelo,
        //        Tipo=tipo,
        //        Coste=coste

        //    };
        //    var oper = TableOperation.Insert(cochenuevo);
        //    tabla.Execute(oper);
        //}

    }
}