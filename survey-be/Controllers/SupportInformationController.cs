using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using CodeFirstDemo.Filter;
using CodeFirstDemo.Helpers;
using CodeFirstDemo.Services;
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
        private readonly IUriService _uriService;

        public SupportInformationController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
        }

        // GET: api/SupportInformation?PageNumber=1&PageSize=5&orderBy=user_id_des
        // GET: api/SupportInformation?PageNumber=1&PageSize=5&search=FAQ => search theo noi dung support information
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportInformationDTO>>> GetSupportInformations([FromQuery] PaginationFilter filter)
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

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.OrderBy, filter.Search);
            var supportInformations = await _context.SupportInformations.ToListAsync();

            var supportInformationDTOs = _mapper.Map<List<SupportInformationDTO>>(supportInformations);
            var totalRecords = supportInformationDTOs.Count;

            var pagedData = supportInformationDTOs
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .OrderBy(_ => _.UserId)
               .ToList();

            if (validFilter.Search != null)
            {
                pagedData = pagedData.Where(_ => _.SupportInformationContent.Contains(validFilter.Search)).ToList();
            }

            if (validFilter.OrderBy != null)
            {
                switch (validFilter.OrderBy)
                {
                    case "user_id_desc": pagedData = pagedData.OrderByDescending(_ => _.UserId).ToList(); break;
                    case "support_information_id_asc": pagedData = pagedData.OrderBy(_ => _.SupportInformationId).ToList(); break;
                    case "support_information_id_desc": pagedData = pagedData.OrderByDescending(_ => _.SupportInformationId).ToList(); break;
                    case "support_information_content_asc": pagedData = pagedData.OrderBy(_ => _.SupportInformationContent).ToList(); break;
                    case "support_information_content_desc": pagedData = pagedData.OrderByDescending(_ => _.SupportInformationContent).ToList(); break;
                }
            }

            var pagedResponse = PaginationHelper.CreatePagedReponse<SupportInformationDTO>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
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

                    if (userId?.UserId == supportInformation.UserId)
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
                    }
                    else
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
