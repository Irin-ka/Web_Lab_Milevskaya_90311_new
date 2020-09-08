using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Lab_Milevskaya_90311.DAL.Data;
using Web_Lab_Milevskaya_90311.DAL.Entities;

namespace Web_Lab_Milevskaya_90311.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана 
            context.Database.EnsureCreated();

            // проверка наличия ролей 
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin 
                await roleManager.CreateAsync(roleAdmin);
            }

            // проверка наличия пользователей 
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru 
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru 
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin 
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                new DishGroup {GroupName="Салаты"},
                new DishGroup {GroupName="Супы"},
                new DishGroup {GroupName="Основные блюда"},
                new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();
            }

            // проверка наличия объектов 
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                new Dish {DishName="Фруктовая тарелка",
                Description="Большая тарелка с ягодами",
                Calories =200, DishGroupId=4, Image="121.jpg" },
                new Dish {DishName="Блины",
                Description="С ягодами, без сметаны",
                Calories =330, DishGroupId=3, Image="131.jpg" },
                new Dish {DishName="Мороженое",
                Description="Мороженое - 80%, фрукты и ягоды - 20%",
                Calories =635, DishGroupId=4, Image="141.jpg" },
                new Dish {DishName="Стейк из свинины",
                Description="Запеченый на гриле",
                Calories =524, DishGroupId=3, Image="151.jpg" },
                new Dish {DishName="Фруктово-овощная нарезка",
                Description="В комплексе сметанный соус",
                Calories =180, DishGroupId=1, Image="161.jpg" }
                });
                await context.SaveChangesAsync();
            }


        }
    }
}
