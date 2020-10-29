using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotemar.Models.Spartane
{
    public class CineListModel
    {
        [JsonProperty("Cines")]
        public List<Cine> Cines { get; set; }

        [JsonProperty("RowCount")]
        public long RowCount { get; set; }
    }
    public class Cine
    {
        [JsonProperty("Folio")]
        public long Folio { get; set; }

        [JsonProperty("Numero_de_Cine")]
        public string NumeroDeCine { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Razon_Social")]
        public string RazonSocial { get; set; }

        [JsonProperty("RFC")]
        public string Rfc { get; set; }

        [JsonProperty("Telefono")]
        public string Telefono { get; set; }

        [JsonProperty("Direccion")]
        public string Direccion { get; set; }

        [JsonProperty("Numero_Exterior")]
        public long NumeroExterior { get; set; }

        [JsonProperty("Colonia")]
        public string Colonia { get; set; }

        [JsonProperty("Municipio")]
        public string Municipio { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }
    }
}
