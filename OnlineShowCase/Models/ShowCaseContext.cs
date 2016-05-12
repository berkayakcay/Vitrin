using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OnlineShowCase.Models.Mapping;

namespace OnlineShowCase.Models
{
    public partial class ShowCaseContext : DbContext
    {
        static ShowCaseContext()
        {
            Database.SetInitializer<ShowCaseContext>(null);
        }

        public ShowCaseContext()
            : base("Name=ShowCaseContext")
        {
        }

        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<BarcodeType> BarcodeTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemColor> ItemColors { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<ItemDim> ItemDims { get; set; }
        public DbSet<ItemVariant> ItemVariants { get; set; }
        public DbSet<MainMenu> MainMenus { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BarcodeMap());
            modelBuilder.Configurations.Add(new BarcodeTypeMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new ItemColorMap());
            modelBuilder.Configurations.Add(new ItemDescriptionMap());
            modelBuilder.Configurations.Add(new ItemDimMap());
            modelBuilder.Configurations.Add(new ItemVariantMap());
            modelBuilder.Configurations.Add(new MainMenuMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new PriceMap());
            modelBuilder.Configurations.Add(new PriceTypeMap());
            modelBuilder.Configurations.Add(new StockMap());
            modelBuilder.Configurations.Add(new SubscriberMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
