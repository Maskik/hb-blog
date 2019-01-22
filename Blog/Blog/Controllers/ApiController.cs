using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace HeedbookIdentity.Controllers
{
    [RequireHttps]
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        // return all posts for any users
        public async Task<IActionResult> Posts(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                {
                    var response = await _context.Posts.ToListAsync();
                    return Ok(response);
                }
                else
                {
                    var response = await _context.Posts.FirstOrDefaultAsync(p => p.Id == Id);
                    return Ok(response);
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]Post post)
        {
            try
            {
                if (post.Title == null)
                    throw new Exception("error");
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditPost([FromBody]Post post)
        {
            try
            {
                if (post.Id == null)
                    throw new Exception("error");
                _context.Posts.Update(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid Id)
        {
            try
            {
                if (Id == null)
                    throw new Exception("error");
                Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == Id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}