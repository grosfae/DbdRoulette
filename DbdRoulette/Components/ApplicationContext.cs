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
        public DbSet<User> Users { get; set; }

        public DbSet<Killer> Killers { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<ChapterType> ChapterTypes { get; set; }

        public DbSet<KillerChapter> KillerChapters { get; set; }
    }

}