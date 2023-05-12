using System;
namespace SharedProject.Seedworks
{
    public abstract class BaseEntity<TId, TUser>
    {
        public TId Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public TUser CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = null;
        public TUser UpdatedBy { get; set; }
        public bool Isdeleted { get; set; }
    }
}

