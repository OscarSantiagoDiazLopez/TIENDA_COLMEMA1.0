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
    public partial class FormAdmin : Form
    {
        List<Colmena> data;
        private string nombre;
        public FormAdmin(string nombre)
        {
            this.nombre = nombre;
            InitializeComponent();
            this.textBoxNombre.Text = this.nombre;
            ConfigurarDataGridView();
            MostrarProductos();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("PRODUCTO", "PRODUCTO");
            dataGridView1.Columns.Add("IMAGEN", "IMAGEN");
            dataGridView1.Columns.Add("DESCRIPCION", "DESCRIPCION");
            dataGridView1.Columns.Add("PRECIO", "PRECIO");
            dataGridView1.Columns.Add("EXISTENCIAS", "EXISTENCIAS");
            dataGridView1.Columns.Add("VENTAS", "VENTAS");
        }

        private void MostrarProductos()
        {
            AdmonBD obj = new AdmonBD();
            data = obj.MostrarInformacion();
            data.ForEach(x =>
            {
                dataGridView1.Rows.Add(x.IdP, x.NombrePro, x.Imagen, x.Descripcion, x.Precio, x.Existencias, x.Ventas);
            });

        }

        private void buttonLOGOUT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CERRANDO SESION");
            this.Close();
        }

        private void buttonREFRESCAR_Click(object sender, EventArgs e)
        {
            AdmonBD obj = new AdmonBD();
            data = obj.MostrarInformacion();

            //mostrar informacion 
            //this.richTextBox1.Clear();
            this.dataGridView1.Rows.Clear();
            //this.dataGridView1.DataSource = null;
            data.ForEach(x =>
            {
                dataGridView1.Rows.Add(x.IdP, x.NombrePro, x.Imagen, x.Descripcion, x.Precio, x.Existencias, x.Ventas);
                //this.richTextBox1.AppendText("ID: " + x.IdP + "NOMBREPRODUCTO: " + x.NombrePro + "IMAGEN: " + x.Imagen + "DESCRIPCION: " + x.Descripcion + "PRECIO: " + x.Precio + "EXISTENCIAS: " + x.Existencias + "\n");
            });
            obj.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void buttonINSERTAR_Click(object sender, EventArgs e)
        {
            int id;
            string nom;
            string des;
            string ima;
            int pre;
            int exi;
            int vent;

            id = Convert.ToInt32(this.textBoxID.Text);
            nom = this.textBoxNOMPRO.Text;
            des = this.textBoxDESCRIPCION.Text;
            ima = this.textBoxIMAGEN.Text;
            pre = Convert.ToInt32(this.textBoxPRECIO.Text);
            exi = Convert.ToInt32(this.textBoxEXISTENCIAS.Text);
            vent = Convert.ToInt32(this.textBoxVENTAS.Text);

            AdmonBD obj = new AdmonBD();
            obj.insertar(id, nom, ima, des, pre, exi, vent);
            limpiar();
            obj.Disconnect();

        }

        public void limpiar()
        {
            textBoxID.Clear();
            textBoxIMAGEN.Clear();
            textBoxNOMPRO.Clear();
            textBoxDESCRIPCION.Clear();
            textBoxPRECIO.Clear();
            textBoxEXISTENCIAS.Clear();
            textBoxVENTAS.Clear();
        }

        private void buttonELIMINAR_Click(object sender, EventArgs e)
        {
            AdmonBD obj = new AdmonBD();
            var result = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                obj.eliminar(Convert.ToInt32(this.textBoxID.Text));
                this.textBoxID.PlaceholderText = "ID";
                obj.Disconnect();
            }
            
        }

        private void buttonVENTAS_Click(object sender, EventArgs e)
        {
            Form3 a3 = new Form3();
            a3.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
