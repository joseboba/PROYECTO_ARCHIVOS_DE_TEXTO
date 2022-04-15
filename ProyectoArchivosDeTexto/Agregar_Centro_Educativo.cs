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
    public partial class Agregar_Centro_Educativo : Form
    {
        string fileName = "Centro_Educativo.txt";
        public Agregar_Centro_Educativo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Todos los campos son requeridos.");
            } else
            {
                int id = generateId();
                StreamWriter sw = File.AppendText(fileName);
                sw.Write(id + "|");
                sw.Write(txtNombre.Text.Trim() + "|");
                sw.Write(txtDireccion.Text.Trim() + "|");
                sw.Write(txtTelefono.Text.Trim());
                sw.WriteLine();
                MessageBox.Show("Se ha guardado con exito el registro: " + id);
                limpiar();
                sw.Close();
            }

        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        
        private bool validate()
        {
            return (txtNombre.Text == null || txtNombre.Text.Trim().Length == 0) ||
                (txtDireccion.Text == null || txtDireccion.Text.Trim().Length == 0) ||
                (txtTelefono.Text == null || txtTelefono.Text.Trim().Length == 0);
        }

        private int generateId()
        {
            StreamReader read;
            try
            {
                read = File.OpenText(fileName);
            } catch
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
