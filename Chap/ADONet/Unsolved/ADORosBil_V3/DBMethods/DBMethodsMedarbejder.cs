using ADORosBil.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADORosBil.DBMethods
{
    internal class DBMethodsMedarbejder : DBMethodsBase<Medarbejder>
    {
        public DBMethodsMedarbejder(string connectionString) 
        : base(connectionString, "Medarbejder", $"(@Id , @Navn)")
        {
        }

        protected override void AddParameterValues(SqlCommand cmd, Medarbejder medarbejder)
        {
            cmd.Parameters.AddWithValue("@Id",medarbejder.Id);
            cmd.Parameters.AddWithValue("@Navn", medarbejder.Navn);
           
        }

        protected override Medarbejder GetRow(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string navn = reader.GetString(reader.GetOrdinal("Navn"));
            return new Medarbejder(id, navn);
        }
    }
}
