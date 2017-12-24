using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Covalence.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ITagService tagService)
        {
            context.Database.Migrate();

            if(context.Users.Any() || context.Tags.Any())
            {
                return;
            }

            var biologyTag = new Tag { Name = "Biology" };
            var physicsTag = new Tag { Name = "Physics" };
            var chemistryTag = new Tag { Name = "chemistry" };

            await context.Tags.AddAsync(biologyTag);
            await context.Tags.AddAsync(physicsTag);
            await context.Tags.AddAsync(chemistryTag);

            await context.SaveChangesAsync();

            var mccreeUser = new ApplicationUser() {
                    Email = "mccree@overwatch.com",
                    UserName = "mccree@overwatch.com",
                    FirstName = "Jesse",
                    LastName = "McCree",
                    Bio = "McCree, full name Jesse McCree, is an American bounty hunter and vigilante with a cybernetic arm and a Wild West motif. He carries his Peacekeeper six-shooter, with its primary fire that can shoot single shots with high accuracy at moderate range, and its alternate fire allowing him to Fan the Hammer to quickly unload the entire cylinder at close range in rapid fire with some loss of accuracy. He can quickly dodge attacks using his Combat Roll ability which also instantly reloads his revolver, and can throw a Flashbang grenade a short distance which stuns enemies and interrupts their abilities. McCree's ultimate ability is Deadeye, which allows him to line up headshots on every enemy in his sight, with resulting damage proportional to the time spent aiming",
                    Location = "87501",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(mccreeUser, "123Abc!");

            await tagService.AddTag(biologyTag, mccreeUser);

            var genjiUser = new ApplicationUser() {
                    Email = "genji@overwatch.com",
                    UserName = "genji@overwatch.com",
                    FirstName = "Genji",
                    LastName = "Shimada",
                    Bio = "Genji, full name Genji Shimada, is a Japanese cyborg ninja. His main attack method is to throw three Shurikens, either in quick succession or simultaneously in a horizontal spread. His abilities are Swift Strike, a quick dashing lunge with good range, and Deflect, a defensive stance that briefly ricochets projectiles back at enemies with his wakizashi. His Cyber-Agility allows him to double-jump and run up walls. Genji's ultimate ability is Dragonblade, which temporarily replaces his shurikens with powerful, sweeping melee attacks dealt by his katana.",
                    Location = "44600",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(genjiUser, "123Abc!");

            await tagService.AddTag(biologyTag, genjiUser);

            var tracerUser = new ApplicationUser() {
                    Email = "tracer@overwatch.com",
                    UserName = "tracer@overwatch.com",
                    FirstName = "Lena",
                    LastName = "Oxton",
                    Bio = "Tracer, real name Lena Oxton, is a British pilot and adventurer. She wields dual rapid-fire Pulse Pistols, and is equipped with a 'chronal accelerator' which grants her the ability to either jump forward in time, crossing many meters in a split second (Blink) or rewind three seconds into the past to heal and restore ammunition (Recall). Her ultimate ability is Pulse Bomb, an explosive charge that sticks to enemies, exploding after a brief delay for massive damage.",
                    Location = "03062",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(tracerUser, "123Abc!");

            await tagService.AddTag(biologyTag, tracerUser);

            var dvaUser = new ApplicationUser() {
                    Email = "dva@overwatch.com",
                    UserName = "dva@overwatch.com",
                    FirstName = "Hana",
                    LastName = "Song",
                    Bio = "D.Va, real name Hana Song, is a South Korean mecha pilot and former pro gamer from Busan. She pilots a combat mecha armed with twin Fusion Cannons, shotgun-like weapons that require no ammunition or reload time. Her mecha is equipped with rocket Boosters for short bursts of flight, as well as a Defense Matrix that allows it to shoot enemy projectiles out of the air. She can also fire a volley of Micro-Missiles that do splash damage on impact.[108] D.Va's ultimate ability, Self-Destruct, overloads and detonates her mecha, dealing massive damage to all enemies in a huge radius within line of sight. If her mech is destroyed (either by her ultimate or in combat), she ejects and continues to fight on foot, armed with a mid-range Light Gun, until her mecha can be summoned again.",
                    Location = "03062",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(dvaUser, "123Abc!");

            await tagService.AddTag(chemistryTag, dvaUser);
            await tagService.AddTag(physicsTag, dvaUser);

            var hanzoUser = new ApplicationUser() {
                    Email = "hanzo@overwatch.com",
                    UserName = "hanzo@overwatch.com",
                    FirstName = "Hanzo",
                    LastName = "Shimada",
                    Bio = "Hanzo, full name Hanzo Shimada, is a Japanese archer, assassin and mercenary. He wields the Storm Bow and is equipped with specialized arrows, including Sonic Arrows to detect enemies and Scatter Arrows to hit multiple targets with ricochets. He is also able to Wall Climb, enabling him to reach vantage points. His ultimate ability is Dragonstrike, in which he unleashes a spiraling spirit dragon that can travel through obstacles to deal damage in a straight line.",
                    Location = "03062",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(hanzoUser, "123Abc!");

            await tagService.AddTag(biologyTag, hanzoUser);

            var meiUser = new ApplicationUser() {
                    Email = "mei@overwatch.com",
                    UserName = "mei@overwatch.com",
                    FirstName = "Mei-Ling",
                    LastName = "Zhou",
                    Bio = "Mei, full name Mei-Ling Zhou (周美灵), is a Chinese climatologist and adventurer from Xi'an. She wields an Endothermic Blaster that can either freeze enemies in place with a short-range spray or shoot a long-range icicle projectile, and she can also use it to Cryo-Freeze herself in a solid ice block to shield herself from damage and heal injuries, as well as erect Ice Walls with many versatile uses, primarily for blocking the enemies. Her ultimate ability is Blizzard, which calls down Snowball, her personal weather modification drone, to freeze all enemies in a wide radius.",
                    Location = "03062",
                    EmailConfirmed = true
                };

            await userManager.CreateAsync(meiUser, "123Abc!");

            await tagService.AddTag(biologyTag, meiUser);

            await context.SaveChangesAsync();
        }
    }
}