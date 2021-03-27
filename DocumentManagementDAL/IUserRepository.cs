﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementDAL
{
  public interface IUserRepository
  {
    Task<User> ValidateUser(string userName, string password);
  }
}
