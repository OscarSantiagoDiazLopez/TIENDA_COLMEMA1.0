using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;



namespace WinFormsTienda
{
    public partial class OpcionPago : Form
    {
        public event Action OnProductosActualizados;
        private string nombreUsuario;
        private List<dynamic> carritoDatos;
        List<Colmena> data;

        private string nombre;
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        //private List<Producto> productosSeleccionados = new List<Producto>(); // Almacenará los productos seleccionados

        /*public OpcionPago()
        {
            InitializeComponent();
           
        }*/

        public OpcionPago(List<(Producto producto, int cantidad)> datos, string usuario)
        {
            InitializeComponent();
            /*carritoDatos = datos;
            nombreUsuario = usuario;*/
            carritoDatos = datos.Cast<dynamic>().ToList(); // Opcional, si necesitas usar dinámicos internamente
            nombreUsuario = usuario;
        }
        List<(Producto producto, int cantidad)> productosSeleccionados = new List<(Producto, int)>();



        private void buttonOXXO_Click(object sender, EventArgs e)
        {
            pdfOxxo();
        }
        public void pdfOxxo()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("FICHA DE PAGO"));

            // Cargar la plantilla HTML
            string PaginaHTML_Texto = Properties.Resources.plantillaPDF.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            decimal total = 0;

            // Generar las filas de la tabla y calcular el total
            filas = string.Empty;
            total = 0;

            foreach (var item in carritoDatos)
            {
                filas += "<tr>";
                filas += $"<td>{item.Cantidad}</td>";
                filas += $"<td>{item.Nombre}</td>";
                filas += $"<td>${item.PrecioUnitario:F2}</td>";
                filas += $"<td>${item.Importe:F2}</td>";
                filas += "</tr>";

                total += Convert.ToDecimal(item.Importe);
            }


            // Calcular impuestos y total con impuesto
            decimal impuesto = total * 0.06m; // Solo el impuesto
            decimal totalConImpuesto = total + impuesto;

            // Reemplazar las etiquetas en la plantilla HTML
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", $"${total:F2}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IMPUESTO", $"${totalConImpuesto:F2}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", $"{nombreUsuario}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", "FICHA DE PAGO");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", "NO. CUENTA: 0001259786412365");


            // Guardar el archivo PDF
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    // Procesar el HTML con los reemplazos
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    //Declaracion de la imagen
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.login, System.Drawing.Imaging.ImageFormat.Jpeg);
                    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.login, System.Drawing.Imaging.ImageFormat.Jpeg);


                    pdfDoc.Add(img); // Agregar la imagen al documento
                    img.ScaleToFit(70, 70);
                    img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Bottom + 50);
                    pdfDoc.Add(img2);

                    // Procesar el HTML con los reemplazos
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Cerrar el flujo y el documento
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Ficha de pago generada.", "RECUERDA PASAR A UNA TIENDA OXXO ANTES DE QUE SE CUMPLAN LOS 5 DIAS HABILES", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FormUsuario formUsuario = new FormUsuario(nombreUsuario);
            //formUsuario.ShowDialog();
        }

        private void buttonTARJETA_Click(object sender, EventArgs e)
        {
            string nombreUsuario = "Usuario123"; // El valor que quieres enviar
            FormUsuario formusuario = new FormUsuario(nombreUsuario); // Pasar el dato al constructor de Form2
            formusuario.Show(); // Mostrar el formulario;
        }
    }

}
