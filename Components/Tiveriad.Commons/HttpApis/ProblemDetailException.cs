namespace Tiveriad.Commons.HttpApis;

/// <summary>
///     A base class for exceptions thrown based on problem detail respose
/// </summary>
public class ProblemDetailException : HttpRequestException
{
    /// <summary>
    ///     Initializes a new instance of the ProblemDetailException class.
    /// </summary>
    /// <param name="problemDetail">The proble detail information</param>
    /// <exception cref="ArgumentNullException">when <paramref name="problemDetail" /> is null</exception>
    public ProblemDetailException(ProblemDetail problemDetail) : base(problemDetail.Title)
    {
        ProblemDetail = problemDetail ?? throw new ArgumentNullException(nameof(problemDetail));
    }


    /// <summary>
    ///     Initializes a new instance of the ProblemDetailException class.
    /// </summary>
    /// <param name="problemDetail">The proble detail information</param>
    /// <param name="innerException">The inner exception</param>
    /// <exception cref="ArgumentNullException">when <paramref name="problemDetail" /> is null</exception>
    public ProblemDetailException(ProblemDetail problemDetail, Exception innerException) : base(problemDetail.Title,
        innerException)
    {
        ProblemDetail = problemDetail ?? throw new ArgumentNullException(nameof(problemDetail));
    }

    /// <summary>
    ///     Gets the problem details for this execption
    /// </summary>
    public ProblemDetail ProblemDetail { get; }
}