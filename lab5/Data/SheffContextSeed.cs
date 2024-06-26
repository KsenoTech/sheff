﻿using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.Data
{
    public static class SheffContextSeed
    {
        public static async Task SeedAsync(SheffContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Useras.Any())
                {
                    return;
                }
                else
                {
                    await SeedUsersAsync(context);
                }

                if (context.ProvidedServices.Any())
                {
                    return;
                }
                else
                {
                    await SeedProvidedServicesAsync(context);
                }

                if (context.Smeta.Any())
                {
                    return;
                }
                else
                {
                    await SeedSmetaAsync(context);
                }

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
                    Name = "John",
                    Surname = "Doe",
                    UserLogin =  "John",
                    UserName =  "John",
                    Email = "john@example.com",
                    EMail = "john@example.com",
                    Password = "password123",
                    Address = "123 Main St",
                    TelephoneNumber = "123-456-7890",
                    KolvoZakazov = 0,
                    Rating = 4.5,
                    MiddleName = "Middle",
                    NormalizedEmail = "john@example.com",
                    NormalizedUserName = "John".ToUpper()
                },
                new User
                {
                    Name = "Alice",
                    Surname = "Smith",
                    UserLogin = "Alice",
                    UserName = "Alice",
                    Email = "john@example.com",
                    EMail = "alice@example.com",
                    Password = "password456",
                    Address = "456 Elm St",
                    TelephoneNumber = "456-789-0123",
                    KolvoZakazov = 0,
                    Rating = 4.0,
                    MiddleName = "Marie",
                    NormalizedEmail = "john@example.com",
                    NormalizedUserName = "Alice".ToUpper()
                }
            };

            foreach (var user in users)
            {
                context.Useras.Add(user);
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedProvidedServicesAsync(SheffContext context)
        {
            var providedServices = new ProvidedService[]
            {
                new ProvidedService
                {

                    Title = "Service 1",
                    Description = "Description for service 1",
                    CostOfM = 50,
                    CostOfM2 = 75
                },
                new ProvidedService
                {

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
            var smetas = new Smetum[]
            {
                new Smetum
                {
                    TimeOrder = DateTime.Now,
                    GeneralBudget = 1000,
                    CanIdoIt = true,
                    Description = "Description for Smeta 1",
                    FeedbackText = "Feedback for Smeta 1"
                },
                new Smetum
                {
                    TimeOrder = DateTime.Now.AddDays(-1),
                    GeneralBudget = 1500,
                    CanIdoIt = false,
                    Description = "Description for Smeta 2",
                    FeedbackText = "Feedback for Smeta 2"
                }
            };

            foreach (var smeta in smetas)
            {
                context.Smeta.Add(smeta);
            }

            await context.SaveChangesAsync();
        }
    }
}
