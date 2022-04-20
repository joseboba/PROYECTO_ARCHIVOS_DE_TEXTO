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
    public partial class Agregar_Curso : Form
    {
        string fileName = "Curso.txt";
        public Agregar_Curso()
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
                int id = generateId();
                StreamWriter sw = File.AppendText(fileName);
                sw.Write(id + "|");
                sw.Write(txtNombre.Text.Trim() + "|");
                sw.Write(txtDescripcion.Text.Trim());
                sw.WriteLine();
                MessageBox.Show("Se ha guardado con exito el registro: " + id);
                limpiar();
                sw.Close();
            }

        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private bool validate()
        {
            return (String.IsNullOrEmpty(txtNombre.Text)) ||
                String.IsNullOrEmpty(txtDescripcion.Text);
        }

        private int generateId()
        {
            StreamReader read;
            try
            {
                read = File.OpenText(fileName);
            }
            catch
            {
                return 1;
            }

            String line;
            List<String> list = new List<String>();

            while ((line = read.ReadLine()) != null)
            {
                list.Add(line);
            }
            read.Close();

            int id = 1;
            if (list.Count > 0)
            {
                id = int.Parse(list[list.Count - 1].Split('|')[0]);
            }
            return (list.Count <= 0) ? id : id + 1;
        }
    }
}
