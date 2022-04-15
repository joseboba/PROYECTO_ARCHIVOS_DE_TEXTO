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
    public partial class Buscar_Detalle_Asignacion : Form
    {
        string fileName = "Detalle_asignacion.txt";
        public Buscar_Detalle_Asignacion()
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
                        if (String.IsNullOrEmpty(foundCurso(list[2])) || String.IsNullOrEmpty(foundCatedratico(list[1])))
                        {
                            MessageBox.Show("No existe el catedratico o el cuso");
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

        private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
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
    }
}
