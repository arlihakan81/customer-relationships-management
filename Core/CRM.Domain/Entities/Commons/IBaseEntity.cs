namespace CRM.Domain.Entities.Commons
{
    public interface IBaseEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }

        Guid? CreatedById { get; set; }

        Guid? UpdatedById { get; set; }

        bool IsDeleted { get; set; }

        Guid? DeletedById { get; set; }

        DateTime? DeletedAt { get; set; }

        Guid? OrganizationId { get; set; }


    }
}
