using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using Application.Features.Orders.Queries.GetByIdOrder;
using Application.Features.Orders.Queries.GetListOrder;
using Application.Features.Orders.Queries.GetListOrderByDynamic;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries.GetByIdProduct;
using Application.Features.Products.Queries.GetListProduct;
using Application.Features.Products.Queries.GetListProductByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrderCommand)
        {
            CreatedOrderDtos result = await Mediator.Send(createOrderCommand);

            return Created("Order Confirmed", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOrderQuery getListOrderQuery = new() { PageRequest = pageRequest };
            OrderListModel result = await Mediator.Send(getListOrderQuery);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOrderQuery getByIdOrderQuery)
        {
            OrderGetByIdDto result = await Mediator.Send(getByIdOrderQuery);

            return Ok(result);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListOrderByDynamicQuery getListOrderByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            OrderListModel result = await Mediator.Send(getListOrderByDynamicQuery);

            return Ok(result);
        }
    }
}
