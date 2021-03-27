using DocumentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementBLL
{
  public class UserService : IUserService
  {
    private IUserRepository _UserRepository;

    public UserService(IUserRepository iUserRepository)
    {
      _UserRepository = iUserRepository;
    }
    public async Task<User> ValidateUser(string userName, string password)
    {
      return await _UserRepository.ValidateUser(userName, password);
    }
  }
}
