using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Repositories.Tests.Models;

public class Book
{
    public InternationalizedString Title { get; set; } = string.Empty;
}

public class BookModel
{
    public string Title { get; set; } = string.Empty;
}