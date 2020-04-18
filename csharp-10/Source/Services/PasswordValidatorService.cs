using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;
 
namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService: IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _dbContext;
        public PasswordValidatorService(CodenationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User user = _dbContext
                .Users
                .FirstOrDefault(x => x.Email.Equals(context.UserName) && x.Password.Equals(context.Password));

            if (user != null)
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user)
                    );
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "Invalid username or password"
                    );
            }   
            return Task.CompletedTask;
        }
     
    }
}