using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using workoutTracker.Domain.Common.Enums;
using workoutTracker.Domain.DatabaseContext;
using workoutTracker.Domain.Models.Application;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Repositories.Interface;
using workoutTracker.Domain.Services.Implementation;

namespace workoutTracker.Domain.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbcontext)
           : base(dbcontext)
        {
            return;
        }

        // TODO: token refresh

        public async Task<string> Login(GoogleAccessTokenResponse googleAccessTokenResponse, string secret)
        {
            var googleJwtToken = new JwtSecurityToken(jwtEncodedString: googleAccessTokenResponse.IdToken);
            string googleId = googleJwtToken.Claims.First(c => c.Type == "sub").Value;
            string name = googleJwtToken.Claims
                .FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
            string email = googleJwtToken.Claims
                .FirstOrDefault(c => c.Type == "email")?.Value ?? string.Empty;

            var user = await _dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.GoogleId == googleId);

            if (user == null)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    GoogleId = googleId,
                };
                _dbContext.Users.Add(user);
            }
            else
            {
                if (user.DeletedById.HasValue)
                {
                    throw new UnauthorizedAccessException();
                }

                user.Name = string.IsNullOrEmpty(name) ? user.Name : name;
                user.Email = string.IsNullOrEmpty(email) ? user.Email : email;
            }

            var claims = new List<Claim>
            {
                new( "oid", user.Id.ToString() ),
                new( ClaimTypes.Name, user.Name ),
                new( "email", user.Email ),
            };

            var newGeneratedToken = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256)
            );

            var responseJwtToken = new JwtSecurityTokenHandler().WriteToken(newGeneratedToken);
            return responseJwtToken;
        }
    }
}
