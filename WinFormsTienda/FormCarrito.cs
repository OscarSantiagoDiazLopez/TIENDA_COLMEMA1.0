using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace WinFormsTienda
{
    public partial class FormCarrito : Form
    {

        //private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<(Producto producto, int cantidad)> productosSeleccionados;
        private string nombreUsuario;
        public event Action OnProductosActualizados; // Evento a lanzar después de la compra

        public FormCarrito(List<(Producto producto, int cantidad)> productosSeleccionados, string nombreUsuario)
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarProductos(productosSeleccionados);
            this.productosSeleccionados = productosSeleccionados ?? new List<(Producto, int)>(); // Asegurarse de que nunca sea null
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Borde fijo, sin opción de redimensionar
            this.MaximizeBox = false;// Desactivar botón de maximizar
            this.MinimizeBox = true;
            PAGAR.Visible = true;
            RECIBO.Visible = false;
            CANCELAR.Visible = true;
            this.nombreUsuario = nombreUsuario;
            lblEfectivo.Visible = false;
            txtEfectivo.Visible = false;
            lblCambio.Visible = false;
            
            cbMetodoPago.Items.Add("Tarjeta");
            cbMetodoPago.Items.Add("Efectivo");
            cbMetodoPago.SelectedIndex = 0; // Seleccionar "Tarjeta" por defecto
            cbMetodoPago.SelectedIndexChanged += ComboBoxMetodoPago_SelectedIndexChanged;

            // Inicializar visibilidad de los controles
            ActualizarControlesPago("Tarjeta");
            cbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList; // Solo permite seleccionar
        }
        private void ComboBoxMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodoSeleccionado = cbMetodoPago.SelectedItem.ToString();
            ActualizarControlesPago(metodoSeleccionado);
            cbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList; // Solo permite seleccionar
        }

        // Método para alternar entre los controles de Tarjeta y Efectivo
        private void ActualizarControlesPago(string metodo)
        {
            if (metodo == "Tarjeta")
            {
                // Mostrar controles relacionados con tarjeta
                txtNumeroTarjeta.Visible = true;
                txtFechaVencimiento.Visible = true;
                txtCVC.Visible = true;
                lblNTARJETA.Visible = true;
                lblVENCIMIENTO.Visible = true;
                lblCVC.Visible = true;

                // Ocultar controles relacionados con efectivo
                //lblEfectivo.Visible = false;
                txtEfectivo.Visible = false;
                //lblCambio.Visible = false;
                txtCambio.Visible = false;
            }
            else if (metodo == "Efectivo")
            {
                // Mostrar controles relacionados con efectivo
                //lblEfectivo.Visible = true;
                txtEfectivo.Visible = true;
                //lblCambio.Visible = true;
                //txtCambio.Visible = true;

                // Ocultar controles relacionados con tarjeta
                txtNumeroTarjeta.Visible = false;
                txtFechaVencimiento.Visible = false;
                txtCVC.Visible = false;
                lblNTARJETA.Visible = false;
                lblVENCIMIENTO.Visible = false;
                lblCVC.Visible= false;
            }
        }
        private void TxtEfectivoEntregado_TextChanged(object sender, EventArgs e)
        {
            // Validar que el texto ingresado sea un número válido
            if (decimal.TryParse(txtEfectivo.Text, out decimal efectivoEntregado))
            {
                // Obtener el total a pagar con impuestos
                decimal totalConImpuesto = decimal.Parse(lblTotalImpuesto.Text.Replace("Total con Impuesto: $", ""));

                if (efectivoEntregado >= totalConImpuesto)
                {
                    // Calcular el cambio
                    decimal cambio = efectivoEntregado - totalConImpuesto;
                    txtCambio.Text = cambio.ToString("F2");
                }
                else
                {
                    txtCambio.Text = "0.00"; // No hay cambio si el efectivo es menor al total
                }
            }
            else
            {
                txtCambio.Text = "0.00"; // Reiniciar el cambio si no es un número válido
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Nombre", "Nombre");
            dgvCarrito.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvCarrito.Columns.Add("Importe", "Importe");

            dgvCarrito.CellClick += dgvCarrito_CellClick;
        }
        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que la fila clickeada sea válida
            {
                // Obtener el nombre del producto y la cantidad de la fila seleccionada
                string productoNombre = dgvCarrito.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                int cantidadProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["Cantidad"].Value);
                decimal precioProducto = Convert.ToDecimal(dgvCarrito.Rows[e.RowIndex].Cells["Importe"].Value);

                // Buscar el producto en la lista de productos seleccionados
                var productoSeleccionado = productosSeleccionados.FirstOrDefault(p => p.producto.NameP == productoNombre);

                // Mostrar mensaje de confirmación
                var result = MessageBox.Show("¿Seguro que deseas eliminar este producto del carrito?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Eliminar el producto de la lista de productos seleccionados
                    productosSeleccionados.Remove(productoSeleccionado);

                    // Eliminar la fila del DataGridView
                    dgvCarrito.Rows.RemoveAt(e.RowIndex);

                    // Actualizar el total
                    ActualizarTotal(precioProducto);
                }
                
            }
            
        }
        
        private decimal ActualizarTotal(decimal precioProductoEliminado)
        {
            // Reducir el precio del total actual
            decimal totalActual = decimal.Parse(lblTotal.Text.Replace("Total: $", ""));
            decimal nuevoTotal = totalActual - precioProductoEliminado;

            // Calcular impuesto y total con impuesto
            decimal impuesto = nuevoTotal * 0.06m;
            decimal totalConImpuesto = nuevoTotal + impuesto;

            // Actualizar las etiquetas del total
            lblTotal.Text = $"Total: ${nuevoTotal:F2}";
            lblTotalImpuesto.Text = $"Total con Impuesto: ${totalConImpuesto:F2}";

            return totalConImpuesto;

        }

        private void CargarProductos(List<(Producto producto, int cantidad)> productosSeleccionados)
        {


            decimal total = 0;

            foreach (var (producto, cantidad) in productosSeleccionados)
            {
                decimal importe = cantidad * producto.Precio;
                //producto.Ventas = cantidad;
                AdmonBD obj = new AdmonBD();
                total += importe;

                dgvCarrito.Rows.Add(cantidad, producto.NameP, producto.Precio, importe);
            }

            // Calcular total con impuesto
            decimal impuesto = total * 0.06m; // 6%
            decimal totalConImpuesto = total + impuesto;

            // Mostrar totales
            lblTotal.Text = $"Total: ${total:F2}";
            lblTotalImpuesto.Text = $"Total con Impuesto: ${totalConImpuesto:F2}";


        }


        private void TxtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void TxtFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar);
        }


        private void TxtFechaVencimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtFechaVencimiento.Text.Length == 2 && !txtFechaVencimiento.Text.Contains("/"))
            {
                txtFechaVencimiento.Text += "/";
                txtFechaVencimiento.SelectionStart = txtFechaVencimiento.Text.Length;
            }
        }


        private void TxtCVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PAGAR_Click(object sender, EventArgs e)
        {
            string metodoSeleccionado = cbMetodoPago.SelectedItem.ToString();
            decimal totalConImpuesto = decimal.Parse(lblTotalImpuesto.Text.Replace("Total con Impuesto: $", ""));

            if (metodoSeleccionado == "Tarjeta")
            {
                // Validar y procesar pago con tarjeta
                if (txtNumeroTarjeta.Text.Length != 16)
                {
                    MessageBox.Show("El número de la tarjeta debe tener exactamente 16 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParseExact(txtFechaVencimiento.Text, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaVencimiento))
                {
                    MessageBox.Show("La fecha de vencimiento no es válida. Use el formato MM/YY.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtCVC.Text.Length != 3)
                {
                    MessageBox.Show("El CVC debe tener exactamente 3 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Procesar compra con tarjeta
                ProcesarCompra();
                MessageBox.Show("Pago realizado con tarjeta con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (metodoSeleccionado == "Efectivo")
            {
                // Validar y procesar pago en efectivo
                if (!decimal.TryParse(txtEfectivo.Text, out decimal efectivoEntregado))
                {
                    MessageBox.Show("Por favor, ingrese un monto válido de efectivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (efectivoEntregado < totalConImpuesto)
                {
                    MessageBox.Show("El efectivo entregado no es suficiente para completar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcular el cambio
                decimal cambio = efectivoEntregado - totalConImpuesto;

                
                // Procesar compra con efectivo
                ProcesarCompra();
                MessageBox.Show($"Pago realizado con efectivo con éxito.\nCambio: ${cambio:F2}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            pdf();
            //decimal totalConImpuesto = decimal.Parse(lblTotalImpuesto.Text.Replace("Total con Impuesto: $", ""));
            AdmonBD obj = new AdmonBD();
            obj.Pagar(nombreUsuario, totalConImpuesto);
            PAGAR.Visible = false;
            CANCELAR.Visible = false;
            
            // Cerrar el formulario después del pago
            this.Close();
        }


        private void ProcesarCompra()
        {
            if (productosSeleccionados == null || productosSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay productos seleccionados para procesar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AdmonBD obj = new AdmonBD();

            foreach (var (producto, cantidadSeleccionada) in productosSeleccionados) // Usa los productos seleccionados
            {
                if (producto != null)
                {
                    // Actualizar existencias
                    producto.Existencias -= cantidadSeleccionada;
                    obj.ActualizarExistencias(producto.IdP, producto.Existencias); // Actualiza la base de datos con las nuevas existencias

                    // Actualizar ventas
                    obj.InsertarVenta(producto.IdP, cantidadSeleccionada); // Suma la cantidad seleccionada al campo 'ventas'

                    // Si las existencias llegan a 0, eliminar el producto
                    if (producto.Existencias == 0)
                    {
                        obj.EliminarProducto(producto.IdP); // Llamar a un método para eliminar el producto de la base de datos

                    }
                }
            }

            OnProductosActualizados?.Invoke();
            FormUsuario formUsuario = new FormUsuario(nombreUsuario);
            formUsuario.CargarProductos();
            //MessageBox.Show("Compra procesada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        public void pdf()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("recibo"));

            // Cargar la plantilla HTML
            string PaginaHTML_Texto = Properties.Resources.plantillaPDF.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            decimal total = 0;

            // Generar las filas de la tabla y calcular el total
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["Cantidad"].Value != null &&
                    row.Cells["Nombre"].Value != null &&
                    row.Cells["PrecioUnitario"].Value != null &&
                    row.Cells["Importe"].Value != null)
                {
                    filas += "<tr>";
                    filas += $"<td>{row.Cells["Cantidad"].Value}</td>";
                    filas += $"<td>{row.Cells["Nombre"].Value}</td>";
                    filas += $"<td>${row.Cells["PrecioUnitario"].Value:F2}</td>";
                    filas += $"<td>${row.Cells["Importe"].Value:F2}</td>";
                    filas += "</tr>";

                    total += Convert.ToDecimal(row.Cells["Importe"].Value);
                }
                
            }

            // Calcular impuestos y total con impuesto
            decimal impuesto = total * 0.06m; // Solo el impuesto
            decimal totalConImpuesto = total + impuesto;

            // Reemplazar las etiquetas en la plantilla HTML
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", $"${total:F2}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IMPUESTO", $"${totalConImpuesto:F2}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", $"{nombreUsuario}");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", "65347");

            // Guardar el archivo PDF
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    //string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "fotototototo.jpg");

                    // Agregar la imagen del encabezado
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.fotototototo, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.ScaleToFit(70, 70);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    // Procesar el HTML con los reemplazos
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Cerrar el flujo y el documento
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Recibo generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FormUsuario formUsuario = new FormUsuario(nombreUsuario);
            //formUsuario.ShowDialog();
        }
       
        private void RECIBO_Click(object sender, EventArgs e)
        {

        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCarrito_Load(object sender, EventArgs e)
        {

        }

    }
    
}



