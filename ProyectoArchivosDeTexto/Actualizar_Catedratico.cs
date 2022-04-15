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
    public partial class Actualizar_Catedratico : Form
    {
        string fileName = "Catedratico.txt";
        public Actualizar_Catedratico()
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

                record[1] = txtNombre.Text.Trim();
                record[2] = txtDireccion.Text.Trim();
                record[3] = txtTelefono.Text.Trim();
                record[4] = txtEspecializacion.Text.Trim();

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

        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEspecializacion.Text = "";
        }

        private bool validateEmpty()
        {
            return (String.IsNullOrEmpty(txtBuscar.Text.Trim()));
        }

        private void setValues(List<String> list)
        {
            txtId.Text = list[0];
            txtNombre.Text = list[1];
            txtDireccion.Text = list[2];
            txtTelefono.Text = list[3];
            txtEspecializacion.Text = list[4];
        }

        private void enable()
        {
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEspecializacion.Enabled = true;
        }

        private void disable()
        {
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEspecializacion.Enabled = false;
        }
    }
}
