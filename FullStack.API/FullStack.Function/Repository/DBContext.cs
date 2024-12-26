using System.Collections.Generic;
using FullStack.Function.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class FullStackContext: DbContext {

    IConfiguration _configuration;
    public FullStackContext(IConfiguration configuration)
    {
        _configuration = configuration;

    }
    public DbSet<Produto> Produto { get; set; }

    public DbSet<Cliente> Cliente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = _configuration["dbConection"];
        optionsBuilder.UseSqlServer(con);
    }
}
