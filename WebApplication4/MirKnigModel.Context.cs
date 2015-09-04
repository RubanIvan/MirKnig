﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MirKnigEntities : DbContext
    {
        public MirKnigEntities()
            : base("name=MirKnigEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
    
        public virtual ObjectResult<FindBook_Result> FindBook(Nullable<int> pageId, string title, string author, string description, Nullable<int> genreId)
        {
            var pageIdParameter = pageId.HasValue ?
                new ObjectParameter("PageId", pageId) :
                new ObjectParameter("PageId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("author", author) :
                new ObjectParameter("author", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("genreId", genreId) :
                new ObjectParameter("genreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindBook_Result>("FindBook", pageIdParameter, titleParameter, authorParameter, descriptionParameter, genreIdParameter);
        }
    
        public virtual ObjectResult<GetBookById_Result> GetBookById(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookById_Result>("GetBookById", bookIdParameter);
        }
    
        public virtual ObjectResult<GetBookPage_Result> GetBookPage(Nullable<int> pageId, Nullable<int> genreID)
        {
            var pageIdParameter = pageId.HasValue ?
                new ObjectParameter("PageId", pageId) :
                new ObjectParameter("PageId", typeof(int));
    
            var genreIDParameter = genreID.HasValue ?
                new ObjectParameter("GenreID", genreID) :
                new ObjectParameter("GenreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookPage_Result>("GetBookPage", pageIdParameter, genreIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetFindMaxPage(Nullable<int> pageId, string title, string author, string description, Nullable<int> genreId)
        {
            var pageIdParameter = pageId.HasValue ?
                new ObjectParameter("PageId", pageId) :
                new ObjectParameter("PageId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("author", author) :
                new ObjectParameter("author", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("genreId", genreId) :
                new ObjectParameter("genreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetFindMaxPage", pageIdParameter, titleParameter, authorParameter, descriptionParameter, genreIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetMaxPage(Nullable<int> genreID)
        {
            var genreIDParameter = genreID.HasValue ?
                new ObjectParameter("GenreID", genreID) :
                new ObjectParameter("GenreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetMaxPage", genreIDParameter);
        }
    
        public virtual int AddComment(Nullable<int> bookId, string userId, string comment)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var commentParameter = comment != null ?
                new ObjectParameter("Comment", comment) :
                new ObjectParameter("Comment", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddComment", bookIdParameter, userIdParameter, commentParameter);
        }
    
        public virtual ObjectResult<GetComment_Result> GetComment(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetComment_Result>("GetComment", bookIdParameter);
        }
    }
}
