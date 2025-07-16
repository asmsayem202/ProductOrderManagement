using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductOrderManagement.Dtos;
using ProductOrderManagement.Services.Interfaces;

namespace ProductOrderManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdOrder = await _orderService.CreateAsync(createOrderDto);
        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateOrderDto dto)
        => await _orderService.UpdateAsync(id, dto) ? Ok() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => await _orderService.DeleteAsync(id) ? Ok() : NotFound();
}
