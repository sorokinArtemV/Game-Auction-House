using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

public class ItemsDbContext : DbContext
{
    public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
    {
    }

    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Armor> Armors { get; set; }
    public DbSet<Effect> Effects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weapon>().OwnsOne(w => w.PrimaryStats);
        modelBuilder.Entity<Weapon>().OwnsOne(w => w.SecondaryStats);
        modelBuilder.Entity<Weapon>()
            .HasMany(w => w.SpecialEffects)
            .WithOne()
            .HasForeignKey("WeaponId");

        modelBuilder.Entity<Armor>().OwnsOne(w => w.PrimaryStats);
        modelBuilder.Entity<Armor>().OwnsOne(w => w.SecondaryStats);
        modelBuilder.Entity<Armor>()
            .HasMany(w => w.SpecialEffects)
            .WithOne()
            .HasForeignKey("ArmorId");
    }
}

#region OnModelCreatingMethod

/*
public class ItemsDbContext : DbContext
{
    public DbSet<Weapon> Weapons { get; set; }


    public ItemsDbContext(DbContextOptions<ItemsDbContext> options, IWebHostEnvironment env)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Weapon>()
            .HasMany(e => e.SpecialEffects)
            .WithOne(e => e.Weapon)
            .HasForeignKey("WeaponId")
            .IsRequired(false);


        // Configure the Weapon entity
        modelBuilder.Entity<Weapon>().HasKey(w => w.Id);



        modelBuilder.Entity<Weapon>().OwnsOne(w => w.PrimaryStats);
        modelBuilder.Entity<Weapon>().OwnsOne(w => w.SecondaryStats);

        // Seed the Weapon entity
        modelBuilder.Entity<Weapon>().HasData(new Weapon()
        {
            Id = 1,
            WeaponType = WeaponType.Sword.ToString(),
            DamageType = DamageType.Physical.ToString(),
            MinDamage = 250.0,
            MaxDamage = 320.0,
            AttackSpeed = 2.7,
            IsTwoHanded = false,
            IsMainHand = true,
            IsOffHand = false,

            // BaseItem properties
            Name = "Thunderfury, Blessed Blade of the Windseeker",
            Quality = Quality.Legendary.ToString(),
            Description =
                "Once carried by the son of Al'Akir, Thunderaan the Windlord, this blade crackles with the fury of a thousand storms.",
            ItemLevel = 80,
            Icon = "thunderfury_icon.png",
            IsStackable = false,
            StackSize = 1,
            IsBound = true,
            BoundType = BoundType.BindOnPickup.ToString(),
            IsConjured = false,
            IsUnique = true,
            Durability = 120,
            IsQuestItem = false,
            StartsQuest = false,
            RequiredRace = new List<string> { Race.Human.ToString(), Race.Orc.ToString() },
            RequiredClasses = new List<string> { GameClass.Warrior.ToString(), GameClass.Paladin.ToString() },
            RequiredLevel = 60,
            RequiredSkill = new List<string> { WeaponType.Sword.ToString() },
            IsLocked = false,
            IsLootable = true,
        });

        // Seed the PrimaryStats owned type
        modelBuilder.Entity<Weapon>().OwnsOne(w => w.PrimaryStats).HasData(new
        {
            WeaponId = 1,
            Strength = 20,
            Agility = 15,
            Stamina = 5
        });

        // Seed the SecondaryStats owned type
        modelBuilder.Entity<Weapon>().OwnsOne(w => w.SecondaryStats).HasData(new
        {
            WeaponId = 1,
            CriticalStrike = 9,
            AttackPower = 15
        });

        modelBuilder.Entity<Effect>().HasData(new Effect
        {
            Id = 1,
            WeaponId = 1,
            Name = "Lightning Strike",
            Description = "Strikes the enemy with a bolt of lightning, dealing extra electric damage.",
            Charges = 5,
            Duration = TimeSpan.FromMinutes(3),
            IsPassive = false
        });
    }
}
*/

#endregion