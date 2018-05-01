using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigracionXMLTableStorage.Models
{
    public class Coches: TableEntity
    {
        //EL IDCOCHE SERA NUESTRO ROWKEY
        private String _IdCoche;
        public string IdCoche
        {
            get { return _IdCoche; }
            set
            {
                _IdCoche = value;
                RowKey = value;
            }
        }

        //LA MARCA SERA NUESTRO PARTITION KEY
        private String _Marca;
        public string Marcar
        {
            get { return _Marca; }
            set
            {
                _Marca = value;
                PartitionKey = value;
            }
        }

        public String Modelo { get; set; }
        public String Tipo { get; set; }
        public String Coste { get; set; }

    }
}