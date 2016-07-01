using Application.DAL.Entities;
using System.Data.Entity;

namespace Application.DAL.EF
{
    public class AppContext : DbContext
    {
        AppContext()
           : base("name=DbConnectionString")
        {

        }
        //передача строки подключения
        public AppContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new StoreDbInitializer());
        }


        //инициализация данных
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
        {
            protected override void Seed(AppContext db)
            {
                db.Dishes.Add(new DishEntity { Name = "Курица «Пикассо»", Ingredients = "Курица Сладкий перец Соль Черный перец", Weight = 220 });
                db.Dishes.Add(new DishEntity { Name = "Азу по‑татарски", Ingredients = "Говядина Лук сооленые огурцы Соль Черный перец", Weight = 220 });
                db.Organizations.Add(new OrganizationEntity { Name = "Сити-Фуд", Address = "ул.Пономаренко, 35а", Phone = 80292566745, Email = null });
                db.Organizations.Add(new OrganizationEntity { Name = "Buon Appеtito", Address = "ул. Орловская 66", Phone = 80293208000, Email = null });

                db.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
           foreach (var type in typesToRegister)
           {
               dynamic configurationInstance = Activator.CreateInstance(type);
               modelBuilder.Configurations.Add(configurationInstance);
           }*/

            //токен оптимистичного параллелизма ?????????????????????
            //CLR????
            //(TPC)????
            base.OnModelCreating(modelBuilder);


            //Dish
            modelBuilder.Entity<DishEntity>().HasKey(k => k.Id);//ключ

            modelBuilder.Entity<DishEntity>()
                   .HasMany<MenuEntity>(s => s.Menus)
                   .WithRequired(s => s.Dish)
                   .HasForeignKey(s => s.DishId);


            modelBuilder.Entity<DishEntity>().Property(t => t.Ingredients).HasMaxLength(200).IsRequired().HasColumnType("nvarchar");//макс длинна обязательно строка
            modelBuilder.Entity<DishEntity>().Property(t => t.Name).HasMaxLength(50).IsRequired().HasColumnType("nvarchar");//макс длинна обязательно строка
            modelBuilder.Entity<DishEntity>().Property(t => t.Weight).IsRequired().HasColumnType("int");//макс длинна обязательно int

            //Organization

            modelBuilder.Entity<OrganizationEntity>()
                .HasMany<MenuEntity>(s => s.Menus)
                .WithRequired(s => s.Organization)
                .HasForeignKey(s => s.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasKey(k => k.Id);//ключ
            modelBuilder.Entity<OrganizationEntity>().Property(t => t.Address).HasMaxLength(200).IsRequired().HasColumnType("nvarchar");//макс длинна обязательно строка
            modelBuilder.Entity<OrganizationEntity>().Property(t => t.Email).HasMaxLength(200).HasColumnType("nvarchar");//макс длинна обязательно строка
            modelBuilder.Entity<OrganizationEntity>().Property(t => t.Name).HasMaxLength(50).HasColumnType("nvarchar");//макс длинна не обязательно строка
            modelBuilder.Entity<OrganizationEntity>().Property(t => t.Phone).IsRequired().HasColumnType("long");//макс длинна не обязательно int

            //Menu
            modelBuilder.Entity<MenuEntity>().HasKey(k => k.Id)
                    .HasRequired<DishEntity>(s => s.Dish)
                    .WithMany(s => s.Menus)
                    .HasForeignKey(s => s.Dish);

            modelBuilder.Entity<MenuEntity>()
                    .HasRequired<OrganizationEntity>(s => s.Organization)
                    .WithMany(s => s.Menus)
                    .HasForeignKey(s => s.OrganizationId)
                    ;//ключ

            modelBuilder.Entity<MenuEntity>().Property(t => t.Date).IsRequired().HasColumnType("datetime");//макс длинна обязательно дата
            modelBuilder.Entity<MenuEntity>().Property(t => t.OrganizationId).HasColumnName("Organization");
            modelBuilder.Entity<MenuEntity>().Property(t => t.DishId).IsRequired().HasColumnName("Dish");






        }
        //?
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }



    }
}
