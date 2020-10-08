using AutoMapper;
//using AutoMapper.Configuration;
using Egras.Business.Interfaces;
using Egras.Entities;
using Egras.LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EgrasWebAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        IUserManager _userManager;
        //IRepository<User> _userManager;
        private IMapper _mapper;
        private ILoggerManager _logger;
        private IConfiguration _iConfiguration;
        //private readonly AppSettings _appSettings;
        public UserController(IUserManager userManager, ILoggerManager logger, IMapper mapper, IConfiguration iConfiguration)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _iConfiguration = iConfiguration;
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var user = await _userManager.Get();
            _logger.LogInfo("Return all the users from the storage");

            var userlist = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userlist);

        }

        [HttpGet("{userid}", Name = "UserById")]
        public async Task<IActionResult> Get(int userid)
        {

            if (userid == 0)
            {
                _logger.LogInfo($"userid: { userid}, Can not be zero or null.");
                return BadRequest(new ResponseMessages { Message = "User id can`t be zero or null ", status = "400" });
            }
            var user = await _userManager.Get(userid);
            if (!user.Any())
            {
                _logger.LogInfo($"User with userid: {userid}, hasn't been found.");
                return NotFound(new ResponseMessages { Message = "Not Found", status = "404" });
            }
            else
            {
                _logger.LogInfo($"User by userid : {userid} from the storage");
                var userlist = _mapper.Map<IEnumerable<UserDto>>(user);

                return Ok(userlist);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserDto userDto)
        {
            if (userDto == null)
            {
                _logger.LogError("User Object cannot be zero or null");
                return BadRequest(new ResponseMessages { Message = "User is null ", status = "400" });
            }
            var userEntity = _mapper.Map<User>(userDto);
            var userVal = await _userManager.Add(userEntity);
            if (userVal != 0)
            {
                //var createdUser = _mapper.Map<AddUserDto>(userEntity);
                _logger.LogInfo($"New created user as login ID : {userEntity.LoginID}");
                //return CreatedAtRoute("UserById", new { userid = createdUser.userId }, createdUser);
                return Ok(new ResponseMessages { Message = "User Created Successfully", status = "200" });
            }
            else
            {
                return BadRequest(new ResponseMessages { Message = "User Not Created ", status = "400" });
            }
        }

        [HttpPut("{updatedById}")]
        public async Task<IActionResult> UpdateUser(int updatedById, [FromBody] AddUserDto userDto)
        {
            if (userDto == null || updatedById <= 0)
            {
                _logger.LogError("User or UpdatedByUserId cannot be zero or null");
                return BadRequest(new ResponseMessages { Message = "User Is Null", status = "400" });
            }
            var userEntity = _mapper.Map<User>(userDto);
            var userVal = await _userManager.Update(userEntity);
            if (userVal != 0)
            {
                var updatedUser = _mapper.Map<AddUserDto>(userVal);
                _logger.LogInfo($"Update user successfully  as login id :{updatedUser.LoginId} and updated by userid : {updatedById}");
                return CreatedAtRoute("UserById", new { userid = updatedUser.userId }, updatedUser);
            }
            else
            {
                return BadRequest(new ResponseMessages { Message = "User Not Updated", status = "400" });
            }
        }

        [HttpDelete("{userId,deletedByUserId}")]
        public async Task<IActionResult> DeleteUser(int userId, int deletedByUserId)
        {
            if (userId <= 0 || deletedByUserId <= 0)
            {
                _logger.LogError("UserID or DeletedByUserId can not be zero ");
                return BadRequest(new ResponseMessages { Message = "User id is zero", status = "400" });
            }
            var userVal = await _userManager.Delete(userId);
            if (userVal == 0)
            {
                _logger.LogError($"User not found with userid :{userId}");
                return NotFound(new ResponseMessages { Message = "User Not Found", status = "200" });
            }
            else
            {
                _logger.LogInfo($"User Deleted Successfully with user id : {userId} By user id : {deletedByUserId}");
                return Ok(new ResponseMessages { Message = "User Deleted Successfully", status = "200" });
            }
        }

        [HttpGet("GetUserId/{loginid}")]

        public async Task<IActionResult> GetUserId(string loginid)
        {
            if (loginid == null || loginid == string.Empty)
            {
                _logger.LogError("LoginID can not be null or empty");
                return BadRequest(new ResponseMessages { Message = "loginid is zero or empty", status = "500" });
            }
            var userval = await _userManager.GetUserId(loginid);
            if (userval != 0)
            {
                _logger.LogInfo($"User found for loginid : {loginid}");
                return Ok(userval);
            }
            else
            {
                _logger.LogInfo($"User not found for Loginid : {loginid}");
                return NotFound(new ResponseMessages { Message = "LoginID Not Found", status = "400" });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Authenticate model)
        {
            if (model == null)
            {
                _logger.LogError("User Details can not be null or empty");
                return BadRequest(new ResponseMessages { Message = "User Details can not be null or empty", status = "500" });
            }
            var user = await _userManager.Authenticate(model);

            if (user != null)
            {
                //return BadRequest(new { message = "Username or password is incorrect" });
                //_logger.LogError("LoginID can not be null or empty");
                //return BadRequest(new ResponseMessages { Message = "Username or password is incorrect", status = "500" });
                _logger.LogInfo($"User found for loginid : {user.Username}");
                var token = GenerateJSONWebToken(user);
                return Ok(new { token = token });
            }
            else
            {
                _logger.LogInfo($"User not found for Loginid : {model.Username}");
                return NotFound(new ResponseMessages { Message = "LoginID Not Found", status = "400" });
            }
        }

        private string GenerateJSONWebToken(Authenticate user)
        {
            _logger.LogInfo($"Token careation for loginid : {user.Username}");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Typ, user.UserType.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.ErrorCode.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,user.UserType.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _iConfiguration["Jwt:Issuer"],
                audience: _iConfiguration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            _logger.LogInfo($"token created for loginid : {user.Username} and token : {encodedToken}");
            return encodedToken;
        }
    }
}
