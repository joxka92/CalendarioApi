using Infrastructure.Services.UnitOfWork;
using Infrastructure.Support;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Services.StoredProcedure
{
    public class StoredProcedure : IStoredProcedure
    {
        private readonly IUnitOfWork _uow;
        public StoredProcedure(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public bool Execute(string sp, params object[] parameters)
        {
            try
            {
                string cmd = $"{sp} {string.Join(",", parameters.Select(item => item ?? "null"))}";
                int rowsAffected = _uow.Context.Database.ExecuteSqlRaw(cmd);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteOut(string sp, string Salida, params object[] parameters )
        {
            try
            {
                var cantidadParam = new SqlParameter
                {
                    ParameterName = $"@{Salida}",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };
                string cmd = $"{sp} {string.Join(",", parameters.Select(item => item ?? "null"))} , @{Salida} OUTPUT";
                int rowsAffected = _uow.Context.Database.ExecuteSqlRaw(cmd , cantidadParam);

                int cantidad = (int)cantidadParam.Value;

                return cantidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

   



        public bool ExecuteImage(string sp, params object[] parameters)

        {
            try
            {

                object[] paramItems = new object[]
                {
                    new SqlParameter("@ext", parameters[0]),
                    new SqlParameter("@file", parameters[1]),
                    new SqlParameter("@idUsuario",parameters[2]),
                    new SqlParameter("@Id", parameters[3]),
                };
                string cmd = $"exec {sp} @ext, @file, @idUsuario, @Id ";
                int rowsAffected = _uow.Context.Database.ExecuteSqlRaw(cmd, paramItems);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IEnumerable<T> GetCollection<T>(string sp, params object[] parameters) where T : class
        {
            try
            {
                var set = _uow.Context.Set<T>();
                return set.FromSqlRaw<T>($"{sp} {string.Join(",", parameters?.Select(item => item ?? "null"))}").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T GetSingleElement<T>(string sp, params object[] parameters) where T : class
        {
            try
            {
                var set = _uow.Context.Set<T>();
                return set.FromSqlRaw<T>($"{sp} {string.Join(",", parameters.Select(item => item ?? "null"))}").AsEnumerable().SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
