namespace Tiveriad.Pipelines.Tests.Models;

public class Model
{
    public DateTime? DateTime { get; set; }
}

public class Middleware : IMiddleware<Model, Context, Configuration>
{
    public Configuration Configuration { get; set; }

    public void Run(Context context, Model model)
    {
        model.DateTime = DateTime.Now;
    }
}