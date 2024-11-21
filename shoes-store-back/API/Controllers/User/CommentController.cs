using API.DAO;
using API.DTOs.RequestDTO;
using API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User
{
    [ApiController]
    [Route("api/v1/comment")]
    public class CommentController : Controller
    {
        private readonly CommentDAO dao;
        public CommentController(CommentDAO dao)
        {
            this.dao = dao;
        }

        [HttpPost("create-comment"), Authorize]
        public IActionResult CreateComment([FromBody] CommentDTO commentDTO)
        {
            var user = JWTHandler.GetUserIdFromHttpContext(HttpContext);
            commentDTO.UserID = user;
            var response = dao.CreateComment(commentDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("get-comment"), Authorize]
        public IActionResult GetCommentInProduct(int productID)
        {
            var user = JWTHandler.GetUserIdFromHttpContext(HttpContext);
            var response = dao.GetCommentInProduct(user, productID);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("delete-comment/{commentID}"), Authorize]
        public IActionResult DeleteComment(int commentID) {
            var reponse = dao.DeleteComment(commentID);
            return StatusCode(reponse.StatusCode,reponse);
        }

        [HttpPut("update-comment"), Authorize]
        public IActionResult UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            var reponse = dao.UpdateComment(updateCommentDTO);
            return StatusCode(reponse.StatusCode, reponse);
        }
    }
}
