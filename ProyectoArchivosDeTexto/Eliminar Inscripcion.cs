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
    public partial class Eliminar_Inscripcion : Form
    {

        string fileName = "Inscripcion.txt";
        public Eliminar_Inscripcion()
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

        private string foundEstudent(string search)
        {
            string descripcion = null;
            StreamReader sr = File.OpenText("Estudiante.txt");
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
            txtEstudiante.Text = foundEstudent(list[2]);
            txtFechaInscripcion.Text = list[3];
            txtGradoAcademico.Text = list[4];
        }

        private void limpiar()
        {
            txtCentroEducativo.Text = "";
            txtEstudiante.Text = "";
            txtFechaInscripcion.Text = "";
            txtGradoAcademico.Text = "";
            txtId.Text = "";
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
    }
}
