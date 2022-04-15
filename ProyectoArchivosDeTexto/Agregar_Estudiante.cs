using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoArchivosDeTexto
{
    
    public partial class Agregar_Estudiante : Form
    {
        string fileName = "Estudiante.txt";
        public Agregar_Estudiante()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Todos los campos son requeridos.");
            }
            else
            {
                string carne = System.Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
                StreamWriter sw = File.AppendText(fileName);
                sw.Write(carne + "|");
                sw.Write(txtNombre.Text.Trim() + "|");
                sw.Write(txtDireccion.Text.Trim() + "|");
                sw.Write(txtTelefono.Text.Trim() + "|");
                sw.Write(txtFecha.Text.Trim() + "|");
                sw.Write(txtSexo.Text.Trim());
                sw.WriteLine();
                MessageBox.Show("Se ha guardado con exito el registro: " + carne);
                limpiar();
                sw.Close();
            }
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFecha.Text = "";
            txtSexo.Text = "";
        }

        private bool validate()
        {
            return String.IsNullOrEmpty(txtNombre.Text.Trim()) ||
                String.IsNullOrEmpty(txtDireccion.Text.Trim()) ||
                String.IsNullOrEmpty(txtTelefono.Text.Trim()) ||
                String.IsNullOrEmpty(txtFecha.Text.Trim()) || 
                String.IsNullOrEmpty(txtSexo.Text.Trim());
        }
    }
}
