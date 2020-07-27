using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BaseDatos.Entidades;


namespace BaseDatos
{
    public class GestionBD
    {
        //Declarando las variables
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionCaso"].ConnectionString; //De una forma dinamica
                                                                                                        
        public int actualizarCarro(Carro obj)
        {
            int cantidadRegistros = -1;
            //La estructura using es para crear recursos que solo van a existir en memoria dentro de su bloque de programación 
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Carro " +
                                  "set MARCA = @MARCA, " +
                                  "    MODELO = @MODELO, " +
                                  "    PAIS = @PAIS, " +
                                  "    COSTO = @COSTO " +
                                  "Where IDCARRO = @IDCARRO ";
                cmd.Parameters.Add(new SqlParameter("@MARCA", obj.MARCA));
                cmd.Parameters.Add(new SqlParameter("@MODELO", obj.MODELO));
                cmd.Parameters.Add(new SqlParameter("@PAIS", obj.PAIS));
                cmd.Parameters.Add(new SqlParameter("@COSTO", obj.COSTO));
                cmd.Parameters.Add(new SqlParameter("@IDCARRO", obj.IDCARRO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); 
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int eliminarCarro(Carro obj)
        {
            int cantidadRegistros = -1;
           
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {            
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Carro Where IDCARRO = @IDCARRO";
                cmd.Parameters.Add(new SqlParameter("@IDCARRO", obj.IDCARRO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int registrarCarro(Carro obj)
        {
            int cantidadRegistros = -1;
          
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Carro (MARCA,MODELO,PAIS,COSTO)" +
                " Values (@MARCA,@MODELO,@PAIS,@COSTO)";
                cmd.Parameters.Add(new SqlParameter("@MARCA", obj.MARCA));
                cmd.Parameters.Add(new SqlParameter("@MODELO", obj.MODELO));
                cmd.Parameters.Add(new SqlParameter("@PAIS", obj.PAIS));
                cmd.Parameters.Add(new SqlParameter("@COSTO", obj.COSTO));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public DataTable cargarCarros()
        {
            DataTable objTabla = new DataTable(); //Inicializamos la Tabla
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Carro";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla); 
            return objTabla;
        }

    }
}
