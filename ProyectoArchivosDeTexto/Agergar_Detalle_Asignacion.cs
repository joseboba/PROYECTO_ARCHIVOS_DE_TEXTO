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
    public partial class Agergar_Detalle_Asignacion : Form
    {
        string fileName = "Detalle_asignacion.txt";
        public Agergar_Detalle_Asignacion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Todos los campos son requeridos.");
            }
            else if (validateCatedratico())
            {
                MessageBox.Show("El catedratico ingresado no existe.");
            }
            else if (validateCurso())
            {
                MessageBox.Show("El curso ingresado no existe.");
            }
            else
            {
                int id = generateId();
                StreamWriter sw = File.AppendText(fileName);
                sw.Write(id + "|");
                sw.Write(txtCatedratico.Text.Trim() + "|");
                sw.Write(txtCurso.Text.Trim() + "|");
                sw.Write(txtHorario.Text.Trim() + "|");
                sw.Write(txtDiasImpartido.Text.Trim());
                sw.WriteLine();
                MessageBox.Show("Se ha guardado con exito el registro: " + id);
                limpiar();
                sw.Close();
            }
        }


        private void limpiar()
        {
            txtCatedratico.Text = "";
            txtCurso.Text = "";
            txtHorario.Text = "";
            txtDiasImpartido.Text = "";
        }

        private bool validate()
        {
            return String.IsNullOrEmpty(txtCatedratico.Text.Trim()) ||
             String.IsNullOrEmpty(txtCurso.Text.Trim()) ||
             String.IsNullOrEmpty(txtHorario.Text.Trim()) ||
             String.IsNullOrEmpty(txtDiasImpartido.Text.Trim());
        }

        private bool validateCatedratico()
        {
            bool found = true;

            StreamReader sr = File.OpenText("Catedratico.txt");
            String line;
            List<String> list = new List<String>();

            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split('|').ToList();
                if (list[0].Equals(txtCatedratico.Text.Trim()))
                {
                    found = false;
                }
            }
            sr.Close();
            return found;
        }

        private bool validateCurso()
        {
            bool found = true;
            StreamReader sr = File.OpenText("Curso.txt");
            String line;
            List<String> list = new List<String>();

            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split('|').ToList();
                if (list[0].Equals(txtCurso.Text.Trim()))
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
