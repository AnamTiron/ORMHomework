using MatrimonialAgency.Models;
using MatrimonialAgency.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialAgency.Context
{
    class AgencyContext : DbContext
    {
        public AgencyContext() : base("Agency")
        {
            Init();
        }

        public void Init()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Passion> Passions { get; set; }
        public DbSet<Gender> Genders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            ApplyCustomConventions(modelBuilder);
         
            modelBuilder.Entity<Member>().HasMany(p => p.Passions).WithMany()
                .Map(ms =>
                {
                    ms.MapLeftKey("MemberId");
                    ms.MapRightKey("PassionId");
                    ms.ToTable("MemberPassion", "Agency");
                });



            modelBuilder.Entity<Member>()
                        .Property(t => t.Email)
                         .HasColumnAnnotation("Index",
                         new IndexAnnotation(
                        new IndexAttribute("IX_Email")
                         {IsUnique = true}));

        
            modelBuilder.Entity<Member>()
                        .Property(t => t.LastName)
                        .HasColumnAnnotation(
                        "Index",
                        new IndexAnnotation(new IndexAttribute("IX_LastName") { IsUnique = false }));


        }


        private void ApplyCustomConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(10, 2));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(150));
        }

      
    }
}


