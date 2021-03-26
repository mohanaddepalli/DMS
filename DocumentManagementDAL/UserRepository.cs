using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{
  public class UserRepository 
  {
    public User ValidateUser(string userName, string  password)
    {
      using (var db=new DMSEntities())
      {
        var user = (from x in db.Users
                      where x.LoginName == userName && x.Password == password
                      select x).FirstOrDefault();

        return user;
      }
    }
  }
}
