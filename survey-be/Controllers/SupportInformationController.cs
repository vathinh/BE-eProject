using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using survey_be.Data;
using survey_be.Dtos;
using survey_be.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportInformationController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;

        public SupportInformationController(SurveyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SupportInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportInformation>>> GetSupportInformations()
        {
            if (_context.SupportInformations == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Data not found",
                    data = null
                });
            }
            var supportInformations = await _context.SupportInformations.ToListAsync();
            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Data get successfully",
                data = supportInformations
            });
        }

        // POST: api/SupportInformation
        [HttpPost]
        public async Task<ActionResult<SupportInformationDTO>> PostSupportInformation(SupportInformationDTO payloadSupportInformation)
        {
            if (_context.SupportInformations == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail",
                    data = null
                });
            }
            var newSupportInformation = _mapper.Map<SupportInformation>(payloadSupportInformation);

            var userId = _context.UserInfos.SingleOrDefault(_ => _.UserId == newSupportInformation.UserId);

            if (userId != null)
            {
                _context.SupportInformations.Add(newSupportInformation);
                await _context.SaveChangesAsync();

                return Ok(new Models.HttpResponseSuccess
                {
                    status = HttpStatusCode.OK,
                    title = "Create data successfully",
                    data = null
                });
            }

            return NotFound(new Models.HttpResponseError
            {
                status = HttpStatusCode.BadRequest,
                title = "Invalid userId, create data fail",
                data = null
            });
        }

        // PUT: api/SupportInformation/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportInformation(int id, SupportInformationDTO payloadSupportInformation)
        {

            try
            {
                var newSupportInformation = _mapper.Map<SupportInformation>(payloadSupportInformation);

                var supportInformation = await _context.SupportInformations.FindAsync(id);
                var userId = _context.UserInfos.SingleOrDefault(_ => _.UserId == newSupportInformation.UserId);


                if (supportInformation != null)
                {

                    if(userId?.UserId == supportInformation.UserId)
                    {
                    supportInformation.SupportInformationContent = payloadSupportInformation.SupportInformationContent;
                    supportInformation.UserId = payloadSupportInformation.UserId;


                    await _context.SaveChangesAsync();
                    return Ok(new Models.HttpResponseSuccess
                    {
                        status = HttpStatusCode.OK,
                        title = "Update data successfully",
                        data = null
                    });
                    } else
                    {
                        return NotFound(new Models.HttpResponseError
                        {
                            status = HttpStatusCode.BadRequest,
                            title = "Invalid userId, create data fail",
                            data = null
                        });
                    }

                }

                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.BadRequest,
                    title = "Update data fail",
                    data = null
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
