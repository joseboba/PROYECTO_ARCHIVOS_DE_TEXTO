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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void centroEducativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Centro_Educativo window = new Centro_Educativo();
            window.ShowDialog();    
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estudiante window = new Estudiante();
            window.ShowDialog();
        }

        private void inscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripcion window = new Inscripcion();
            window.ShowDialog();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos window = new Pagos();
            window.ShowDialog();    
        }

        private void catedraticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catedratico window = new Catedratico();
            window.ShowDialog();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curso window = new Curso();
            window.ShowDialog();    
        }

        private void asignacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignacion window = new Asignacion();
            window.ShowDialog();
        }

        private void detalleDeAsignacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_Asignacion window = new Detalle_Asignacion();
            window.ShowDialog();
        }
    }
}
