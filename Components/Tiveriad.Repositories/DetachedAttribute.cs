#region

using System;

#endregion

namespace Tiveriad.Repositories;

[AttributeUsage(AttributeTargets.Property)]
public sealed class DetachedAttribute : Attribute
{
}