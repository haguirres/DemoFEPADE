using Demo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Datos
{
    public class AdministradorSQL
    {
        public List<Employee> ObtenerEmpleados()
        {
            List<Employee> listaEmpleados = new List<Employee>();
            using (var contexto = new AdventureWorksConnection())
            {
                listaEmpleados = contexto.Employee.ToList();
            }
            return listaEmpleados;
        }
    }
}
