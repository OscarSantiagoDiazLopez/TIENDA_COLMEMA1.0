using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Intrinsics.Arm;
using Mysqlx.Crud;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;


namespace WinFormsTienda
{
    public class AdmonBD
    {
        private MySqlConnection connection;

        public AdmonBD()
        {
            this.Connect();
        }

        public void Disconnect()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Conexión cerrada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool ValidarUsuario(string usuario, string contrasena)
        {
            try
            {
                // Cadena de conexión
                string connectionString = "Server=localhost; Database=tienda; User=root; Password=; SslMode=none;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL corregida
                    string query = "SELECT COUNT(*) FROM cuentas WHERE APODO = @Usuario AND CONTRASENA = @Contrasena";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contrasena", contrasena);

                        // Ejecutar la consulta
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count == 1; // Devuelve true si el usuario existe
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public string ObtenerModoUsuario(string usuario)
        {
            try
            {
                // Cadena de conexión
                string connectionString = "Server=localhost; Database=tienda; User=root; Password=; SslMode=none;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener el campo MODO
                    string query = "SELECT MODO FROM cuentas WHERE APODO = @Usuario";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        // Ejecutar la consulta y obtener el valor
                        object result = command.ExecuteScalar();
                        return result?.ToString() ?? string.Empty; // Devuelve el valor o una cadena vacía si no hay resultados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el modo del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MostrarUsuario(string usuario)
        {
            try
            {
                // Cadena de conexión
                string connectionString = "Server=localhost; Database=tienda; User=root; Password=; SslMode=none;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    //Cosulta SQL para obtener el campo NOMBRECOMPLETO
                    string query = "SELECT NOMBRECOMPLETO FROM cuentas WHERE APODO = @Usuario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        // Ejecutar la consulta y obtener el valor
                        object result = command.ExecuteScalar();
                        return result?.ToString() ?? string.Empty; // Devuelve el valor o una cadena vacía si no hay resultados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el modo del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Colmena> MostrarInformacion()
        {
            List<Colmena> data = new List<Colmena>();
            Colmena item;

            int idP;
            string nombrePro;
            string imagen;
            string descripcion;
            int precio;
            int existencias;
            int ventas;

            try
            {
                string query = "SELECT * FROM productos";
                MySqlCommand command = new MySqlCommand(query, this.connection);

                // Ejecutar la consulta y leer los resultados
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idP = Convert.ToInt32(reader["ID"]);
                    nombrePro = Convert.ToString(reader["NOMBREPRODUCTO"]) ?? "";
                    imagen = Convert.ToString(reader["IMAGEN"]) ?? "";
                    descripcion = Convert.ToString(reader["DESCRIPCION"]) ?? "";
                    precio = Convert.ToInt32(reader["PRECIO"]);
                    existencias = Convert.ToInt32(reader["EXISTENCIAS"]);
                    ventas = Convert.ToInt32(reader["VENTAS"]);

                    item = new Colmena(idP, nombrePro, imagen, descripcion, precio, existencias, ventas);
                    data.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                this.Disconnect();
            }

            return data;
        }


        public void insertar(int idd, string nom, string ima, string des, int pre, int exis, int vent)
        {
            string query = "";
            try
            {
                query = "INSERT INTO productos (ID, NOMBREPRODUCTO, IMAGEN, DESCRIPCION, PRECIO, EXISTENCIAS, VENTAS) VALUES (" + "'" + idd + "'," + "'" + nom + "'," + "'" + ima + "'," + "'" + des + "'," + "'" + pre + "'," + "'" + exis + "','" + vent + "');";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show(query + "\nRegistro Agregado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(query + "\nClave duplicada" + ex.Message);
                this.Disconnect();
            }
        }

        public void InsertarVenta(int idProducto, int cantidad)
        {
            string query = "";
            try
            {

                query = "UPDATE productos SET VENTAS = VENTAS + @cantidad WHERE ID = @idProducto";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar venta: " + ex.Message);
                this.Disconnect();
            }
        }

        public void eliminar(int idd)
        {
            string query = "";
            try
            {

                /* Esta forma de insertar es la menos segura en cuanto ataques por mysql pero la mas sencilla por lo pronto*/

                query = "DELETE FROM productos WHERE ID=" + idd + ";";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show(query + "\nRegistro Eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(query + "\nError " + ex.Message);
                this.Disconnect();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Producto> MostrarInformacion1()
        {
            List<Producto> data = new List<Producto>();
            Producto item;

            try
            {
                string query = "SELECT * FROM productos";
                MySqlCommand command = new MySqlCommand(query, this.connection);

                // Ejecutar la consulta y leer los resultados
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idP = Convert.ToInt32(reader["ID"]);
                    string nombrePro = Convert.ToString(reader["NOMBREPRODUCTO"]) ?? "";
                    string imagen = Convert.ToString(reader["IMAGEN"]) ?? "";
                    string descripcion = Convert.ToString(reader["DESCRIPCION"]) ?? "";
                    int precio = Convert.ToInt32(reader["PRECIO"]);
                    int existencias = Convert.ToInt32(reader["EXISTENCIAS"]);
                    int ventas = Convert.ToInt32(reader["VENTAS"]);
                    item = new Producto(idP, nombrePro, imagen, descripcion, precio, existencias, ventas);
                    data.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                this.Disconnect();
                Console.WriteLine("Error: " + ex.Message);  // Para ver el error específico si ocurre
            }

            // Verifica si se encontraron productos
            if (data.Count == 0)
            {
                MessageBox.Show("No se encontraron productos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return data;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActualizarExistencias(int productoId, int nuevasExistencias)
        {
            string query = "UPDATE productos SET EXISTENCIAS = @Existencias WHERE ID = @Id";

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Existencias", nuevasExistencias);
                    command.Parameters.AddWithValue("@Id", productoId);

                    // Ejecutar la consulta
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        //MessageBox.Show("Existencias actualizadas correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("No se encontró el producto con el ID especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar existencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarProducto(int productoId)
        {
            // Consulta para establecer el campo "imagen" como NULL (o vacío) para el producto con el ID especificado
            string query = "UPDATE productos SET Imagen = NULL WHERE ID = @Id";

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agregar el parámetro con el ID del producto
                    command.Parameters.AddWithValue("@Id", productoId);

                    // Ejecutar la consulta
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {

                        // MessageBox.Show("La imagen del producto fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        // MessageBox.Show("No se encontró el producto con el ID especificado para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error de la base de datos
                MessageBox.Show($"Ocurrió un error al intentar actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Pagar(String nombreUsuario, decimal totalConImpuesto)
        {
            try
            {
                // Crear la consulta SQL para actualizar el campo 'monto' en la tabla 'cuentas'
                string query = "UPDATE cuentas SET MONTO = MONTO + @totalConImpuesto WHERE NOMBRECOMPLETO = @usuario";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agregar los parámetros para evitar inyecciones SQL
                    command.Parameters.AddWithValue("@totalConImpuesto", totalConImpuesto);
                    command.Parameters.AddWithValue("@usuario", nombreUsuario);

                    // Ejecutar el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si la actualización fue exitosa
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("El monto se ha actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("No se encontró la cuenta o hubo un error al actualizar el monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public decimal ObtenerMontoTotal()
        {
            decimal montoTotal = 0;

            try
            {
                string query = "SELECT SUM(MONTO) AS MontoTotal FROM cuentas";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    
                    object result = command.ExecuteScalar();

                    // Si el resultado no es nulo, asignar el valor al monto total
                    if (result != DBNull.Value)
                    {
                        montoTotal = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al obtener el monto total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return montoTotal;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Connect()
        {
            string cadena = "Server=localhost; Database=tienda; User=root; Password=; SslMode=none;";
            try
            {
                connection = new MySqlConnection(cadena);
                connection.Open();
                //MessageBox.Show("Conexión establecida exitosamente.", "Información" MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}