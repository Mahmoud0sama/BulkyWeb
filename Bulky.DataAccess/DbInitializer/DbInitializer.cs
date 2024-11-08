using Bulky.Models;
using Bulky.Utility;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly AppDbContext _db;
		
		public DbInitializer(
			UserManager<IdentityUser> userManager, 
			RoleManager<IdentityRole> roleManager,
			AppDbContext db)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_db = db;
		}
		

		
			
			
		public void Initialize()
		{
			//migration if they are not applied
			try
			{
				if(_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}
			}
			catch (Exception ex)
			{

			}
			//ceate roles if they are not created
			if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

				//if roles not created then we create an admin user as well
				_userManager.CreateAsync(new ApplicationUser
				{
					UserName = "AdminUser@gmail.com",
					Email = "AdminUser@gmail.com",
					Name = "AdminUser",
					PhoneNumber = "1112223333",
					StreetAddress = "12 st",
					State = "Il",
					PostalCode = "23422",
					City = "LA"
				}, "Admin123*").GetAwaiter().GetResult();
				ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "AdminUser@gmail.com");
				_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
			}
			return;
		}
	}
}
