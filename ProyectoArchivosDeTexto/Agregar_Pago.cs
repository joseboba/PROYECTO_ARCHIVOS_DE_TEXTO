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
    public partial class Agregar_Pago : Form
    {
        string fileName = "Pagos.txt";
        public Agregar_Pago()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Todos los campos son requeridos.");
            }
            else if (validateEstudent())
            {
                MessageBox.Show("El estudiante ingresado no existe.");
            }
            else if (validateCentroEducativo())
            {
                MessageBox.Show("El centro educativo ingresado no existe.");
            }
            else
            {
                int id = generateId();
                StreamWriter sw = File.AppendText(fileName);
                sw.Write(id + "|");
                sw.Write(txtCentroEducativo.Text.Trim() + "|");
                sw.Write(txtEstudiante.Text.Trim() + "|");
                sw.Write(txtFechaPago.Text.Trim() + "|");
                sw.Write(txtGradoAcademico.Text.Trim());
                sw.WriteLine();
                MessageBox.Show("Se ha guardado con exito el registro: " + id);
                limpiar();
                sw.Close();
            }
        }


        private void limpiar()
        {
            txtCentroEducativo.Text = "";
            txtEstudiante.Text = "";
            txtFechaPago.Text = "";
            txtGradoAcademico.Text = "";
        }

        private bool validate()
        {
            return String.IsNullOrEmpty(txtCentroEducativo.Text.Trim()) ||
             String.IsNullOrEmpty(txtEstudiante.Text.Trim()) ||
             String.IsNullOrEmpty(txtFechaPago.Text.Trim()) ||
             String.IsNullOrEmpty(txtGradoAcademico.Text.Trim());
        }

        private bool validateEstudent()
        {
            bool found = true;

            StreamReader sr = File.OpenText("Estudiante.txt");
            String line;
            List<String> list = new List<String>();

            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split('|').ToList();
                if (list[0].Equals(txtEstudiante.Text.Trim()))
                {
                    found = false;
                }
            }
            sr.Close();
            return found;
        }

        private bool validateCentroEducativo()
        {
            bool found = true;
            StreamReader sr = File.OpenText("Centro_Educativo.txt");
            String line;
            List<String> list = new List<String>();

            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split('|').ToList();
                if (list[0].Equals(txtCentroEducativo.Text.Trim()))
                {
                    found = false;
                }
            }
            sr.Close();
            return found;
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
            int id = int.Parse(list[list.Count - 1].Split('|')[0]);
            return id + 1;
        }

    }
}
