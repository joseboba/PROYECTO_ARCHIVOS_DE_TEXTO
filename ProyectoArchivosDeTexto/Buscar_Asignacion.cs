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
    public partial class Buscar_Asignacion : Form
    {
        string fileName = "Asignaciones.txt";
        public Buscar_Asignacion()
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
                        if (String.IsNullOrEmpty(foundCentroEducativo(list[1])))
                        {
                            MessageBox.Show("No existe el centro educativo");
                        }
                        else
                        {
                            setValues(list);
                            found = true;
                        }
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


        private string foundCentroEducativo(string search)
        {
            string descripcion = null;
            StreamReader sr = File.OpenText("Centro_Educativo.txt");
            String line;
            List<String> list = new List<String>();

            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split('|').ToList();
                if (list[0].Equals(search))
                {
                    descripcion = list[1].Trim();
                }
            }
            sr.Close();
            return descripcion;
        }

        private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
        }

        private void setValues(List<String> list)
        {
            txtId.Text = list[0];
            txtCentroEducativo.Text = foundCentroEducativo(list[1]);
            txtFecha.Text = list[2];
            txtGradoAcademico.Text = list[3];
        }

        private void limpiar()
        {
            txtCentroEducativo.Text = "";
            txtFecha.Text = "";
            txtGradoAcademico.Text = "";
            txtId.Text = "";
        }
    }
}
