using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using survey_be.Data;
using survey_be.Models;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public UserRolesController(SurveyDbContext context)
        {
            _context = context;
        }


        // READ TO LIST UserRole
        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            return await _context.UserRoles.ToListAsync();
        }

        // READ BY ID
        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            var userRole = await _context.UserRoles.FindAsync(id);

            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }


        // EDIT
        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRole userRole)
        {
            if (id != userRole.UserRoleId)
            {
                return BadRequest();
            }

            _context.Entry(userRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
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


        // CREATE
        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRole userRole)
        {
          if (_context.UserRoles == null)
          {
              return Problem("Entity set 'SurveyDbContext.UserRoles'  is null.");
          }
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRole", new { id = userRole.UserRoleId }, userRole);
        }


        // DELETE
        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoleExists(int id)
        {
            return (_context.UserRoles?.Any(e => e.UserRoleId == id)).GetValueOrDefault();
        }
    }
}
