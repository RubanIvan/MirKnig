//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Book Book { get; set; }
    }
}
