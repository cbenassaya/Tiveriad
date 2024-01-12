#region

using System;
using System.Collections.Generic;

#endregion

namespace Tiveriad.Repositories;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DataReferenceRouteAttribute : Attribute
{
    public DataReferenceRouteAttribute(string route)
    {
        Route = route;
    }
        
    public string Route { get; set; }
}

public interface IDataReference<TKey> : IEntity<TKey>, IWithTenant<TKey> where TKey : IEquatable<TKey>
{
    public InternationalizedString Label { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Visibility Visibility { get; set; }
}

public enum Visibility
{
    Public,
    Private
}

public class DataReferenceBase<TKey> : IDataReference<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey Id { get; set; } = default;
    public virtual TKey OrganizationId { get; set; } = default;
    public virtual InternationalizedString Label { get; set; } = string.Empty;
    public virtual string Description { get; set; } = string.Empty;
    public virtual string Code { get; set; } = string.Empty;
    public virtual Visibility Visibility { get; set; } = Visibility.Private;
}