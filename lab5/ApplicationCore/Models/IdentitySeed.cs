using Microsoft.AspNetCore.Identity;

namespace WebSheff.ApplicationCore.Models
{
    public static class IdentitySeed
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            
            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            // Создание Администратора
            string adminUserName = "klmadmin";
            string adminPassword = "SWAGger2985!?(-_-)";

            string adminSurname = "Ksenofontov";
            string adminName = "Lev";
            string adminMiddleName = "Michalych";

            string adminEmail = "klmych@mail.ru";
            string adminAddress = "CanYouFindMe?";
            string adminTelephoneNumber = "89203776291";
         
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Surname = adminSurname,
                    Name = adminName,
                    MiddleName = adminMiddleName,
                    Email = adminEmail,
                    Address = adminAddress,
                    TelephoneNumber = adminTelephoneNumber,
                    UserName = adminUserName,
                    Password = adminPassword,
                    PasswordConfirm = adminPassword
                };
                //добавить 
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            // Создание Пользователя
            string userUserName = "user";
            string userPassword = "Userr1!";
                   
            string userSurname = "Surname";
            string userName = "Name";
            string userMiddleName = "MiddleName";
                   
            string userEmail = "example@mail.ru";
            string userAddress = "CanYouFindMe?";
            string userTelephoneNumber = "81234567890";

            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User
                {
                    Surname = userSurname,
                    Name = userName,
                    MiddleName = userMiddleName,
                    Email = userEmail,
                    Address = userAddress,
                    TelephoneNumber = userTelephoneNumber,
                    UserName = userUserName,
                    Password = userPassword,
                    PasswordConfirm = userPassword
                };

                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }

    }
}
