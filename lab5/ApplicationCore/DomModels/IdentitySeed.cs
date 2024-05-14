using Microsoft.AspNetCore.Identity;

namespace WebSheff.ApplicationCore.DomModels
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

            if (await roleManager.FindByNameAsync("executor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("executor"));
            }

            #region Создание Администратора
            string adminUserLogin = "klmadmin";
            string adminPassword = "SWAGger2985!?(-_-)";

            string adminSurname = "Ksenofontov";
            string adminName = "Lev";
            string adminMiddleName = "Michalych";

            string adminEmail = "klmych@mail.ru";
            string adminAddress = "CanYouFindMe?";
            string adminTelephoneNumber = "89203776291";
            #endregion
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                User admin = new User
                {
                    Surname = adminSurname,
                    Name = adminName,
                    MiddleName = adminMiddleName,
                    Email = adminEmail,
                    EMail = adminEmail,
                    Address = adminAddress,
                    TelephoneNumber = adminTelephoneNumber,
                    UserLogin = adminUserLogin,
                    UserName = adminUserLogin,
                    Password = adminPassword,
                    PasswordConfirm = adminPassword,
                    NormalizedEmail = adminEmail,
                };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            #region Создание Пользователя
            string userLoginName = "useqr";
            string userPassword = "User12r1!";
                   
            string userSurname = "Surname";
            string userName = "Name";
            string userMiddleName = "MiddleName";
                   
            string userEmail = "example@mail.ru";
            string userAddress = "CanYouFindMe?";
            string userTelephoneNumber = "81234567890";
            #endregion
            var existingUser = await userManager.FindByEmailAsync(userEmail);
            if (existingUser == null)
            {
                User user = new User
                {
                    Surname = userSurname,
                    Name = userName,
                    MiddleName = userMiddleName,
                    Email = userEmail,
                    EMail = userEmail,
                    Address = userAddress,
                    TelephoneNumber = userTelephoneNumber,
                    UserLogin = userLoginName,
                    UserName = userLoginName,
                    Password = userPassword,
                    PasswordConfirm = userPassword,
                    NormalizedEmail = userEmail
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
