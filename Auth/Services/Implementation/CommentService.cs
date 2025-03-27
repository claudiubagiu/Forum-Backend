using Auth.Models.Domain;
using Auth.Models.DTOs;
using Auth.Repositories.Interface;
using Auth.Services.Interface;
using AutoMapper;

namespace Auth.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }
        public async Task<CommentDto?> CreateAsync(AddCommentRequestDto addCommentRequestDto, DateTime dateTime, string userId)
        {
            Comment comment = mapper.Map<Comment>(addCommentRequestDto);
            comment.CreatedAt = dateTime;
            comment.UserId = userId;
            comment = await commentRepository.CreateAsync(comment);

            if (comment != null)
                return mapper.Map<CommentDto>(comment);
            return null;
        }

        public async Task<bool> DeleteAsync(Guid id, string userId, List<String> userRoleClaims)
        {
            var comment = await commentRepository.GetByIdAsync(id);

            if (comment == null)
                return false;

            if (userRoleClaims.Contains("Admin") || comment.UserId == userId)
            {
                await DeleteChildrenAsync(comment.ChildrenComments.ToList());
                await commentRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        private async Task DeleteChildrenAsync(List<Comment> children)
        {
            if (!children.Any()) return;

            foreach (var child in children)
            {
                if(child.ChildrenComments.Any())
                    await DeleteChildrenAsync(child.ChildrenComments.ToList());
                await commentRepository.DeleteAsync(child.Id);
            }
        }
        public async Task<List<CommentDto>?> GetAllAsync()
        {
            var comments = await commentRepository.GetAllAsync();
            if (comments != null)
                return mapper.Map<List<CommentDto>>(comments);
            return null;
        }

        public async Task<CommentDto?> GetByIdAsync(Guid id)
        {
            var comment = await commentRepository.GetByIdAsync(id);
            if (comment != null)
                return mapper.Map<CommentDto>(comment);
            return null;
        }

        public async Task<CommentDto?> UpdateAsync(Guid id, UpdateCommentRequestDto updateCommentRequestDto, string userId, List<String> userRoleClaims)
        {
            var comment = await commentRepository.GetByIdAsync(id);
            if (comment == null)
                return null;

            if(userRoleClaims.Contains("Admin") || comment.UserId == userId)
            {
                comment = mapper.Map(updateCommentRequestDto, comment);
                comment = await commentRepository.UpdateAsync(comment);
                return mapper.Map<CommentDto>(comment);
            }
            return null;
        }
    }
}
