using ApiTablaCoches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace ApiTablaCoches.Controllers
{
    public class TokenController : ApiController
    {
        ModeloToken modelo;
        public TokenController()
        {
            this.modelo = new ModeloToken();
        }
        [HttpGet]
        [Route("api/gettoken/{marca}")]
        public String GetToken(String marca)
        {
            return modelo.GetSeguridadSaS(marca);
        }

    }
}
