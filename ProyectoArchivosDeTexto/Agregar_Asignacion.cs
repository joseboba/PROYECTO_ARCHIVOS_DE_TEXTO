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
    public partial class Agregar_Asignacion : Form
    {
        string fileName = "Asignaciones.txt";
        public Agregar_Asignacion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Todos los campos son requeridos.");
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
                sw.Write(txtFecha.Text.Trim() + "|");
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
            txtFecha.Text = "";
            txtGradoAcademico.Text = "";
        }

        private bool validate()
        {
            return String.IsNullOrEmpty(txtCentroEducativo.Text.Trim()) ||
             String.IsNullOrEmpty(txtFecha.Text.Trim()) ||
             String.IsNullOrEmpty(txtGradoAcademico.Text.Trim());
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

            int id = 1;
            if (list.Count > 0)
            {
                id = int.Parse(list[list.Count - 1].Split('|')[0]);
            }
            return (list.Count <= 0) ? id : id + 1;
        }
    }
}
