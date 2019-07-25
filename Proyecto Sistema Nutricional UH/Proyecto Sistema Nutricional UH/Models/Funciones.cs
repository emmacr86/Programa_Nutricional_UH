using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Nutricional_UH.Models
{
    public class Funciones
    {
        public int InsertarUsuarioNuevo(int cedula, string contrasena, string nombre, string apellidos, string sexo, int edad, int estatura, int peso, string correo, string tasaMetabolicaBasal, string factorActividad, string caloriasNecesarias, int cantidadComidas)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("Insert Into tablaPersona(cedulaPersona,contrasenaPersona,nombrePersona,apellidosPersona,sexoPersona,edadPersona,estaturaPersona,pesoPersona,correoPersona,tasaMetabolicaPersona,factorAtividadPersona,caloriasNecesariasPersona,cantidadComidasPersona)Values('"
            + cedula + "','" + contrasena + "','" + nombre + "','" + apellidos + "','" + sexo + "','" + edad + "','" + estatura + "','" + peso + "','" + correo + "','" + tasaMetabolicaBasal + "','" + factorActividad + "','" + caloriasNecesarias + "','" + cantidadComidas + "')", conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public DataSet ObtenerTablaUsuario()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("Select * FROM tablaPersona", conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(tabla);
            return tabla;
        }

        public DataSet ValidarUsuarioIngresado(int cedula, string contrasena)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM tablaPersona WHERE cedulaPersona = " + cedula + " AND contrasenaPersona = " + contrasena, conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(tabla);
            return tabla;
        }

        public int InsertarDieta(int cedulaDieta, int pesoAnteriorDieta, int pesoNuevoDieta, string caloriasNecesariasDieta, string caloriasIndicadasDieta, int carnesDieta, int vegetalesDieta, int lacteosDieta, int harinasDieta, int otrosDieta, string fechaDieta)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("Insert Into tablaDieta(cedulaDieta,pesoAnteriorDieta,pesoNuevoDieta,caloriasNecesariasDieta,caloriasIndicadasDieta,carnesDieta,vegetalesDieta,lacteosDieta,harinasDieta,otrosDieta,fechaDieta)Values('"
            + cedulaDieta + "','" + pesoAnteriorDieta + "','" + pesoNuevoDieta + "','" + caloriasNecesariasDieta + "','" + caloriasIndicadasDieta + "','" + carnesDieta + "','" + vegetalesDieta + "','" + lacteosDieta + "','" + harinasDieta + "','" + otrosDieta + "','" + fechaDieta + "')", conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public int ActualizarPeso(int cedula, int peso, string calorias)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("Update tablaPersona Set pesoPersona='" + peso + "', caloriasNecesariasPersona='" + calorias + " 'Where cedulaPersona=" + cedula, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public DataSet DataGrafico(int cedula)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(local);Initial Catalog=SistemaNutricional;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM tablaDieta WHERE cedulaDieta = " + cedula, conexion);
            DataSet tabla = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(tabla);
            return tabla;
        }
    }
}