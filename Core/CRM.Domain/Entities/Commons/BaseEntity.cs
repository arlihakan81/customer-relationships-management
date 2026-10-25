namespace CRM.Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey> : IBaseEntity
    {
        public abstract TKey Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public abstract Guid? CreatedById { get; set; }

        public Guid? UpdatedById { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid? DeletedById { get; set; }

        public DateTime? DeletedAt { get; set; }

        public abstract Guid? OrganizationId { get; set; }

        public virtual User? CreatedBy { get; set; }
        public virtual User? UpdatedBy { get; set; }
        public virtual User? DeletedBy { get; set; }

        public virtual Organization? Organization { get; set; }


    }
}
