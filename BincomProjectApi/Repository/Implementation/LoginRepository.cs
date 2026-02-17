using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Data;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.JWT.Interface;
using BincomProjectApi.Shared.GenericResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BincomProjectApi.Repository.Implementation
{
    public class LoginRepository: ILoginRepository
    {   
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public LoginRepository(AppDbContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public async Task<ApiResponse<User>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return ApiResponse<User>.Failure(StatusCodes.Status404NotFound, "user not found");
                }
                var checkPassWord = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (checkPassWord)
                {
                    return ApiResponse<User>.Success("user found", user); ;
                }
                return ApiResponse<User>.Failure(StatusCodes.Status500InternalServerError, "error"); 
            }
            catch (Exception ex) 
            {
                return ApiResponse<User>.Failure(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
