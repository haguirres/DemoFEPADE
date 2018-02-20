using Demo.Modelo;
using System.Collections.Generic;
using System.Linq;

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

        public List<TransactionHistory> ObtenerHistorial()
        {
            List<TransactionHistory> listaTransacciones = new List<TransactionHistory>();

            using (var contexto = new AdventureWorksConnection())
            {
                listaTransacciones = contexto.TransactionHistory.ToList();
            }
            return listaTransacciones;
        }
    }
}