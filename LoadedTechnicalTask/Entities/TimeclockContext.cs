using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LoadedTechnicalTask.Entities
{
    public class TimeclockContext : DbContext
    {
        public TimeclockContext(DbContextOptions<TimeclockContext> options)
        : base(options) { }

        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.StaffMember)
                .WithMany(e => e.Timesheets)
                .HasForeignKey(e => e.StaffMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
