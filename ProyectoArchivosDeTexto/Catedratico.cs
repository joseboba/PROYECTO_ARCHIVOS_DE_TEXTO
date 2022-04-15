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
    public partial class Catedratico : Form
    {
        public Catedratico()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Catedratico window = new Agregar_Catedratico();
            window.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Catedratico window = new Buscar_Catedratico();
            window.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Catedratico window = new Eliminar_Catedratico();
            window.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar_Catedratico window = new Actualizar_Catedratico();
            window.ShowDialog();
        }
    }
}
