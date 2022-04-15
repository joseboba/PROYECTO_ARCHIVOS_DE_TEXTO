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
    public partial class Actualizar_Detalle_Asignacion : Form
    {
        string fileName = "Detalle_asignacion.txt";
        public Actualizar_Detalle_Asignacion()
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

        private string foundCatedratico(string search)
        {
            string descripcion = null;
            StreamReader sr = File.OpenText("Catedratico.txt");
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

        private string foundCurso(string search)
        {
            string descripcion = null;
            StreamReader sr = File.OpenText("Curso.txt");
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
            txtCatedratico.Text = foundCatedratico(list[1]);
            txtCurso.Text = foundCurso(list[2]);
            txtHorario.Text = list[3];
            txtDiasImpartido.Text = list[4];
        }

        private void limpiar()
        {
            txtCatedratico.Text = "";
            txtCurso.Text = "";
            txtHorario.Text = "";
            txtDiasImpartido.Text = "";
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
                string catedratico = foundCatedratico(txtCatedratico.Text);
                string curso = foundCurso(txtCurso.Text);

                if (String.IsNullOrEmpty(curso))
                {
                    MessageBox.Show("El curso no existe");
                }
                else if (String.IsNullOrEmpty(catedratico))
                {
                    MessageBox.Show("El catedratico no existe");
                }
                else
                {
                    record[1] = txtCatedratico.Text.Trim();
                    record[2] = txtCurso.Text.Trim();
                    record[3] = txtHorario.Text.Trim();
                    record[4] = txtDiasImpartido.Text.Trim();

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
            txtCatedratico.Enabled = true;
            txtCurso.Enabled = true;
            txtHorario.Enabled = true;
            txtDiasImpartido.Enabled = true;
        }

        private void disable()
        {
            txtCatedratico.Enabled = false;
            txtCurso.Enabled = false;
            txtHorario.Enabled = false;
            txtDiasImpartido.Enabled = false;
        }
    }
}
