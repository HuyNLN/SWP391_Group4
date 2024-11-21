using API.Data;
using API.DTOs.RequestDTO;
using API.DTOs.ResponseDTO;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAO
{
    public class CommentDAO
    {
        private readonly ShoesDbContext db;
        private readonly IMapper m;
        public CommentDAO(ShoesDbContext db, IMapper _m)
        {
            this.db = db;
            this.m = _m;
        }

        public ResponseMessage CreateComment(CommentDTO commentDTO)
        {
            try
            {
                var getAccount = db.Account.FirstOrDefault(x => x.AccountID == commentDTO.UserID);
                var getProduct = db.Product.FirstOrDefault(p => p.ProductID == commentDTO.ProductID);
                Comment createComment = new Comment
                {
                    Account = getAccount,
                    Product = getProduct,
                    Content = commentDTO.Content,
                    CreatedDate = DateTime.Now,
                    AccountID = getAccount.AccountID,
                    ProductID = getProduct.ProductID
                };
                db.Comment.Add(createComment);
                db.SaveChanges();
                return new ResponseMessage
                {
                    Success = true,
                    Message = "Success",
                    Data = m.Map<CommentResponseDTO>(createComment),
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = $"{ex.Message}",
                    Data = ex,
                    StatusCode = 500
                };
            }
        }

        public ResponseMessage GetCommentInProduct(int accountID, int productID)
        {
            var getComment = db.Comment
                               .Include(x => x.Account)
                               .FirstOrDefault(x => x.AccountID == accountID && x.ProductID == productID);
            return new ResponseMessage
            {
                Success = true,
                Message = "Success",
                Data = getComment,
                StatusCode = 200
            };
        }

        public ResponseMessage DeleteComment(int commentID)
        {
            var getComment = db.Comment.FirstOrDefault(x => x.CommentID == commentID);
            if (getComment != null)
            {
                db.Comment.Remove(getComment);
                db.SaveChanges();
                return new ResponseMessage
                {
                    Success = true,
                    Message = "Success",
                    Data = getComment,
                    StatusCode = 200
                };
            }
            return new ResponseMessage
            {
                Success = false,
                Message = "Unauthorized",
                Data = new int[0],
                StatusCode = 401
            };
        }

        public ResponseMessage UpdateComment(UpdateCommentDTO updateCommentDTO)
        {
            var getComment = db.Comment.FirstOrDefault(x => x.CommentID == updateCommentDTO.CommentID);
            if (getComment != null)
            {
                getComment.Content = updateCommentDTO.Content;
                db.Comment.Update(getComment);
                db.SaveChanges();
                return new ResponseMessage
                {
                    Success = true,
                    Message = "Success",
                    Data = getComment,
                    StatusCode = 200
                };
            }
            return new ResponseMessage
            {
                Success = false,
                Message = "Unauthorized",
                Data = new int[0],
                StatusCode = 401
            };
        }
    }
}

