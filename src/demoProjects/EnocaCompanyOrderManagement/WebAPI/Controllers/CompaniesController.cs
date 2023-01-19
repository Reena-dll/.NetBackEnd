using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Companies.Queries.GetByIdCompany;
using Application.Features.Companies.Queries.GetListCompany;
using Application.Features.Companies.Queries.GetListCompanyByDynamic;
using Application.Features.Products.Models;
using Application.Features.Products.Queries.GetListProductByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            CreatedCompanyDto result = await Mediator.Send(createCompanyCommand);

            return Created("", result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            UpdatedCompanyDto updatedCompanyDto = await Mediator.Send(updateCompanyCommand);
            return Ok(updatedCompanyDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCompanyCommand deleteCompanyCommand)
        {
            DeletedCompanyDto deletedCompanyDto = await Mediator.Send(deleteCompanyCommand);
            return Ok(deletedCompanyDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCompanyQuery getListCompanyQuery = new() { PageRequest = pageRequest };
            CompanyListModel result = await Mediator.Send(getListCompanyQuery);

            return Ok(result);
        }

        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyQuery getByIdCompanyQuery)
        {
            CompanyGetByIdDto result = await Mediator.Send(getByIdCompanyQuery);

            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCompanyByDynamicQuery getListCompanyByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            CompanyListModel result = await Mediator.Send(getListCompanyByDynamicQuery);

            return Ok(result);
        }

    }
}
