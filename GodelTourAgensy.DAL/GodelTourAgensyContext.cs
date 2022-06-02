using GodelTourAgensy.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GodelTourAgensy.DAL
{
    public class GodelTourAgensyContext : DbContext
    {
        public DbSet<AdditionalServiceEntity> AdditionalServiceEntitys { get; set; }

        public DbSet<ClientEntity> ClientEntitys { get; set; }

        public DbSet<IntermidiateServiceEntity> IntermidiateServiceEntitys { get; set; }

        public DbSet<RoomEntity> RoomEntitys { get; set; }

        public DbSet<TravelPackageEntity> TravelPackageEntitys { get; set; }


        public GodelTourAgensyContext(DbContextOptions<GodelTourAgensyContext> options) : base(options) { }
    }
}
