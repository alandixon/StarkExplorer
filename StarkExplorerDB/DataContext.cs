using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using StarkExplorerLib.Artefacts;

namespace StarkExplorerDB
{
    public class DataContext : DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "StarkExplorer.db");
        }

        // Create a Sqlite database file in the local folder.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

}
