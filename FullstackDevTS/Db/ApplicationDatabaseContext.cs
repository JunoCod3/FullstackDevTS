using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FullstackDevTS.Jwt;
using FullstackDevTS.Models.Entities;

namespace FullstackDevTS.Db;

public class ApplicationDatabaseContext : IdentityDbContext<JwtIdentity>
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    } //Warning: Redundant since no modified implementation
    
    //Models Registration....
    public DbSet<TestModel> TestModels { get; set; }
    public DbSet<CategoryModel> CategoryModels { get; set; }
}