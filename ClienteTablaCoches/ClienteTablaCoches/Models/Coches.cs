using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteTablaCoches.Models
{
    public class Coches: TableEntity
    {
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

        private String _Marca;
        public string Marca
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