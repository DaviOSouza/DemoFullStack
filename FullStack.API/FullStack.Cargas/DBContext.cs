using System.Collections.Generic;
using FullStack.Cargas.Model;
using Microsoft.EntityFrameworkCore;

public class FullStackContext: DbContext { 
    public DbSet<Produto> Produto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
