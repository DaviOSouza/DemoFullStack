using System.Collections.Generic;
using FullStack.Cargas.Model;
using Microsoft.EntityFrameworkCore;

public class FullStackContext: DbContext { 
    public DbSet<Produto> Produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        @"Server=tcp:dbfullstackdemo.database.windows.net,1433;Initial Catalog=dbdemo;Persist Security Info=False;User ID=davisouza;Password=Davi.O.S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");    
        }
}
