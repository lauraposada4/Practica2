using ScientificResearch.API.Helpers;
using ScientificResearch.Shared.Entities;
using ScientificResearch.Shared.Enums;
using System.Diagnostics.Eventing.Reader;
using Azure.Identity;
using Azure;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ScientificResearch.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await ChecksearchActivitiesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("Laura", "Tecnología", "Universidades", "lauraposada@gmail.com", UserType.Admin);




        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }



        private async Task<User> CheckUserAsync( string name, string specialty, string membership, string email, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {

                user = new User
                {
                   
                    Name = name,
                    Specialty = specialty,
                    Membership = membership,
                    Email = email,
                    UserName = email,
                    UserType = userType,
                };

                await _userHelper.AdduserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task ChecksearchActivitiesAsync()
        {
            if (!_context.searchActivities.Any())
            {
                _context.searchActivities.Add(new searchActivity { Name = "Estudios de caso" });
                _context.searchActivities.Add(new searchActivity { Name = "Análisis estadístico" });
                _context.searchActivities.Add(new searchActivity { Name = "Encuestas y cuestionarios" });
                _context.searchActivities.Add(new searchActivity { Name = "Experimentos controlados" });

            }



            await _context.SaveChangesAsync();

        }
    }
}
