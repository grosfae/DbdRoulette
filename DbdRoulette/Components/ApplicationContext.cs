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
        public DbSet<PerkTextTag> PerkTextTag { get; set; }
        public DbSet<TextTag> TextTag { get; set; }
        public DbSet<SurvivorPerk> SurvivorPerk { get; set; }
        public DbSet<KillerPerk> KillerPerk { get; set; }
        public DbSet<Power> Power { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<PowerItem> PowerItem { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<MapGallery> MapGallery { get; set; }
        public DbSet<Rarity> Rarity { get; set; }
        public DbSet<Charm> Charm { get; set; }
        public DbSet<CharmType> CharmType { get; set; }
        public DbSet<CosmeticType> CosmeticType { get; set; }
        public DbSet<ChapterCharm> ChapterCharm { get; set; }
        public DbSet<CosmeticOutfit> CosmeticOutfit { get; set; }
        public DbSet<BodyPart> BodyPart { get; set; }
        public DbSet<SurvivorCosmeticOutfit> SurvivorCosmeticOutfit { get; set; }
        public DbSet<KillerCosmeticOutfit> KillerCosmeticOutfit { get; set; }
        public DbSet<ThematicCollection> ThematicCollection { get; set; }
        public DbSet<Effect> Effect { get; set; }
        public DbSet<PerkEffect> PerkEffect { get; set; }
        public DbSet<Addon> Addon { get; set; }
        public DbSet<AddonEffect> AddonEffect { get; set; }
        public DbSet<AddonItemType> AddonItemType { get; set; }
    }

}