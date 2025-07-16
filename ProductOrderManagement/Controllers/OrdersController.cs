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
    public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
        => Ok(await _orderService.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateOrderDto dto)
        => await _orderService.UpdateAsync(id, dto) ? Ok() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => await _orderService.DeleteAsync(id) ? Ok() : NotFound();
}
