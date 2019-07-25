using Proyecto_Sistema_Nutricional_UH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Sistema_Nutricional_UH.Controllers
{
    public class HomeController : Controller
    {
        public static Funciones objFunciones = new Funciones();
        public static RegistrosAvances objregistros = new RegistrosAvances();
        public static Usuario usuario = new Usuario();
        public static int cedula = 0;
        public static int peso = 0;
        public static decimal calorias = 0;
        public static int cantidadComidasDia = 0;

        //**************************Pagina Inicio**************************
        public ActionResult Index()
        {
            cedula = 0;
            peso = 0;
            calorias = 0;
            cantidadComidasDia = 0;
            usuario = new Usuario();
            objregistros = new RegistrosAvances();
            return View();
        }

        [HttpPost]
        public ViewResult Index(Usuario usuario)
        {
            DataSet ds = objFunciones.ObtenerTablaUsuario();
            DataTable tabla = ds.Tables[0];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                int registroCedula = (int)tabla.Rows[i][0];
                string registroContrasena = tabla.Rows[i][1].ToString();
                if (usuario.cedula == registroCedula && usuario.contrasena.Equals(registroContrasena))
                {
                    usuario.cedula = (int)tabla.Rows[i][0];
                    usuario.contrasena = tabla.Rows[i][1].ToString();
                    usuario.nombre = tabla.Rows[i][2].ToString();
                    usuario.apellidos = tabla.Rows[i][3].ToString();
                    usuario.sexo = tabla.Rows[i][4].ToString();
                    usuario.edad = (int)tabla.Rows[i][5];
                    usuario.estatura = (int)tabla.Rows[i][6];
                    usuario.peso = (int)tabla.Rows[i][7];
                    usuario.correo = tabla.Rows[i][8].ToString();
                    usuario.tasaMetabolicaBasal = tabla.Rows[i][9].ToString();
                    usuario.factorActividad = tabla.Rows[i][10].ToString();
                    usuario.caloriasNecesarias = tabla.Rows[i][11].ToString();
                    usuario.cantidadComidas = (int)tabla.Rows[i][12];
                    cedula = usuario.cedula;
                    calorias = decimal.Parse(tabla.Rows[i][11].ToString());
                    peso = usuario.peso;
                    cantidadComidasDia = usuario.cantidadComidas;
                }
            }
            if (!string.IsNullOrEmpty(usuario.nombre))
            {
                try
                {
                    DataSet dataTabla = objFunciones.DataGrafico(cedula);
                    DataTable tabla2 = dataTabla.Tables[0];
                    string fechas = "";
                    string pesografico = "";

                    for (int i = 0; i < tabla2.Rows.Count; i++)
                    {
                        pesografico = pesografico + "," + (tabla2.Rows[i][3].ToString());
                        fechas = fechas + "," + (tabla2.Rows[i][11].ToString());
                    }
                    ViewBag.fechasGrafico = fechas;
                    ViewBag.pesoGrafico = pesografico;
                    return View("Dashboard", usuario);
                }
                catch (Exception)
                {
                    return View(usuario);
                }                
            }
            else
            {
                ViewBag.mensaje = "Los datos Ingresados no coinciden";
                return View();
            }
        }

        //*********************************Registro Usuario Nuevo*********************************   
        [HttpGet]
        public ActionResult RegistroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegistroUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.sexo.Equals("Hombre"))
                {
                    decimal sexotmb = 66;
                    decimal pesotmb = 13.7m;
                    decimal alturatmb = 5;
                    decimal edadtmb = 6.8m;
                    decimal factoractividad = 0;
                    decimal tasaMetabolicaBasal = (sexotmb + (pesotmb * usuario.peso) + (alturatmb * usuario.estatura) + (edadtmb * usuario.edad));
                    if (usuario.factorActividad.Equals("1.2m"))
                    {
                        factoractividad = 1.2m;
                    }
                    else
                    {
                        if (usuario.factorActividad.Equals("1.375m"))
                        {
                            factoractividad = 1.375m;
                        }
                        else
                        {
                            if (usuario.factorActividad.Equals("1.55m"))
                            {
                                factoractividad = 1.55m;
                            }
                            else
                            {
                                if (usuario.factorActividad.Equals("1.725m"))
                                {
                                    factoractividad = 1.725m;
                                }
                                else
                                {
                                    if (usuario.factorActividad.Equals("1.9m"))
                                    {
                                        factoractividad = 1.9m;
                                    }
                                }
                            }
                        }
                    }
                    decimal consumocalorias = tasaMetabolicaBasal * factoractividad;
                    usuario.tasaMetabolicaBasal = tasaMetabolicaBasal.ToString();
                    usuario.caloriasNecesarias = consumocalorias.ToString();
                    usuario.factorActividad = factoractividad.ToString();
                    objFunciones.InsertarUsuarioNuevo(usuario.cedula, usuario.contrasena, usuario.nombre, usuario.apellidos, usuario.sexo, usuario.edad, usuario.estatura, usuario.peso, usuario.correo, usuario.tasaMetabolicaBasal, usuario.factorActividad, usuario.caloriasNecesarias, usuario.cantidadComidas);
                    return View("Index");
                }
                else
                {
                    if (usuario.sexo.Equals("Mujer"))
                    {
                        decimal sexotmb = 655;
                        decimal pesotmb = 9.6m;
                        decimal alturatmb = 1.8m;
                        decimal edadtmb = 4.7m;
                        decimal factoractividad = 0;
                        decimal tasaMetabolicaBasal = (sexotmb + (pesotmb * usuario.peso) + (alturatmb * usuario.estatura) + (edadtmb * usuario.edad));
                        if (usuario.factorActividad.Equals("1.2m"))
                        {
                            factoractividad = 1.2m;
                        }
                        else
                        {
                            if (usuario.factorActividad.Equals("1.375m"))
                            {
                                factoractividad = 1.375m;
                            }
                            else
                            {
                                if (usuario.factorActividad.Equals("1.55m"))
                                {
                                    factoractividad = 1.55m;
                                }
                                else
                                {
                                    if (usuario.factorActividad.Equals("1.725m"))
                                    {
                                        factoractividad = 1.725m;
                                    }
                                    else
                                    {
                                        if (usuario.factorActividad.Equals("1.9m"))
                                        {
                                            factoractividad = 1.9m;
                                        }
                                    }
                                }
                            }
                        }
                        decimal consumocalorias = tasaMetabolicaBasal * factoractividad;
                        usuario.tasaMetabolicaBasal = tasaMetabolicaBasal.ToString();
                        usuario.caloriasNecesarias = consumocalorias.ToString();
                        usuario.factorActividad = factoractividad.ToString();
                        objFunciones.InsertarUsuarioNuevo(usuario.cedula, usuario.contrasena, usuario.nombre, usuario.apellidos, usuario.sexo, usuario.edad, usuario.estatura, usuario.peso, usuario.correo, usuario.tasaMetabolicaBasal, usuario.factorActividad, usuario.caloriasNecesarias, usuario.cantidadComidas);
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.mensaje = "Error en el ingreso de datos";
                        return View();
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error en el ingreso de datos";
                return View();
            }
        }

        //**************************Pagina Dashboard**************************

        [HttpGet]
        public ActionResult Dashboard()
        {
            try
            {
                DataSet dataTabla = objFunciones.DataGrafico(cedula);
                DataTable tabla = dataTabla.Tables[0];
                string fechas ="";
                string  pesografico ="";

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    pesografico = pesografico +","+ (tabla.Rows[i][3].ToString());
                    fechas = fechas +"," + (tabla.Rows[i][11].ToString());
                }
                ViewBag.fechasGrafico = fechas;
                ViewBag.pesoGrafico = pesografico;
                return View(usuario);
            }
            catch (Exception)
            {
                return View(usuario);
            }            
        }

        [HttpPost]
        public ActionResult Dashboard(Usuario usuario)
        {
            return View("ControlNutricional", usuario);
        }

        //**************************Pagina Control Nutricional**************************
        [HttpGet]
        public ActionResult ControlNutricional()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ControlNutricional(Dieta dieta)
        {
            try
            {
                int sumaCarnes = 0;
                int sumaLacteos = 0;
                int sumaVerduras = 0;
                int sumaFrutas = 0;
                int sumaGranos = 0;
                int sumaTotal = 0;
                int pesoNuevo = peso - 1;
                int caloriasNuevas = (int)calorias - 500;

                sumaCarnes = dieta.carne + dieta.pescado + dieta.pollo + dieta.ternero + dieta.cerdo;
                sumaLacteos = dieta.leche + dieta.queso + dieta.helado + dieta.yogurth + dieta.natilla;
                sumaVerduras = dieta.brocoli + dieta.tomate + dieta.lechuga + dieta.papas + dieta.repollo;
                sumaFrutas = dieta.manzana + dieta.pera + dieta.naranja + dieta.banano + dieta.mandarina;
                sumaGranos = dieta.arroz + dieta.frijoles + dieta.cereal + dieta.pan + dieta.pasta;
                sumaTotal = sumaCarnes + sumaLacteos + sumaVerduras + sumaFrutas + sumaGranos;

                if (calorias <= sumaTotal)
                {
                    sumaCarnes = (int)caloriasNuevas / 5;
                    sumaLacteos = (int)caloriasNuevas / 5;
                    sumaVerduras = (int)caloriasNuevas / 5;
                    sumaFrutas = (int)caloriasNuevas / 5;
                    sumaGranos = (int)caloriasNuevas / 5;
                    objFunciones.InsertarDieta(cedula, peso, pesoNuevo, calorias.ToString(), caloriasNuevas.ToString(), sumaCarnes, sumaVerduras, sumaLacteos, sumaFrutas, sumaGranos, DateTime.Now.Date.ToString());
                    objFunciones.ActualizarPeso(cedula, peso - 1, caloriasNuevas.ToString());

                    objregistros.ceduladieta = cedula;
                    objregistros.pesoanterior = peso;
                    objregistros.pesonuevo = peso - 1;
                    objregistros.caloriasnecesariasdieta = caloriasNuevas;
                    objregistros.totalCarnes = sumaCarnes / cantidadComidasDia;
                    objregistros.totalLacteos = sumaLacteos / cantidadComidasDia;
                    objregistros.totalVerduras = sumaVerduras / cantidadComidasDia;
                    objregistros.totalFrutas = sumaFrutas / cantidadComidasDia;
                    objregistros.totalGranos = sumaGranos / cantidadComidasDia;

                    return View("Resultado", objregistros);
                }
                else
                {
                    objFunciones.InsertarDieta(cedula, peso, pesoNuevo, calorias.ToString(), caloriasNuevas.ToString(), sumaCarnes, sumaVerduras, sumaLacteos, sumaFrutas, sumaGranos, DateTime.Now.Date.ToString());
                    objFunciones.ActualizarPeso(cedula, peso - 1, caloriasNuevas.ToString());

                    objregistros.ceduladieta = cedula;
                    objregistros.pesoanterior = peso;
                    objregistros.pesonuevo = peso - 1;
                    objregistros.caloriasnecesariasdieta = caloriasNuevas;
                    objregistros.totalCarnes = sumaCarnes / cantidadComidasDia;
                    objregistros.totalLacteos = sumaLacteos / cantidadComidasDia;
                    objregistros.totalVerduras = sumaVerduras / cantidadComidasDia;
                    objregistros.totalFrutas = sumaFrutas / cantidadComidasDia;
                    objregistros.totalGranos = sumaGranos / cantidadComidasDia;

                    return View("Resultado", objregistros);
                }
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Error en el ingreso de datos";
                return View();
            }
        }
        //**************************Pagina Resultados**************************
        [HttpGet]
        public ActionResult Resultado(RegistrosAvances objregistros)
        {
            return View(objregistros);
        }
    }
}