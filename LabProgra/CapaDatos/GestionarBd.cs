using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Entidades;

namespace CapaDatos
{
    public class GestionarBd
    {
        SqlConnection conexion;
        SqlCommand comando;



        //--INSERT DE AUTO--//
        public int RegistrarAuto(Auto objAuto)
        {

            int cantRegistros = -1;

            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-GEUAC8A\SQLEXPRESS;Initial Catalog=AutoV;Integrated Security=True";

            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into auto (IdCarro,Marca,Modelo,Pais,Costo) " +
                                      "Values (@IdCarro,@Marca,@Modelo,@Pais,@Costo)";

                //--DEFINICION DE PARAMETROS--//
                comando.Parameters.Add(new SqlParameter("@IdCarro", objAuto.IdCarro));
                comando.Parameters.Add(new SqlParameter("@Marca", objAuto.Marca));
                comando.Parameters.Add(new SqlParameter("@Modelo", objAuto.Modelo));
                comando.Parameters.Add(new SqlParameter("@Pais", objAuto.Pais));
                comando.Parameters.Add(new SqlParameter("@Costo", objAuto.Costo));

                //--Conexion ABIERTA--//
                conexion.Open();

                cantRegistros = comando.ExecuteNonQuery();

                //--Conexion CERRADA--//
                conexion.Close();
            }
            return cantRegistros;
        }

        //--MODIFICACION DE AUTO--//
        public int ModificarAuto(Auto objAuto)
        {

            int cantRegistros = -1;

            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-GEUAC8A\SQLEXPRESS;Initial Catalog=AutoV;Integrated Security=True";

            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Update auto set Marca = @Marca, Modelo = @Modelo, Pais =@Pais, Costo =@Costo where IdCarro = @Idcarro ";


                //--DEFINICION DE PARAMETROS--//
                comando.Parameters.Add(new SqlParameter("@IdCarro", objAuto.IdCarro));
                comando.Parameters.Add(new SqlParameter("@Marca", objAuto.Marca));
                comando.Parameters.Add(new SqlParameter("@Modelo", objAuto.Modelo));
                comando.Parameters.Add(new SqlParameter("@Pais", objAuto.Pais));
                comando.Parameters.Add(new SqlParameter("@Costo", objAuto.Costo));

                //--Conexion ABIERTA--//
                conexion.Open();

                cantRegistros = comando.ExecuteNonQuery();

                //--Conexion CERRADA--//
                conexion.Close();
            }
            return cantRegistros;
        }

        //--ELIMINACION DE AUTO--//
        public int EliminarAuto(Auto objherra)
        {
            int cantRegistros = -1;

            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-GEUAC8A\SQLEXPRESS;Initial Catalog=AutoV;Integrated Security=True";  //String de Conexion

            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Delete from auto where idCarro=@idCarro";

                //DEFINICION DE PARAMETRO
                comando.Parameters.Add(new SqlParameter("@idCarro", objherra.IdCarro));

                conexion.Open();

                cantRegistros = comando.ExecuteNonQuery();
            }
            return cantRegistros;
        }

        //--CARGA DE DATOS DE AUTO--//
        public DataTable cargaAutos()
        {

            DataTable objTabla = new DataTable();
            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-GEUAC8A\SQLEXPRESS;Initial Catalog=AutoV;Integrated Security=True";

            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from auto";
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
                sqlAdaptador.Fill(objTabla); //CARGAMOS TABLA QUE NOS RETORNA EL COMANDO
                return objTabla;
            }
        }
    }
}
