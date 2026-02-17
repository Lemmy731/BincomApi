using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Data;
using BincomProjectApi.Repository.Interface;
using Microsoft.AspNetCore.Identity;

namespace BincomProjectApi.Repository.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        public RegisterRepository(AppDbContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public async Task<bool> Register(User user)
        {
            try
            {
                var response = await _userManager.FindByEmailAsync(user.Email);
                if (response == null)
                {
                    var databaseResponse = await _userManager.CreateAsync(user, user.PasswordHash);
                    if (databaseResponse.Succeeded)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
