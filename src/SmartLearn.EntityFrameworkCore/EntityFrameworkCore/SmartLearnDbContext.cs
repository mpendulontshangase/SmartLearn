using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SmartLearn.Authorization.Roles;
using SmartLearn.Authorization.Users;
using SmartLearn.MultiTenancy;
using SmartLearn.Domain;

namespace SmartLearn.EntityFrameworkCore
{
    public class SmartLearnDbContext : AbpZeroDbContext<Tenant, Role, User, SmartLearnDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> Persons { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<HomeworkRecord> HomeworkRecords { get; set; }
        public DbSet<TestRecord> TestRecords { get; set; }

        public SmartLearnDbContext(DbContextOptions<SmartLearnDbContext> options)
            : base(options)
        {
        }
     
    }
}
