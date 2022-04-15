using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArchivosDeTexto
{
    public partial class Centro_Educativo : Form
    {
        public Centro_Educativo()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Centro_Educativo window = new Agregar_Centro_Educativo();
            window.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Centro_Educativo window = new Buscar_Centro_Educativo();
            window.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Centro_Educativo window = new Eliminar_Centro_Educativo();
            window.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar_Centro_Educativo window = new Actualizar_Centro_Educativo();
            window.ShowDialog();
        }
    }
}
