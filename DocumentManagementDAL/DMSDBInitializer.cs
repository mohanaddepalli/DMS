using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{

  public class DMSDBInitializer : CreateDatabaseIfNotExists<DMSEntities>
  {
    protected override void Seed(DMSEntities context)
    {
      IList<Status> defaultStatuses = new List<Status>();
      defaultStatuses.Add(new Status() { StatusName = "Active", CreatedTimestamp = DateTime.UtcNow, LastModifiedTimestamp = DateTime.UtcNow });
      defaultStatuses.Add(new Status() { StatusName = "InActive", CreatedTimestamp = DateTime.UtcNow, LastModifiedTimestamp = DateTime.UtcNow });
      context.Status.AddRange(defaultStatuses);

      User user = new User
      {
        CreatedTimestamp = DateTime.UtcNow,
        FirstName = "Mohan",
        LastModifiedTimestamp = DateTime.UtcNow,
        LastName = "Addepalli",
        MiddleName = "k",
        LoginName = "admin",
        Password = "123456",
        StatusId = 1
      };
      context.Users.Add(user);
      base.Seed(context);
    }
  }
}

