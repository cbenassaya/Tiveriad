using Microsoft.EntityFrameworkCore;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public  class CourseRepository:EFRepository<Course,int>
{
    public CourseRepository(DbContext context) : base(context)
    {
    }
}

public  class StudentRepository:EFRepository<Student,int>
{
    public StudentRepository(DbContext context) : base(context)
    {
        
    }
}

public  class CompanyRepository:EFRepository<Company,int>
{
    public CompanyRepository(DbContext context) : base(context)
    {
    }
}

public  class PersonRepository:EFRepository<Person,int>
{
    public PersonRepository(DbContext context) : base(context)
    {
    }
}

public  class ProfessorRepository:EFRepository<Professor,int>
{
    public ProfessorRepository(DbContext context) : base(context)
    {
    }
}

public  class InvoiceRepository:EFRepository<Invoice,int>
{
    public InvoiceRepository(DbContext context) : base(context)
    {
    }
}