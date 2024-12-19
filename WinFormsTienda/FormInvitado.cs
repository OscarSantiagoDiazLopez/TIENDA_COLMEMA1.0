using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsTienda
{
    public partial class FormInvitado : Form
    {
        List<Colmena> data;
        private string nombre;
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private List<Producto> productosSeleccionados = new List<Producto>(); // Almacenará los productos seleccionados

        public FormInvitado(string nombre)
        {
            this.nombre = nombre;
            InitializeComponent();
            CargarProductos();
            
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
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged1;
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

        private void ComboBox_SelectedIndexChanged1(object sender, EventArgs e)
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
            MessageBox.Show("NECESITAS UNA CUENTA DE USUARIO PARA PODER COMPRAR", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonSALIR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SALIENDO");
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

    }
}
