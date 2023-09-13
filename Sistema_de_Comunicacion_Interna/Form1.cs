using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Comunicacion_Interna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public partial class Registro : Form
        {
            SqlConnection con = new SqlConnection("Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;Integrated Security=True");
            // Reemplazar nombre_servidor y nombre_base_datos con los valores adecuados.

            public Registro()
            {
                InitializeComponent();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir la conexión a la base de datos.
                con.Open();

                // Crear un objeto SqlCommand para ejecutar la consulta INSERT.
                SqlCommand cmd = new SqlCommand("INSERT INTO usuarios (nombre, correo_electronico, contrasena) VALUES (@nombre, @correo, @contrasena)", con);

                // Asignar valores a los parámetros de la consulta.
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                // Ejecutar la consulta.
                cmd.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos.
                con.Close();

                // Mostrar un mensaje de éxito.
                MessageBox.Show("Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error.
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }

            try
            {
                // Conectarse a la base de datos.
                SqlConnection con = new SqlConnection("Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;Integrated Security=True");
                con.Open();

                // Crear la consulta de inserción.
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (nombre, correo, contrasena) VALUES (@nombre, @correo, @contrasena)", con);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                // Ejecutar la consulta.
                cmd.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos.
                con.Close();

                // Mostrar un mensaje de éxito.
                MessageBox.Show("Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error.
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Obtener el id del usuario emisor (quien está enviando el mensaje).
            int emisorId = ObtenerIdUsuarioActual();

            // Obtener el id del usuario receptor (destinatario del mensaje).
            int receptorId = ObtenerIdUsuarioSeleccionado();

            // Obtener el asunto y cuerpo del mensaje.
            string asunto = txtAsunto.Text;
            string cuerpo = txtCuerpo.Text;

            try
            {
                // Conectar a la base de datos.
                SqlConnection con = new SqlConnection("Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;User ID=nombre_usuario;Password=contraseña_usuario");
                con.Open();

                // Insertar el mensaje en la tabla de Mensajes.
                SqlCommand cmd = new SqlCommand("INSERT INTO Mensajes (EmisorId, ReceptorId, Asunto, Cuerpo, Estado) VALUES (@emisorId, @receptorId, @asunto, @cuerpo, 'pendiente')", con);
                cmd.Parameters.AddWithValue("@emisorId", emisorId);
                cmd.Parameters.AddWithValue("@receptorId", receptorId);
                cmd.Parameters.AddWithValue("@asunto", asunto);
                cmd.Parameters.AddWithValue("@cuerpo", cuerpo);
                cmd.ExecuteNonQuery();

                // Cerrar la conexión a la base de datos.
                con.Close();

                // Mostrar un mensaje de éxito.
                MessageBox.Show("Mensaje enviado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error.
                MessageBox.Show("Error al enviar mensaje: " + ex.Message);
            }
        }
