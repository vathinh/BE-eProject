using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using survey_be.Data;
using survey_be.Dtos;
using survey_be.Models;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        public static UserInfo userinfo = new UserInfo();
        private readonly IConfiguration _configuration;




        public UserInfoesController(SurveyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        // POST: api/UserInfoes
        [HttpPost("register")]
        public ActionResult<UserInfo> Register(UserDTO request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            userinfo.UserName = userinfo.UserName;
            userinfo.UserPassword = passwordHash;
            userinfo.RollNo = userinfo.RollNo;
            userinfo.UserClass = userinfo.UserClass;
            userinfo.Specification = userinfo.Specification;
            userinfo.Section = userinfo.Section;

            return Ok(userinfo);
        }

        // POST: api/UserInfoes
        [HttpPost("login")]
        public ActionResult<UserInfo> Login(UserDTO request)
        {
            if (userinfo.UserName != userinfo.UserName)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, userinfo.UserPassword))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(userinfo);

            return Ok(token);
        }

        // CREATE TOKEN
        private string CreateToken(UserInfo userinfo)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, userinfo.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        // GET: api/UserInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserInfos()
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            return await _context.UserInfos.ToListAsync();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            if (_context.UserInfos == null)
            {
                return Problem("Entity set 'SurveyDbContext.UserInfos'  is null.");
            }
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.UserId }, userInfo);
            //return Ok(userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(int id)
        {
            return (_context.UserInfos?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
