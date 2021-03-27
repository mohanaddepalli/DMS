using DocumentManagementBLL;
using DocumentManagementDAL;
using System.Threading.Tasks;
using System.Web.Http;

namespace DocumentManagmentApi.Controllers
{
  public class UserController : ApiController
  {
    private IUserService _IUserService;
    public UserController(IUserService userService)
    {
      _IUserService = userService;
    }

    [HttpGet]
    [Route("user/validate")]
    public async Task<IHttpActionResult> ValidateUser(string userName, string password)
    {
      var user =  await _IUserService.ValidateUser(userName, password);
      return Ok(user);
    }
  }
}
