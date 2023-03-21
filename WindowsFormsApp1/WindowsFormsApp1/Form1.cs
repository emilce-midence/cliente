using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Función para guardar un nuevo registro de cliente
        public void GuardarCliente(string nombre, string direccion, string telefono)
        {
            try
            {
                // Conectar a la base de datos
                MySqlConnection conexion = new MySqlConnection("server=localhost;database=facturacion;user id=root;password=123456;");
                conexion.Open();

                // Insertar el nuevo registro en la tabla de clientes
                string consulta = "INSERT INTO clientes(nombre, direccion, telefono) VALUES(@nombre, @direccion, @telefono)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message);
            }
        }

        // Función para actualizar un registro existente de cliente
        public void ActualizarCliente(int id, string nombre, string direccion, string telefono)
        {
            try
            {
                // Conectar a la base de datos
                MySqlConnection conexion = new MySqlConnection("server=localhost;database=facturacion;user id=root;password=123456;");
                conexion.Open();

                // Actualizar el registro en la tabla de clientes
                string consulta = "UPDATE clientes SET nombre = @nombre, direccion = @direccion, telefono = @telefono WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
            }
        }

        // Función para eliminar un registro de cliente
        public void EliminarCliente(int id)
        {
            try
            {
                // Conectar a la base de datos
                MySqlConnection conexion = new MySqlConnection("server=localhost;database=facturacion;user id=root;password=123456;");
                conexion.Open();

                // Eliminar el registro de la tabla de clientes
                string consulta = "DELETE FROM clientes WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
            }
        }



    }
}
