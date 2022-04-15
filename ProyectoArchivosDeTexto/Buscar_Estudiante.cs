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
    public partial class Buscar_Estudiante : Form
    {
        string fileName = "Estudiante.txt";
        public Buscar_Estudiante()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                        setValues(list);
                        found = true;
                    }
                }
                sr.Close();
            }

            if (!found)
            {
                MessageBox.Show("No existe un registro con ese carne");
                limpiar();
            }
        }

        private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
        }

        private void setValues(List<String> list)
        {
            txtCarne.Text = list[0];
            txtNombre.Text = list[1];
            txtDireccion.Text = list[2];
            txtTelefono.Text = list[3];
            txtFecha.Text = list[4];
            txtSexo.Text = list[5];
        }

        private void limpiar()
        {
            txtCarne.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFecha.Text = "";
            txtSexo.Text = "";
        }
    }
}
