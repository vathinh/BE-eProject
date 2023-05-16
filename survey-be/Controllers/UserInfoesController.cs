using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodeFirstDemo.Filter;
using CodeFirstDemo.Helpers;
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
		private readonly IMapper _mapper; // ver 01



		public UserInfoesController(SurveyDbContext context, IConfiguration configuration, IMapper mapper)
		{
			_context = context;
			_configuration = configuration;
			_mapper = mapper; // ver 01

		}

		// POST: api/UserInfoes
		[HttpPost("register")]
		public ActionResult<UserInfo> Register(UserDTO request)
		{
			string passwordHash
				= BCrypt.Net.BCrypt.HashPassword(request.Password);

			userinfo.UserName = request.UserName;
			userinfo.UserPassword = passwordHash;
			userinfo.FullName = request.FullName; // ver 01
			userinfo.RollNo = request.RollNo; // ver 01
			userinfo.UserClass = request.UserClass; // ver 01
			userinfo.Specification = request.Specification; // ver 01
			userinfo.Section = request.Section; // ver 01
            userinfo.AdmissionDate = request.AdmissionDate; // ver 01

            return Ok(userinfo);
		}

        // POST: api/UserInfoes
        [HttpPost("login")]
        public ActionResult<UserInfo> Login(LoginDTO request) // thay class UserDTO.cs = LoginDTO.cs
        {
            if (userinfo.UserName != request.UserName)
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
        private string CreateToken(UserInfo userInfo)
		{
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Name, userinfo.UserName)
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

		//public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserInfos()
		//{
		//	if (_context.UserInfos == null)
		//	{
		//		return NotFound(new Models.HttpResponseError
		//		{
		//			status = HttpStatusCode.NotFound,
		//			title = "Get data fail",
		//			data = null
		//		});
		//	}

		//	return Ok(userinfo);
		//}

		// GET: api/UserInfoes/
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

		// PUT: api/UserInfoes/
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

		// PUT: api/UserInfoes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		// Ver 01
		[HttpPut]
		public async Task<IActionResult> PutUser(UserDTO payloadUser)
		{

			try
			{
				var updateUser = _mapper.Map<UserInfo>(payloadUser);
				_context.UserInfos.Update(updateUser);
				await _context.SaveChangesAsync();
				return Ok(updateUser);
			}
			catch (Exception ex)
			{
				return NotFound(new Models.HttpResponseError
				{
					status = HttpStatusCode.NotFound,
					title = "Update data fail " + ex.Message,
					data = null
				});
			}

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
