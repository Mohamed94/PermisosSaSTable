using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ApiTablaCoches.Models
{
    public class ModeloToken
    {
        private CloudTable GetTablaCoches()
        {
            String claves = CloudConfigurationManager.GetSetting("cuentastorage");
            CloudStorageAccount cuenta = CloudStorageAccount.Parse(claves);
            CloudTableClient cliente = cuenta.CreateCloudTableClient();
            CloudTable tabla = cliente.GetTableReference("TablaCoches");
            return tabla;
        }
        public String GetSeguridadSaS(String marca)
        {
            CloudTable tabla = GetTablaCoches();
            SharedAccessTablePolicy permisos = new SharedAccessTablePolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
                Permissions = SharedAccessTablePermissions.Query|
                 SharedAccessTablePermissions.Delete
            };
            string token = tabla.GetSharedAccessSignature
            (
                permisos,
                null,
                marca,
                null,
                marca,
                null
            );
            return token;
        }
    }
}