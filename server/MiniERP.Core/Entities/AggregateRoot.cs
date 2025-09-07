using System;

namespace MiniERP.Core.Entities;

public interface IAggregateRoot : IEntity
{

    DateTimeOffset CreatedAt { get; set; }
    int CreatedBy { get; set; }

    DateTimeOffset UpdatedAt { get; set; }
    int UpdatedBy { get; set; }
}

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    public string? Reference { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public int CreatedBy { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
    public int UpdatedBy { get; set; }
}