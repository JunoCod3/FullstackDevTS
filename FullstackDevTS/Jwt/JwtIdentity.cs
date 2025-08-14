using Microsoft.AspNetCore.Identity;

namespace FullstackDevTS.Jwt;

public class JwtIdentity : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}