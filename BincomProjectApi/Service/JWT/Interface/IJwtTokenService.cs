using BincomProjectApi.Model.JwtModel;

namespace BincomProjectApi.Service.JWT.Interface
{
    public interface IJwtTokenService
    {
        string GenerateAccessTokenAsync(JwtClaimsModel claims);
    }
}
