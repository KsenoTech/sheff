using WebSheff.ApplicationCore.Models;

namespace WebSheff.Data
{
    public static class SheffContextSeed
    {
        public static async Task SeedAsync(SheffContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                // Если в таблицах уже есть данные, то выходим
                if (context.Users.Any() || context.ProvidedServices.Any() || context.Smetas.Any())
                {
                    return;
                }

                await SeedUsersAsync(context);
                await SeedProvidedServicesAsync(context);
                await SeedSmetaAsync(context);
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла ошибка при инициализации базы данных.", ex);
            }
        }

        private static async Task SeedUsersAsync(SheffContext context)
        {
            var users = new User[]
            {
                new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "john@example.com",
                    Password = "password123",
                    Address = "123 Main St",
                    TelephoneNumber = "123-456-7890",
                    KolvoZakazov = 0,
                    Rating = 4.5,
                    MiddleName = "Middle"
                    //Login = "johndoe"
                },
                new User
                {
                    Id = 2,
                    Name = "Alice",
                    Surname = "Smith",
                    Email = "alice@example.com",
                    Password = "password456",
                    Address = "456 Elm St",
                    TelephoneNumber = "456-789-0123",
                    KolvoZakazov = 0,
                    Rating = 4.0,
                    MiddleName = "Marie"
                   // Login = "alicesmith"
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedProvidedServicesAsync(SheffContext context)
        {
            var providedServices = new ProvidedService[]
            {
                new ProvidedService
                {
                    Id = 1,
                    Title = "Service 1",
                    Description = "Description for service 1",
                    CostOfM = 50,
                    CostOfM2 = 75
                },
                new ProvidedService
                {
                    Id = 2,
                    Title = "Service 2",
                    Description = "Description for service 2",
                    CostOfM = 60,
                    CostOfM2 = 80
                }
            };

            foreach (var service in providedServices)
            {
                context.ProvidedServices.Add(service);
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedSmetaAsync(SheffContext context)
        {
            var smetas = new Smeta[]
            {
                new Smeta
                {
                    Id = 1,
                    IdClient = 1,
                    IdExecutor = 2,
                    TimeOrder = DateTime.Now,
                    GeneralBudget = 1000,
                    CanIdoIt = true,
                    Description = "Description for Smeta 1",
                    FeedbackText = "Feedback for Smeta 1"
                },
                new Smeta
                {
                    Id = 2,
                    IdClient = 2,
                    IdExecutor = 1,
                    TimeOrder = DateTime.Now.AddDays(-1),
                    GeneralBudget = 1500,
                    CanIdoIt = false,
                    Description = "Description for Smeta 2",
                    FeedbackText = "Feedback for Smeta 2"
                }
            };

            foreach (var smeta in smetas)
            {
                context.Smetas.Add(smeta);
            }

            await context.SaveChangesAsync();
        }
    }
}
