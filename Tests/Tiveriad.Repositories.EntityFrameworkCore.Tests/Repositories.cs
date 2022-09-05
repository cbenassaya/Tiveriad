using Microsoft.EntityFrameworkCore;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class CourseRepository : EFRepository<Course, string>
{
    public CourseRepository(DbContext context) : base(context)
    {
    }
}

public class StudentRepository : EFRepository<Student, string>
{
    public StudentRepository(DbContext context) : base(context)
    {
    }
}

public class CompanyRepository : EFRepository<Company, string>
{
    public CompanyRepository(DbContext context) : base(context)
    {
    }
}

public class PersonRepository : EFRepository<Person, string>
{
    public PersonRepository(DbContext context) : base(context)
    {
    }
}

public class ProfessorRepository : EFRepository<Professor, string>
{
    public ProfessorRepository(DbContext context) : base(context)
    {
    }
}

public class InvoiceRepository : EFRepository<Invoice, string>
{
    public InvoiceRepository(DbContext context) : base(context)
    {
    }
}