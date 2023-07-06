using CleanArchitectureDemo.Domain.Common.Interfaces;

namespace CleanArchitectureDemo.Domain.Common
{
    /// <summary>
    /// This class is the child class of BaseEntity and it implements the IAuditableEntity interface defined above.
    /// </summary>
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
