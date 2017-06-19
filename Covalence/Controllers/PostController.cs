using System;
using System.Threading.Tasks;
using Covalence.Authentication;
using Covalence.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Covalence.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        readonly ILogger<PostController> _logger;
        private readonly IPostService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(UserManager<ApplicationUser> userManager, IPostService service, ILogger<PostController> logger) {
            _logger = logger;
            _service = service;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostViewModel model) {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                _logger.LogError("User not found");
                return BadRequest();
            }
            
            if(ModelState.IsValid) {
                try 
                {
                    await _service.CreatePost(user, model);
                    return Ok();
                }
                catch(Exception e) 
                {
                    return BadRequest($"Failed to create post: {e}");
                }
            }    
            return BadRequest("ViewModel is invalid");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts() 
        {
            try
            {
                var posts = await _service.GetAllPosts();
                return Ok(posts);
            }
            catch(Exception e) 
            {
                return BadRequest(e);
            }   
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPost(int postId) 
        {
            try
            {
                var post = await _service.GetPost(postId);
                return Ok(post);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}