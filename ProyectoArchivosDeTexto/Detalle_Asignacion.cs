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
    public partial class Detalle_Asignacion : Form
    {
        public Detalle_Asignacion()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agergar_Detalle_Asignacion window = new Agergar_Detalle_Asignacion();
            window.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Detalle_Asignacion window = new Buscar_Detalle_Asignacion();
            window.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Detalle_Asignacion window = new Eliminar_Detalle_Asignacion();
            window.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar_Detalle_Asignacion window = new Actualizar_Detalle_Asignacion();
            window.ShowDialog();
        }
    }
}
