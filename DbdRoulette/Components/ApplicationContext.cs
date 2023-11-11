﻿using System;
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
        public DbSet<PerkType> PerkType { get; set; }
        public DbSet<SurvivorPerk> SurvivorPerk { get; set; }
        public DbSet<KillerPerk> KillerPerk { get; set; }
        public DbSet<Power> Power { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<PowerItem> PowerItem { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<MapGallery> MapGallery { get; set; }
        public DbSet<Rarity> Rarity { get; set; }
        public DbSet<Charm> Charm { get; set; }
        public DbSet<CharmType> CharmType { get; set; }
        public DbSet<CharmCollection> CharmCollection { get; set; }
        public DbSet<ChapterCharm> ChapterCharm { get; set; }
    }

}