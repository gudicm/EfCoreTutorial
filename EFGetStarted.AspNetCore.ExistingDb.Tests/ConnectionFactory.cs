
using EFGetStarted.AspNetCore.ExistingDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace EFGetStarted.AspNetCore.ExistingDb.Tests
{
    public class ConnectionFactory : IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public BloggingContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<BloggingContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new BloggingContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        public BloggingContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<BloggingContext>().UseSqlite(connection).Options;

            var context = new BloggingContext(option);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            return context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
