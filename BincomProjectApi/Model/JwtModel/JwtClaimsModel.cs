namespace BincomProjectApi.Model.JwtModel
{
    public class JwtClaimsModel
    {
        public string Id { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateTime IssuedAt { get; init; } = DateTime.UtcNow;
    }
}
