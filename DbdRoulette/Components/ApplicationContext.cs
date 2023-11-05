using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<User> User { get; set; }

        public DbSet<Killer> Killer { get; set; }

        public DbSet<Survivor> Survivor { get; set; }

        public DbSet<Chapter> Chapter { get; set; }

        public DbSet<ChapterType> ChapterType { get; set; }

        public DbSet<Difficulty> Difficulty { get; set; }

        public DbSet<Perk> Perk { get; set; }
    }

}