using Microsoft.AspNetCore.Mvc;
using POCMongoDBId.Core.Entities;
using POCMongoDBId.Infrastructure.Data.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly ItemRepository _itemRepository;

    public ItemController(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] Item item)
    {
        try
        {

            _itemRepository.InsertItem(item);

            return Ok(item);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
