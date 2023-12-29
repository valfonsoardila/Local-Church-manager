using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PresupuestoRepository
    {
        private readonly SqlConnection _connection;
        public PresupuestoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Presupuesto presupuesto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into PRESUPUESTO(Id, FechaPresupuesto, InicioIntervalo, FinIntervalo, Comite, Ofrenda, Actividad, Voto, TotalPresupuesto) Values (@Id, @FechaPresupuesto, @Comite, @Ofrenda, @Actividad, @Voto, @TotalPresupuesto)";
                command.Parameters.AddWithValue("@Id", presupuesto.Id);
                command.Parameters.AddWithValue("@AnoPresupuesto", presupuesto.AñoPresupuesto);
                command.Parameters.AddWithValue("@InicioIntervalo", presupuesto.InicioIntervalo);
                command.Parameters.AddWithValue("@FinIntervalo", presupuesto.FinIntervalo);
                command.Parameters.AddWithValue("@Comite", presupuesto.Comite);
                command.Parameters.AddWithValue("@Ofrenda", presupuesto.Ofrenda);
                command.Parameters.AddWithValue("@Actividad", presupuesto.Actividad);
                command.Parameters.AddWithValue("@Voto", presupuesto.Voto);
                command.Parameters.AddWithValue("@TotalEgresos", presupuesto.TotalEgresos);
                command.Parameters.AddWithValue("@TotalPresupuesto", presupuesto.TotalPresupuesto);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Presupuesto presupuesto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from PRESUPUESTO where Id=@Id";
                command.Parameters.AddWithValue("@Id", presupuesto.Id);
                command.ExecuteNonQuery();
            }
        }
        public List<Presupuesto> ConsultarTodos()
        {
            List<Presupuesto> presupuestos = new List<Presupuesto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select Id, AnoPresupuesto, InicioIntervalo, FinIntervaloComite, Ofrenda, Actividad, Voto, TotalEgresos, TotalPresupuesto from PRESUPUESTO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Presupuesto presupuesto = DataReaderMapToPresupuesto(dataReader);
                        presupuestos.Add(presupuesto);
                    }
                }
            }
            return presupuestos;
        }
        public List<Presupuesto> FiltrarPresupuestosPorComite(string comite)
        {
            List<Presupuesto> presupuestos = new List<Presupuesto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from PRESUPUESTO where Comite=@Comite";
                command.Parameters.AddWithValue("@Comite", comite);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Presupuesto presupuesto = DataReaderMapToPresupuesto(dataReader);
                        presupuestos.Add(presupuesto);
                    }
                }
            }
            return presupuestos;
        }
        //public List<Presupuesto> FiltrarEgresosPorConcepto(string concepto)
        //{
        //    List<Presupuesto> presupuestos = new List<Presupuesto>();
        //    using (var command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "select * from PRESUPUESTO where Ofrenda=@Ofrenda";
        //        command.Parameters.AddWithValue("@Ofrenda", concepto);
        //        var dataReader = command.ExecuteReader();
        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                Presupuesto presupuesto = DataReaderMapToPresupuesto(dataReader);
        //                presupuestos.Add(presupuesto);
        //            }
        //        }
        //    }
        //    return presupuestos;
        //}
        public Presupuesto BuscarPorIdentificacion(int id)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from PRESUPUESTO where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPresupuesto(dataReader);
            }
        }
        public void Modificar(Presupuesto presupuesto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update PRESUPUESTO set AnoPresupuesto=@AnoPresupuesto, Comite=@Comite, Ofrenda=@Ofrenda, Actividad=@Actividad, Voto=@Voto, TotalPresupuesto=@TotalPresupuesto
                                        where Id=@Id";
                command.Parameters.AddWithValue("@AnoPresupuesto", presupuesto.AñoPresupuesto);
                command.Parameters.AddWithValue("@InicioIntervalo", presupuesto.InicioIntervalo);
                command.Parameters.AddWithValue("@FinIntervalo", presupuesto.FinIntervalo);
                command.Parameters.AddWithValue("@Comite", presupuesto.Comite);
                command.Parameters.AddWithValue("@Actividad", presupuesto.Actividad);
                command.Parameters.AddWithValue("@Voto", presupuesto.Voto);
                command.Parameters.AddWithValue("@TotalEgresos", presupuesto.TotalEgresos);
                command.Parameters.AddWithValue("@TotalPresupuesto", presupuesto.TotalPresupuesto);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Presupuesto DataReaderMapToPresupuesto(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Presupuesto presupuesto = new Presupuesto();
            presupuesto.Id = (int)dataReader["Id"];
            presupuesto.AñoPresupuesto = (string)dataReader["AnoPresupuesto"];
            presupuesto.InicioIntervalo = (string)dataReader["InicioIntervalo"];
            presupuesto.FinIntervalo = (string)dataReader["FinIntervalo"];
            presupuesto.Comite = (string)dataReader["Comite"];
            presupuesto.Ofrenda = (int)dataReader["Ofrenda"];
            presupuesto.Actividad = (int)dataReader["Actividad"];
            presupuesto.Voto = (int)dataReader["Voto"];
            presupuesto.TotalEgresos = (int)dataReader["TotalEgresos"];
            presupuesto.TotalPresupuesto = (int)dataReader["TotalPresupuesto"];
            return presupuesto;
        }
        public int Totalizar()
        {
            return ConsultarTodos().Count();
        }
        public int TotalizarTipo(string tipo)
        {
            return ConsultarTodos().Where(p => p.Comite.Equals(tipo)).Count();
        }
    }
}
