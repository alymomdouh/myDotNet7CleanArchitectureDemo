﻿namespace CleanArchitectureDemo.Domain.Common
{
    public interface IAuditableEntity : IEntity
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
