using Auth.Models.Domain;
using Auth.Models.DTOs;
using Auth.Repositories.Interface;
using Auth.Services.Interface;
using AutoMapper;
using System.Security.Claims;

namespace Auth.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public PostService(IMapper mapper, IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }

        public async Task<PostDto?> CreateAsync(AddPostRequestDto addPostRequestDto, DateTime dateTime, string userId)
        {
            Post post = mapper.Map<Post>(addPostRequestDto);
            post.CreatedAt = dateTime;
            post.UserId = userId;
            post = await postRepository.CreateAsync(post);

            if(post != null)
                return mapper.Map<PostDto>(post);
            return null;
        }

        public async Task<Boolean> DeleteAsync(Guid id, string userId, List<String> userRoleClaims)
        {
            var post = await postRepository.GetByIdAsync(id);

            if (post == null)
                return false;

            if (userRoleClaims.Contains("Admin") || post.UserId == userId)
            {
                await postRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<PostDto?> GetByIdAsync(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post != null)
                return mapper.Map<PostDto>(post);
            return null;
        }

        public async Task<List<PostDto>?> GetAllAsync()
        {
            var posts = await postRepository.GetAllAsync();
            if (posts != null)
                return mapper.Map<List<PostDto>>(posts);
            return null;
        }

        public async Task<PostDto?> UpdateAsync(Guid id, UpdatePostRequestDto updatePostRequestDto, string userId, List<String> userRoleClaims )
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post == null)
                return null;

            if(userRoleClaims.Contains("Admin") || post.UserId == userId)
            {
                post = mapper.Map(updatePostRequestDto, post);
                post = await postRepository.UpdateAsync(post);
                return mapper.Map<PostDto>(post);
            }
            return null;
        }
    }
}
