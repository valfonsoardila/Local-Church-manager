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
                command.CommandText = "Insert Into PRESUPUESTO(Id, FechaPresupuesto, Comite, Ofrenda, Actividad, Voto, TotalPresupuesto) Values (@Id, @FechaPresupuesto, @Comite, @Ofrenda, @Actividad, @Voto, @TotalPresupuesto)";
                command.Parameters.AddWithValue("@Id", presupuesto.Id);
                command.Parameters.AddWithValue("@FechaPresupuesto", presupuesto.FechaPresupuesto);
                command.Parameters.AddWithValue("@Comite", presupuesto.Comite);
                command.Parameters.AddWithValue("@Ofrenda", presupuesto.Ofrenda);
                command.Parameters.AddWithValue("@Actividad", presupuesto.Actividad);
                command.Parameters.AddWithValue("@Voto", presupuesto.Voto);
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
                command.CommandText = "Select Id, FechaPresupuesto, Comite, Ofrenda, Actividad, Voto, TotalPresupuesto from PRESUPUESTO";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Presupuesto presupuesto = DataReaderMapToEgreso(dataReader);
                        presupuestos.Add(presupuesto);
                    }
                }
            }
            return presupuestos;
        }
        public List<Presupuesto> FiltrarIngresosPorComite(string comite)
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
                        Presupuesto presupuesto = DataReaderMapToEgreso(dataReader);
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
        //                Presupuesto presupuesto = DataReaderMapToEgreso(dataReader);
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
                return DataReaderMapToEgreso(dataReader);
            }
        }
        public void Modificar(Presupuesto presupuesto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"update PRESUPUESTO set FechaPresupuesto=@FechaPresupuesto, Comite=@Comite, Ofrenda=@Ofrenda, Actividad=@Actividad, Voto=@Voto, TotalPresupuesto=@TotalPresupuesto
                                        where Id=@Id";
                command.Parameters.AddWithValue("@FechaPresupuesto", presupuesto.FechaPresupuesto);
                command.Parameters.AddWithValue("@Comite", presupuesto.Comite);
                command.Parameters.AddWithValue("@Actividad", presupuesto.Actividad);
                command.Parameters.AddWithValue("@Voto", presupuesto.Voto);
                command.Parameters.AddWithValue("@TotalPresupuesto", presupuesto.TotalPresupuesto);
                var filas = command.ExecuteNonQuery();
            }
        }
        private Presupuesto DataReaderMapToEgreso(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Presupuesto presupuesto = new Presupuesto();
            presupuesto.Id = (int)dataReader["Id"];
            presupuesto.FechaPresupuesto = (DateTime)dataReader["FechaPresupuesto"];
            presupuesto.Comite = (string)dataReader["Comite"];
            presupuesto.Ofrenda = (int)dataReader["Ofrenda"];
            presupuesto.Actividad = (int)dataReader["Actividad"];
            presupuesto.Voto = (int)dataReader["Voto"];
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
