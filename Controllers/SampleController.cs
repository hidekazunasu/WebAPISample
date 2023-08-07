using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Models;
using System;

namespace Sample.Controllers;

[ApiController]
[Route("[Controller]")]
public class SampleController : ControllerBase
{
    private readonly SampleDbCotext _context;

    public SampleController(SampleDbCotext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var data = await _context.User.ToListAsync();

            if (data != null && data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                // データが見つからない場合にエラーレスポンスを返す
                return NotFound("データが見つかりませんでした。");
            }
        }
        catch (Exception ex)
        {
            // 例外が発生した場合にエラーレスポンスを返す
            return BadRequest("エラーが発生しました：" + ex.Message);
        }
    }
}
