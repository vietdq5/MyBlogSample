using AutoMapper;
using AutoMapper.QueryableExtensions;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGao.Utilities.Dtos;
using SieuNhanGao.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SieuNhanGao.Service.ServicesIml
{
    public class PostService : IPostService
    {
        private IReadRepository<Post> _postRepository;
        private ICUDRepository<Post> _postCUDRepository;
        private IReadRepository<Tag> _tagRepository;
        private IReadRepository<PostTag> _postTagRepository;
        private IReadRepository<PostCategory> _postCategoryRepository;
        private IReadRepository<Category> _categoryRepository;
        private IReadRepository<User> _userRepository;
        private IReadRepository<Comment> _commentRepository;

        private IUnitOfWork _unitOfWork;

        public PostService(IReadRepository<Post> postRepository,
                            IReadRepository<Tag> tagRepository,
                            ICUDRepository<Post> postCUDRepository,
                         IReadRepository<PostTag> postTagRepository,
                         IReadRepository<PostCategory> postCategoryRepository,
                         IReadRepository<Category> categoryRepository,
                         IReadRepository<User> userRepository,
                         IReadRepository<Comment> commentRepository,
                         IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _postCUDRepository = postCUDRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
            _postCategoryRepository = postCategoryRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _commentRepository = commentRepository;
        }

        public IList<PostViewModel> GetAll()
        {
            return _postRepository.FindAll(x => x.Id).ProjectTo<PostViewModel>().ToList();
        }

        public PagedResult<PostHomeViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            // get all post
            var posts = _postRepository.FindAll(s=>s.Status==1);
            var users = _userRepository.FindAll();
            // filter post with keywork
            if (!string.IsNullOrEmpty(keyword))
                posts = posts.Where(x => x.Title.Contains(keyword));

            // oder post by CreateDate and pagination
            var postsPagination = posts.OrderByDescending(x => x.CreateDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            // get user info with post
            var postsWithUserInfor = from p in postsPagination
                                     join u in users
                                     on p.UserId equals u.Id
                                     select new PostHomeViewModel
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         Description = p.Description,
                                         Thumbnail = p.Thumbnail,
                                         CreateDate = p.CreateDate,
                                         Alias = p.Alias,
                                         ViewCount = p.ViewCount,
                                         ImageAvatar = u.Avatar,
                                         UserName = u.UserName,
                                         DateCreateAgo = DateFormat.GetPrettyDateAgo(p.CreateDate)
                                     };

            // total post
            int totalRow = posts.Count();
            // get pagecount for all post
            var pageCount = (double)totalRow / pageSize;

            var paginationSet = new PagedResult<PostHomeViewModel>()
            {
                Results = postsWithUserInfor.ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
                PageCount = (int)Math.Ceiling(pageCount)
            };

            return paginationSet;
        }

        public DetailPostViewModel GetDetail(int id)
        {
            // lay chi tiet post theo id
            var post = GetById(id);
            // lay user theo post
            var user = _userRepository.FindSingle(s => s.Id == post.UserId);
            // lay danh sach tag theo post id
            var tags = from t in _tagRepository.FindAll()
                       join pt in _postTagRepository.FindAll(s => s.PostId == id)
                       on t.Id equals pt.TagId
                       //where pt.PostId == id
                       select new TagViewModel
                       {
                           Id = t.Id,
                           TagName = t.TagName
                       };

            // lay danh sach category theo postid
            var categories = from pc in _postCategoryRepository.FindAll(s => s.PostId == id)
                             join c in _categoryRepository.FindAll()
                             on pc.CategoryId equals c.Id
                             //where pc.PostId == id
                             select new CategoryViewModel
                             {
                                 Id = c.Id,
                                 CategoryName = c.CategoryName
                             };

            // lay danh sach comment
            var comments = from cm in _commentRepository.FindAll()
                           join p in _postRepository.FindAll()
                           on cm.PostId equals p.Id
                           join us in _userRepository.FindAll()
                           on p.UserId equals us.Id
                           where cm.PostId == id && cm.Status == true
                           select new CommentInPostViewModel
                           {
                               UserName = us.UserName,
                               CreateDate = cm.CreateDate,
                               Content = cm.Content
                           };
            //get previous post
            var previousPost = _postRepository.FindAll(s => s.Id < id).ProjectTo<PostViewModel>().LastOrDefault();
            //get next post
            var nextPost = _postRepository.FindAll(s => s.Id > id).ProjectTo<PostViewModel>().FirstOrDefault();

            var postViewModel = new DetailPostViewModel
            {
                PostId = post.Id,
                Title = post.Title,
                Content = post.Content,
                Tags = tags,
                Categories = categories,
                Avatar = user.Avatar,
                Author = user.FirstName,
                Comments = comments.OrderByDescending(s => s.CreateDate),
                DateAgo = DateFormat.GetPrettyDateAgo(post.CreateDate),
                PreviousPost = previousPost,
                NextPost = nextPost
            };
            return postViewModel;
        }

        public List<PostViewModel> GetLatest()
        {
            return _postRepository.FindAll().OrderByDescending(s => s.CreateDate).Take(5).ProjectTo<PostViewModel>().ToList();
        }

        public PostViewModel GetById(int id)
        {
            return Mapper.Map<Post, PostViewModel>(_postRepository.FindSingle(s => s.Id == id));
        }

        public PostViewModel Add(PostViewModel postvm)
        {
            var post = Mapper.Map<PostViewModel, Post>(postvm);
            _postCUDRepository.Add(post);
            return postvm;
        }

        public void Update(PostViewModel postVm)
        {
            var post = Mapper.Map<PostViewModel, Post>(postVm);
            _postCUDRepository.Update(post);
        }

        public void Delete(int id)
        {
            var post = _postRepository.FindSingle(s => s.Id == id);
            _postCUDRepository.Remove(post);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public PagedResult<PostHomeViewModel> GetAllPagingWithCategory(string categoryName, int page, int pageSize)
        {
            // get all post
            var posts = _postRepository.FindAll();
            var users = _userRepository.FindAll();

            var category = _categoryRepository.FindAll(x => x.CategoryName == categoryName).FirstOrDefault();
            // neu ko tim thay categiryId thì return lại là null
            if (category == null)
            {
                return null;
            }
            // todo hardcode
            var postCategories = _postCategoryRepository.FindAll(x => x.CategoryId == category.Id);

            // get user info with post
            var postsWithUserInfor = from p in posts
                                     join u in users
                                     on p.UserId equals u.Id
                                     join pc in postCategories
                                     on p.Id equals pc.PostId
                                     select new PostHomeViewModel
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         Description = p.Description,
                                         Thumbnail = p.Thumbnail,
                                         CreateDate = p.CreateDate,
                                         Alias = p.Alias,
                                         ViewCount = p.ViewCount,
                                         ImageAvatar = u.Avatar,
                                         UserName = u.UserName,
                                         DateCreateAgo = DateFormat.GetPrettyDateAgo(p.CreateDate)
                                     };

            // oder post by CreateDate and pagination
            var postsPagination = postsWithUserInfor
                .OrderByDescending(x => x.CreateDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            // total post
            int totalRow = postsWithUserInfor.Count();
            // get pagecount for all post
            var pageCount = (double)totalRow / pageSize;

            var paginationSet = new PagedResult<PostHomeViewModel>()
            {
                Results = postsPagination.ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
                PageCount = (int)Math.Ceiling(pageCount)
            };

            return paginationSet;
        }

        public PagedResult<PostHomeViewModel> GetAllPagingWithTag(string tagName, int page, int pageSize)
        {
            // get all post
            var posts = _postRepository.FindAll();
            var users = _userRepository.FindAll();

            var tag = _tagRepository.FindAll(x => x.TagName == tagName).FirstOrDefault();
            // neu ko tim thay tag id thi thuc return null
            if (tag == null) return null;
            var postTags = _postTagRepository.FindAll(x => x.TagId == tag.Id);

            // get user info with post
            var postsWithUserInfor = from p in posts
                                     join u in users
                                     on p.UserId equals u.Id
                                     join pc in postTags
                                     on p.Id equals pc.PostId
                                     select new PostHomeViewModel
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         Description = p.Description,
                                         Thumbnail = p.Thumbnail,
                                         CreateDate = p.CreateDate,
                                         Alias = p.Alias,
                                         ViewCount = p.ViewCount,
                                         ImageAvatar = u.Avatar,
                                         UserName = u.UserName,
                                         DateCreateAgo = DateFormat.GetPrettyDateAgo(p.CreateDate)
                                     };

            // oder post by CreateDate and pagination
            var postsPagination = postsWithUserInfor
                .OrderByDescending(x => x.CreateDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            // total post
            int totalRow = postsWithUserInfor.Count();
            // get pagecount for all post
            var pageCount = (double)totalRow / pageSize;

            var paginationSet = new PagedResult<PostHomeViewModel>()
            {
                Results = postsPagination.ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
                PageCount = (int)Math.Ceiling(pageCount)
            };

            return paginationSet;
        }

        public void IncreaseView(int id)
        {
            var post = _postRepository.FindSingle(s => s.Id == id);
            if (post.ViewCount.HasValue)
            {
                post.ViewCount += 1;
            }
            else
            {
                post.ViewCount = 1;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}