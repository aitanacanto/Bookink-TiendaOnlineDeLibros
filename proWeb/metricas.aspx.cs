using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI;

namespace proWeb
{
    public partial class metricas : System.Web.UI.Page
    {
        private string constring;

        protected void Page_Load(object sender, EventArgs e)
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
            if (!IsPostBack)
            {
                graficaVentas();
            }
        }

        private void graficaVentas()
        {
            var labels = new List<string>();
            var data = new List<int>();

            using (SqlConnection conex = new SqlConnection(constring))
            {
                try
                {
                    conex.Open();

                    string query = "SELECT FORMAT(Fecha, 'MM/yy') AS Mes, COUNT(*) AS Cantidad " +
                                   "FROM Pedidos " +
                                   "GROUP BY FORMAT(Fecha, 'MM/yy') " +
                                   "ORDER BY MIN(Fecha)";
                    SqlCommand cmd = new SqlCommand(query, conex);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader["Mes"].ToString());
                        data.Add(Convert.ToInt32(reader["Cantidad"]));
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores: registra el error o manejarlo como desees
                    Console.WriteLine(ex);
                    labels.Add("Error");
                    data.Add(0);
                }
            }

            // Construye el script para la gráfica
            StringBuilder script = new StringBuilder();
            script.Append("<script>");
            script.Append("window.onload = function() {");
            script.Append("var ctx = document.getElementById('pedidosChart').getContext('2d');");
            script.Append("var pedidosChart = new Chart(ctx, {");
            script.Append("type: 'bar',");
            script.Append("data: {");
            script.Append("labels: [" + string.Join(",", labels.ConvertAll(l => "'" + l + "'")) + "],");
            script.Append("datasets: [{");
            script.Append("label: 'Cantidad de Pedidos',");
            script.Append("data: [" + string.Join(",", data) + "],");
            script.Append("backgroundColor: 'rgba(54, 162, 235, 0.2)',");
            script.Append("borderColor: 'rgba(54, 162, 235, 1)',");
            script.Append("borderWidth: 1");
            script.Append("}]");
            script.Append("},");
            script.Append("options: {");
            script.Append("scales: {");
            script.Append("y: {");
            script.Append("beginAtZero: true,");
            script.Append("max: 50");
            script.Append("}");
            script.Append("}");
            script.Append("}");
            script.Append("});");
            script.Append("}");
            script.Append("</script>");

            litScript.Text = script.ToString();
        }
    }
}
