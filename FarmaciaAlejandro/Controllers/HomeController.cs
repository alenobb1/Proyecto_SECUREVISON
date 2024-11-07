using System.Diagnostics;
using FarmaciaAlejandro.Migrations;
using FarmaciaAlejandro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmpleadoFarmacia = FarmaciaAlejandro.Migrations.EmpleadoFarmacia;

namespace FarmaciaAlejandro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConexionDB _conexionDB;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ConexionDB conexionDB, IWebHostEnvironment hostEnvironment, ILogger<HomeController> logger)
        {
            _conexionDB = conexionDB;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        // Botones que dirigen a opciones
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            if (TempData["ErrorPago"] != null)
            {
                ViewBag.ErrorPago = true;

            }

            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            bool pagado = true;
            if (username == "usuario" && password == "contraseña" && pagado == true)
            {
                // Autenticación exitosa, redirigir al usuario a la página de inicio
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorPago"] = "Si";
                return RedirectToAction("Login", "Home");
                //// Credenciales incorrectas, mostrar un mensaje de error
                //ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                //return View();
            }
        }

        // Clients

        // Function to show and create a client
        public IActionResult Cliente()
        {

            return View();
        }
        public IActionResult VerClientes()
        {
            ViewBag.ListaCliente = _conexionDB.Cliente.ToList();

            return View();
        }


        public IActionResult CrearCliente()
        {

            return View();
        }
        public IActionResult EliminarCliente()
        {
            var ListaCliente = _conexionDB.Cliente.ToList();


            return View(ListaCliente);
        }

        [HttpDelete]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = _conexionDB.Cliente.Find(id); // Buscar el cliente por su ID

            if (cliente == null)
            {
                return NotFound(); // Devolver un error 404 si el cliente no existe
            }

            _conexionDB.Cliente.Remove(cliente); // Eliminar el cliente
            _conexionDB.SaveChanges(); // Guardar los cambios en la base de datos

            return RedirectToAction("VerClientes"); // Redireccionar a la acción Cliente
        }

        [HttpPost]
        public IActionResult CrearCliente(Models.Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Cliente.Add(cliente);
                _conexionDB.SaveChanges();
            }

            return RedirectToAction("Cliente", "Home"); // Redirect to the home page

        }


        public IActionResult EditarClienteGeneral()
        {
            var cliente = _conexionDB.Cliente.ToList();

            if (cliente == null)
            {
                return NotFound(); // Devolver un error 404 si el cliente no existe
            }

            return View(cliente);
        }


        [HttpGet]
        public IActionResult EditarCliente(int id)
        {
            var cliente = _conexionDB.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound(); // Devolver un error 404 si el cliente no existe
            }

            return View(cliente);
        }

        // Método para manejar la actualización del cliente
        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Entry(cliente).State = EntityState.Modified;
                _conexionDB.SaveChanges();
                return RedirectToAction("EditarClienteGeneral"); // Redireccionar a la acción Cliente
            }

            return View(cliente);
        }







        // Departamentos de Farmacia

        // Función para mostrar y crear un departamento de farmacia
        public IActionResult DepartamentoFarmacia()
        {
            return View();
        }

        public IActionResult VerDepartamentosFarmacia()
        {
            var ListaDepartamento = _conexionDB.DepartamentoFarmacia.ToList();
            return View(ListaDepartamento);
        }

        public IActionResult CrearDepartamentoFarmacia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearDepartamentoFarmacia(FarmaciaAlejandro.Models.DepartamentoFarmacia departamento)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.DepartamentoFarmacia.Add(departamento);
                _conexionDB.SaveChanges();
            }
            return RedirectToAction("DepartamentoFarmacia", "Home"); // Redirigir a la página de inicio
        }

        public IActionResult EliminarDepartamentoFarmacia()
        {
            var ListaDepartamentos = _conexionDB.DepartamentoFarmacia.ToList();
            return View(ListaDepartamentos);
        }

        [HttpDelete]
        public IActionResult EliminarDepartamentoFarmacia(int id)
        {
            var departamento = _conexionDB.DepartamentoFarmacia.Find(id); // Buscar el departamento por su ID

            if (departamento == null)
            {
                return NotFound(); // Devolver un error 404 si el departamento no existe
            }

            _conexionDB.DepartamentoFarmacia.Remove(departamento); // Eliminar el departamento
            _conexionDB.SaveChanges(); // Guardar los cambios en la base de datos

            return RedirectToAction("VerDepartamentosFarmacia"); // Redireccionar a la acción VerDepartamentosFarmacia
        }

        public IActionResult EditarDepartamentoFarmaciaGeneral()
        {
            var departamentos = _conexionDB.DepartamentoFarmacia.ToList();

            if (departamentos == null)
            {
                return NotFound(); // Devolver un error 404 si no hay departamentos
            }

            return View(departamentos);
        }

        [HttpGet]
        public IActionResult EditarDepartamentoFarmacia(int id)
        {
            var departamento = _conexionDB.DepartamentoFarmacia.Find(id);

            if (departamento == null)
            {
                return NotFound(); // Devolver un error 404 si el departamento no existe
            }

            return View(departamento);
        }

        // Método para manejar la actualización del departamento de farmacia
        [HttpPost]
        public IActionResult EditarDepartamentoFarmacia(FarmaciaAlejandro.Models.DepartamentoFarmacia departamento)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Entry(departamento).State = EntityState.Modified;
                _conexionDB.SaveChanges();
                return RedirectToAction("EditarDepartamentoFarmaciaGeneral"); // Redireccionar a la acción EditarDepartamentoFarmaciaGeneral
            }

            return View(departamento);
        }












        public IActionResult Proveedor()
        {
            return View();
        }

        public IActionResult VerProveedores()
        {
            var ListaProveedor = _conexionDB.Proveedor.ToList();
            return View(ListaProveedor);
        }

        public IActionResult CrearProveedor()
        {
            return View();
        }

        public IActionResult EliminarProveedor()
        {
            var ListaProveedor = _conexionDB.Proveedor.ToList();
            return View(ListaProveedor);
        }

        [HttpDelete]
        public IActionResult EliminarProveedor(int id)
        {
            var proveedor = _conexionDB.Proveedor.Find(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _conexionDB.Proveedor.Remove(proveedor);
            _conexionDB.SaveChanges();

            return RedirectToAction("VerProveedores");
        }

        [HttpPost]
        public IActionResult CrearProveedor(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Proveedor.Add(proveedor);
                _conexionDB.SaveChanges();
            }

            return RedirectToAction("Proveedor", "Home");
        }

        public IActionResult EditarProveedorGeneral()
        {
            var proveedores = _conexionDB.Proveedor.ToList();

            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        [HttpGet]
        public IActionResult EditarProveedor(int id)
        {
            var proveedor = _conexionDB.Proveedor.Find(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        [HttpPost]
        public IActionResult EditarProveedor(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Entry(proveedor).State = EntityState.Modified;
                _conexionDB.SaveChanges();
                return RedirectToAction("EditarProveedorGeneral");
            }

            return View(proveedor);
        }



        /// <summary>
        /// EMPLEADOS
        /// </summary>
        /// <returns></returns>
        public IActionResult Empleado()
        {
            return View();
        }

        public IActionResult VerEmpleados()
        {
            ViewBag.ListaEmpleados = _conexionDB.EmpleadoFarmacia.ToList();
            return View();
        }

        public IActionResult CrearEmpleado()
        {
            ViewBag.ListaDepartamentos = _conexionDB.DepartamentoFarmacia.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CrearNuevoEmpleado(Models.EmpleadoFarmacia value)
        {

            _conexionDB.EmpleadoFarmacia.Add(value);
            _conexionDB.SaveChanges();


            return RedirectToAction("Proveedor", "Home");
        }

        public IActionResult EliminarEmpleado()
        {
            var listaEmpleados = _conexionDB.EmpleadoFarmacia.ToList();
            return View(listaEmpleados);
        }

        [HttpDelete]
        public IActionResult EliminarEmpleado(int id)
        {
            var empleado = _conexionDB.EmpleadoFarmacia.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            _conexionDB.EmpleadoFarmacia.Remove(empleado);
            _conexionDB.SaveChanges();

            return RedirectToAction("VerEmpleados");
        }



        public IActionResult EditarEmpleadoGeneral()
        {
            var empleados = _conexionDB.EmpleadoFarmacia.ToList();

            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            var empleado = _conexionDB.EmpleadoFarmacia.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoFarmacia empleado)
        {
            if (ModelState.IsValid)
            {
                _conexionDB.Entry(empleado).State = EntityState.Modified;
                _conexionDB.SaveChanges();
                return RedirectToAction("EditarEmpleadoGeneral");
            }

            return View(empleado);
        }








        public IActionResult Medicina()
        {
            var ListaMedicamento = _conexionDB.MedicinaFarmacia.ToList();// traer todos los datos entity framework


            return View(ListaMedicamento);
        }

        [HttpPost]
        public IActionResult CrearMedicina(Models.MedicinaFarmacia Medicina)
        {

            if (ModelState.IsValid)
            {
                _conexionDB.MedicinaFarmacia.Add(Medicina);
                _conexionDB.SaveChanges();
            }

            return RedirectToAction("Medicina", "Home"); // Redirect to the home page

        }
        public IActionResult VentaFarmacia()
        {
            var ListVentaFarmacia = _conexionDB.VentaFarmacia.ToList();// traer todos los datos entity framework


            return View(ListVentaFarmacia);
        }

        //[HttpPost]
        //public IActionResult CrearMedicina(Models.VentaFarmacia VentaFarmacia)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _conexionDB.VentaFarmacia.Add(VentaFarmacia);
        //        _conexionDB.SaveChanges();
        //    }

        //    return RedirectToAction("VentaMedicina", "Home"); // Redirect to the home page

        //}

        public IActionResult DetalleVentaFarmacia()
        {
            var ListaMedicina = _conexionDB.MedicinaFarmacia.ToList();// traer todos los datos entity framework
            var ListaClienteFarmacia = _conexionDB.Cliente.ToList();// traer todos los datos entity framework

            ViewBag.ListaMedicina = ListaMedicina;
            ViewBag.ListaClienteFarmacia = ListaClienteFarmacia;

            return View();
        }

        [HttpPost]
        public IActionResult CrearDetalleVentaFarmacia(Models.DetalleVentaFarmacia DetalleVentaFarmacia)
        {

            if (ModelState.IsValid)
            {
                _conexionDB.DetalleVentaFarmacia.Add(DetalleVentaFarmacia);
                _conexionDB.SaveChanges();
            }

            return RedirectToAction("DetalleVentaMedicina", "Home"); // Redirect to the home page

        }

        [HttpPost]
        public IActionResult CrearVenta(int IDMedicina, int IdCliente, int Cantidad)
        {
            var DetalleMedicina = _conexionDB.MedicinaFarmacia.Find(IDMedicina);


            if (Cantidad > DetalleMedicina.Stock)
            {
                return RedirectToAction("VentaFarmacia");
            }

            DetalleMedicina.Stock -= Cantidad;
            _conexionDB.SaveChanges();



            Models.VentaFarmacia NuevaVenta = new Models.VentaFarmacia();
            NuevaVenta.IdClienteFarmacia = IdCliente;
            NuevaVenta.Fecha = DateTime.Now;
            NuevaVenta.Total = (double)(DetalleMedicina.Precio * Cantidad);

            var NuevoDato = _conexionDB.VentaFarmacia.Add(NuevaVenta);
            _conexionDB.SaveChanges();

            // Ahora puedes acceder al ID del registro creado a través de la propiedad Id
            int idRegistroCreado = NuevaVenta.IdVentaFarmacia;


            Models.DetalleVentaFarmacia Detalle = new DetalleVentaFarmacia();
            Detalle.IDVenta = idRegistroCreado;
            Detalle.IDMedicina = IDMedicina;
            Detalle.Cantidad = Cantidad;
            Detalle.SubTotal = (double)(DetalleMedicina.Precio * Cantidad);
            _conexionDB.DetalleVentaFarmacia.Add(Detalle);
            _conexionDB.SaveChanges();



            // Redirigir a alguna acción después de crear la venta
            return RedirectToAction("Index");
        }
    }
}
