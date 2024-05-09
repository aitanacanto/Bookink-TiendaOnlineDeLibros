using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class adminUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí llamamos a un método para obtener la lista de productos
            List<ENUsuario> listaUsuarios = ObtenerUsuarios();
            List<ENUsuario> listaTrabajadores = ObtenerUsuarios();

            // Asignamos la lista de productos al repeater
            rptUsuarios.DataSource = listaUsuarios;
            rptUsuarios.DataBind();

            rptTrabajadores.DataSource = listaTrabajadores;
            rptTrabajadores.DataBind();
        }

        // Método de ejemplo para obtener la lista de productos
        private List<ENUsuario> ObtenerUsuarios()
        {
            // Aquí puedes obtener la lista de productos desde la base de datos, archivo XML, etc.
            // Por ahora, usaremos una lista estática para ejemplificar

            List<ENUsuario> listaUsuarios = new List<ENUsuario>();
            // Añade algunos productos de ejemplo (debes obtenerlos de tu fuente de datos real)
            listaUsuarios.Add(new ENUsuario(1, "Javier", "Sanchuis Rodriguez", "494949", "javi@sanchis.com"));
            listaUsuarios.Add(new ENUsuario(2, "Manuel", "Lopez Cobos", "494949", "manu@cobos.com"));
            listaUsuarios.Add(new ENUsuario(3, "Laura", "Rodriguez Sala", "494949", "laura@sala.com"));
            listaUsuarios.Add(new ENUsuario(4, "Francisco", "Francia LoL", "494949", "fran@franclol.com"));
            listaUsuarios.Add(new ENUsuario(5, "María", "Del Oro Marín", "494949", "maria@deloro.com"));
            listaUsuarios.Add(new ENUsuario(6, "Lionel", "Messias Capuccino", "494949", "lionel@messi.com"));

            return listaUsuarios;
        }

        protected void btnBorrarTrabajador_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarTrabajador_Click(object sender, EventArgs e)
        {

        }

        protected void rptTrabajadores_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}
