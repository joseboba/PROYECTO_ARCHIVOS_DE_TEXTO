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
    public partial class Eliminar_Curso : Form
    {
        string fileName = "Curso.txt";
        public Eliminar_Curso()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            search(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            search(false);
        }

        private void search(bool search)
        {
            bool found = false;
            if (validateEmpty())
            {
                MessageBox.Show("No existe ningun parametro de busqueda.");
                found = true;
            }
            else
            {
                StreamReader sr = File.OpenText(fileName);
                String line;
                List<String> list = new List<String>();

                while ((line = sr.ReadLine()) != null)
                {
                    list = line.Split('|').ToList();
                    if (list[0].Equals(txtBuscar.Text.Trim()))
                    {
                        if (search)
                        {
                            setValues(list);
                            btnEliminar.Enabled = true;
                            btnBuscar.Enabled = false;
                            txtBuscar.Enabled = false;
                        }
                        found = true;
                    }
                }

                sr.Close();
            }

            if (!found)
            {
                MessageBox.Show("No existe un registro con ese id");
                limpiar();
            }

            if (!search && found)
            {
                File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l.Split('|')[0] != txtBuscar.Text.Trim()).ToList());
                MessageBox.Show("Registro eliminado con exito.");
                limpiar();
                btnEliminar.Enabled = false;
                btnBuscar.Enabled = true;
                txtBuscar.Enabled = true;
            }

        }

        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
        }

        private void setValues(List<String> list)
        {
            txtId.Text = list[0];
            txtNombre.Text = list[1];
            txtDescripcion.Text = list[2];
        }
    }
}
