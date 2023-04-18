using GestionClientesAPI.Models;
using GestionClientesAPI.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace GestionClientesAPI.Controllers
{
    [ApiController]
    public class UsuariosController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public dynamic GetUsuarios()
        {
            List<Parametro> list = new List<Parametro>
            {
                new Parametro("@usuarios_id","1")
            };
            DataTable tCategoria =  DBConexion.Listar("mostrar_clientes",list);

            string jsonCategoria = JsonConvert.SerializeObject(tCategoria);

            return new
            {
                success = true,
                messsge = "Exito",
                result = new
                {
                    /*Convertimos el string en un objeto JSON*/
                    categoria = JsonConvert.DeserializeObject<List<GCUsuarios>>(jsonCategoria),
                }
            };
        }

        [HttpPost]
        [Route("api/[controller]")]
        public dynamic PostUsers(UsuariosDTO usuariosDTO)
        {
            List<Parametro> insert = new List<Parametro>
            {
                new Parametro("@usuarios_name",usuariosDTO.usuarios_name),
                new Parametro("@usuarios_password",usuariosDTO.usuarios_password)

            };

            bool exito  = DBConexion.Ejecutar("agregar_clientes", insert);
            return new
            {
                success = true,
                message = exito ? "Guardado con Exito" : "Error al Guardar",
                result = " "
            };
        }

        [HttpPost]
        [Route("api/eliminar/[controller]")]
        public dynamic DeleteUsers(UsuariosDTO usuariosDTO)
        {
            List<Parametro> delete = new List<Parametro>
            {
                new Parametro("@usuarios_id",usuariosDTO.usuarios_id),
                new Parametro("@usuarios_name",usuariosDTO.usuarios_name),
                new Parametro("@usuarios_password",usuariosDTO.usuarios_password)
            };

            bool exito = DBConexion.Ejecutar("eliminar_clientes", delete);
            return new
            {
                success = true,
                message = exito ? "Eliminado con Exit" : "Error al Eliminar",
                result = " "
            };
        }
    }
}
