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
    public partial class Actualizar_Inscripcion : Form
    {
        string fileName = "Inscripcion.txt";
        public Actualizar_Inscripcion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            search(true);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            search(false);
        }

         private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
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
            List<String> listUpdate = new List<String>();
            bool found = false;
            int foundIndex = 0;

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

                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    list = line.Split('|').ToList();
                    listUpdate.Add(line);
                    if (list[0].Equals(txtBuscar.Text.Trim()))
                    {
                        if (search)
                        {
                            setValues(list);
                            btnActualizar.Enabled = true;
                            btnBuscar.Enabled = false;
                            txtBuscar.Enabled = false;
                            enable();
                        }
                        foundIndex = count;
                        found = true;
                    }
                    count++;
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
                List<String> record = listUpdate[foundIndex].Split('|').ToList();
                string centroEducativo = foundCentroEducativo(txtCentroEducativo.Text);
                string student = foundEstudent(txtEstudiante.Text);

                if(String.IsNullOrEmpty(student))
                {
                    MessageBox.Show("El estudiante no existe");
                } else if (String.IsNullOrEmpty(centroEducativo))
                {
                    MessageBox.Show("El centro educativo no existe");
                } else
                {
                    record[1] = txtCentroEducativo.Text.Trim();
                    record[2] = txtEstudiante.Text.Trim();
                    record[3] = txtFechaInscripcion.Text.Trim();
                    record[4] = txtGradoAcademico.Text.Trim();

                    string[] arrLine = File.ReadAllLines(fileName);
                    arrLine[foundIndex] = String.Join("|", record);
                    File.WriteAllLines(fileName, arrLine);

                    MessageBox.Show("Registro actualizado con exito.");
                    btnActualizar.Enabled = false;
                    btnBuscar.Enabled = true;
                    txtBuscar.Enabled = true;
                    limpiar();
                    disable();
                }
            }

        }

        private void enable()
        { 
            txtCentroEducativo.Enabled = true;
            txtEstudiante.Enabled = true;
            txtFechaInscripcion.Enabled = true;
            txtGradoAcademico.Enabled = true;
        }

        private void disable()
        {
            txtCentroEducativo.Enabled = false;
            txtEstudiante.Enabled = false;
            txtFechaInscripcion.Enabled = false;
            txtGradoAcademico.Enabled = false;
        }
    }
}
