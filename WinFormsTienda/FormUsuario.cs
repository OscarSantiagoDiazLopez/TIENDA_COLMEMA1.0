using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTienda
{
    public partial class FormUsuario : Form
    {
        List<Colmena> data;
        private string nombre;
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<Producto> productosSeleccionados = new List<Producto>(); // Almacenará los productos seleccionados

        public FormUsuario(string nombre)
        {
            this.nombre = nombre;
            //nombreUsuario = nombre; // Guardar el valor recibido
            InitializeComponent();
            CargarProductos();
            timer2.Enabled = true;
            this.textBoxNombre.Text = this.nombre;
            

        }

        public void CargarProductos()
        {
            // Ruta base para buscar imágenes
            string rutaCarpetaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenVS");

            // Obtener datos de la base de datos
            AdmonBD obj = new AdmonBD();
            List<Producto> productos = obj.MostrarInformacion1(); // Devuelve la lista de productos

            if (productos.Count == 0)
            {
                MessageBox.Show("No se encontraron productos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<PictureBox> pictureBoxes = new List<PictureBox>
    {
        pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
        pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10
    };

            List<RichTextBox> richTextBoxes = new List<RichTextBox>
    {
        richTextBox1, richTextBox2, richTextBox3, richTextBox4, richTextBox5,
        richTextBox6, richTextBox7, richTextBox8, richTextBox9, richTextBox10
    };

            comboBoxes = new List<ComboBox>
    {
        prodBox1, prodBox2, prodBox3, prodBox4, prodBox5,
        prodBox6, prodBox7, prodBox8, prodBox9, prodBox10
    };

            // Llenar ComboBoxes con opciones de cantidad (0-10)
            foreach (var combo in comboBoxes)
            {
                combo.Items.Clear();
                combo.Items.AddRange(Enumerable.Range(0, 10).Select(n => n.ToString()).ToArray());
                combo.SelectedIndex = -1; // Sin selección inicial
                combo.DropDownStyle = ComboBoxStyle.DropDownList; // Solo permite seleccionar
                combo.Enabled = false;    // Deshabilitar hasta que haya un producto
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;  // Limpiar las imágenes
            }

            foreach (var richTextBox in richTextBoxes)
            {
                richTextBox.Clear();  // Limpiar los textos
            }

            // Filtrar productos con existencias > 0
            productos = productos.Where(p => p.Existencias > 0).ToList();

            int index = 0;
            foreach (var producto in productos)
            {
                try
                {
                    // Buscar la imagen en la carpeta
                    string rutaImagen = Path.Combine(rutaCarpetaImagenes, producto.Imagen);

                    if (!File.Exists(rutaImagen))
                        continue;

                    if (index < pictureBoxes.Count && index < richTextBoxes.Count && index < comboBoxes.Count)
                    {
                        PictureBox pictureBox = pictureBoxes[index];
                        RichTextBox richTextBox = richTextBoxes[index];
                        ComboBox comboBox = comboBoxes[index];

                        // Configurar PictureBox
                        pictureBox.Image = Image.FromFile(rutaImagen);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Tag = producto.IdP;

                        // Configurar RichTextBox
                        richTextBox.Text = $"Producto: {producto.NameP}\nDescripcion: {producto.Descripcion}\nPrecio: ${producto.Precio}\nExistencias: {producto.Existencias}";

                        // Habilitar ComboBox
                        comboBox.Enabled = true;
                        comboBox.Tag = producto; // Guardar producto en el Tag

                        index++;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error al cargar producto {producto.IdP}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedIndex != -1)
            {
                // Obtener el producto asociado desde el Tag
                Producto producto = (Producto)comboBox.Tag;

                if (producto != null)
                {
                    // Añadir producto a la lista si no existe
                    if (!productosSeleccionados.Contains(producto))
                    {
                        productosSeleccionados.Add(producto);
                    }
                }
            }
        }

        private void CARRITO_Click(object sender, EventArgs e)
        {
            List<(Producto producto, int cantidad)> productosSeleccionados = new List<(Producto, int)>();

            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.Enabled && comboBox.SelectedIndex != -1) // Validar ComboBox activa con selección
                {
                    Producto producto = (Producto)comboBox.Tag; // Producto asociado
                    int cantidadSeleccionada = int.Parse(comboBox.SelectedItem.ToString());

                    if (cantidadSeleccionada > 0) // Validar que la cantidad sea mayor a 0
                    {
                        if (producto != null)
                        {
                            if (cantidadSeleccionada > producto.Existencias)
                            {
                                MessageBox.Show(
                                    $"No es posible comprar {cantidadSeleccionada} unidades del producto \"{producto.NameP}\".\nSolo hay {producto.Existencias} en existencia.",
                                    "Error de compra",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }
                            else
                            {
                                productosSeleccionados.Add((producto, cantidadSeleccionada));
                            }
                        }
                    }
                }
            }

            if (productosSeleccionados.Count > 0)
            {
                /*OpcionPago opcionPago = new OpcionPago(productosSeleccionados, nombre);
                opcionPago.OnProductosActualizados += CargarProductos;

                opcionPago.ShowDialog();*/

                FormCarrito formCarrito = new FormCarrito(productosSeleccionados, nombre);  // Pasa la lista con los productos y cantidades seleccionados
                formCarrito.OnProductosActualizados += CargarProductos;

                formCarrito.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay productos seleccionados o las cantidades son inválidas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CargarProductos();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            labelFECHA.Text = DateTime.Now.ToLongDateString();
            labelHORA.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void buttonLOGOUT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CERRANDO SESION");
            this.Close();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
