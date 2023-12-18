using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Data;
using Movie_Review.Data.Dtos;
using Movie_Review.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _UserService;
        private UserContext _context;
        private IMapper _mapper;

        public UserController(UserService registerService, UserContext context, IMapper mapper)
        {
            _UserService = registerService;
            _context = context;
            _mapper = mapper; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser
            (CreateUserDto dto)
        {
            await _UserService.SignUser(dto);
            return Ok("Usuário cadastrado!");

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var token = await _UserService.Login(dto);
            return Ok(token);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(RemoveUserDto dto)
        {
            await _UserService.RemoveUser(dto);
            return Ok("Usuário removido");
        }

        // GET /User/:id/reviews
        [HttpGet("{id}/reviews")]
        public ActionResult<List<ReadReviewDto>> GetUserReviews([Required(ErrorMessage = "O Id é obrigatorio")] string id)
        {
            var response = _context.Reviews.Skip(0).Take(5).Where(review => review.User.Reviews.Any(user => user.UserId == id)).ToList();

            var toRead = _mapper.Map<List<ReadReviewDto>>(response);

            toRead.ForEach(review =>
            {
                var getLikes = _context.Likes.Skip(0).Take(5).Where(x => x.ReviewId == review.Id);
                review.LikeCount = getLikes.Count(x => x.isLike == true);
                review.DislikeCount = getLikes.Count(x => x.isLike == false);
            });

            return Ok(toRead);
        }

        // GET /User/:id/reviews
        [HttpGet("{id}/likes")]
        public ActionResult<List<ReadReviewDto>> GetUserLikes([Required(ErrorMessage = "O Id é obrigatorio")] string id)
        {
            var response = _context.Reviews.Skip(0).Take(5).Where(like => like.User.Likes.Any(user => user.UserId == id)).ToList();
            var toRead = _mapper.Map<List<ReadLikeDto>>(response);

            toRead.ForEach(review =>
            {
                var getLikes = _context.Likes.Where(x => x.ReviewId == review.Id);
                review.LikeCount = getLikes.Count(x => x.isLike == true);
                review.DislikeCount = getLikes.Count(x => x.isLike == false);
                bool getMyLike = getLikes.Where(x => x.ReviewId == review.Id && x.UserId == id).Any(x => x.isLike);
                review.isLike = getMyLike;
            });
            return Ok(toRead);
        }
    }
}
