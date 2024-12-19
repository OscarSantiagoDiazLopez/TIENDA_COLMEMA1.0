using NAudio.Wave;
using System.Windows.Forms;
using System.Media;

using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsTienda
{
    public partial class FormPORTADA : Form
    {
        private SoundPlayer musica;

       // public Form1()        
            public FormPORTADA()
        {
            InitializeComponent();
            musica = new SoundPlayer(new MemoryStream(Properties.Resources.ABEJA));
        }
        private void FormPORTADA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLOGIN a1 = new FormLOGIN();
            this.Hide();
            a1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musica.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musica.Stop();
        }
    }
}
