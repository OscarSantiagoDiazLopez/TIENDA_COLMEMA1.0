using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsTienda
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Borde fijo, sin opción de redimensionar
            this.MaximizeBox = false;// Desactivar botón de maximizar
            this.MinimizeBox = true;
            refrescar();
            monto();
        }


        public void CargarGrafica(List<Colmena> sales)
        {
            // Limpiar series anteriores
            this.chart1.Series.Clear();

            // Crear una nueva serie para el gráfico de pastel
            Series series = new Series("Ventas")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true // Muestra las etiquetas en el gráfico
            };

            // Agregar datos a la serie
            foreach (var colmena in sales)
            {

                series.Points.AddXY(colmena.NombrePro, colmena.Ventas);

            }

            // Agregar la serie al gráfico
            this.chart1.Series.Add(series);

            // Configurar el diseño del gráfico
            chart1.Titles.Clear();
            chart1.Titles.Add("Ventas por Producto");
            chart1.Legends[0].Enabled = true; // Habilitar la leyenda
        }

        private void buttonREFRESCAR_Click(object sender, EventArgs e)
        {
            refrescar();
            monto();
        }

        public void refrescar()
        {
            try
            {

                AdmonBD obj = new AdmonBD();

                // Obtener la lista de ventas desde la base de datos
                List<Colmena> updatedVentas = obj.MostrarInformacion();

                // Actualizar la gráfica con los datos obtenidos
                CargarGrafica(updatedVentas);

                // Desconectar la base de datos después de usarla
                obj.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la gráfica: " + ex.Message);
            }
        }

        public void monto()
        {
            try
            {
                AdmonBD obj = new AdmonBD();
                decimal montoTotal = obj.ObtenerMontoTotal();

                lblMonto.Text = $"Total de ventas de acuerdo al monto: ${montoTotal}";

                obj.Disconnect();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al obtener el monto total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
