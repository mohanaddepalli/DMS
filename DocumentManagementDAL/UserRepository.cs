using System.Linq;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{
  public class UserRepository : IUserRepository
  {
    public async Task<User> ValidateUser(string userName, string password)
    {
      using (var context = new DMSEntities())
      {
        context.Configuration.ProxyCreationEnabled = false;
        var user = context.Users.Where(x => x.LoginName == userName && x.Password == password).FirstOrDefault();

        return user;
      }
    }
  }
}
