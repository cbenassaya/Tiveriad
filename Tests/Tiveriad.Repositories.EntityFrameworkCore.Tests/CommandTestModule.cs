using System.Globalization;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tiveriad.Commons.Tests;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;
using Xunit;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class CommandTestModule:TestBase<Startup>
{
    
    [Fact]
    public async Task Add_Entity()
    {
        var repository = GetService<CourseRepository>();
        var course = new Course() { Name = Faker.Company.Name() };
        await repository.AddOneAsync(course);
    }
    
    [Fact]
    public async Task Add_Entities_Many_To_Many()
    {
        var courseRepository = GetService<CourseRepository>();
        var studentRepository = GetService<StudentRepository>();
        var context = GetRequiredService<DbContext>();
        
        var initialStudentsCount = studentRepository.Count();

        var student =  new Student
        {
            Firstname = Faker.Name.First(),
            Lastname = Faker.Name.Last(),
            Email = Faker.Internet.Email(),
            City = Faker.Address.City(),
            Country = Faker.Address.Country(),
            StreetAddress = Faker.Address.StreetAddress(),
            Courses = new HashSet<Course>()
        };

        var  course = courseRepository.Queryable.RandomElement(x=>true);

        var state = context.Entry(course).State;
        
        student.Courses.Add(course);
        await studentRepository.AddOneAsync(student);

        context.SaveChanges(true);
        Assert.Equal(initialStudentsCount + 1, studentRepository.Count());
    }
    
    [Fact]
    public async Task Add_Entities_Many_To_Many_With_NewChild()
    {
        var courseRepository = GetService<CourseRepository>();
        var studentRepository = GetService<StudentRepository>();
        var context = GetRequiredService<DbContext>();
        
        var initialStudentsCount = studentRepository.Count();


        var  course = courseRepository.Queryable.RandomElement(x=>true);
        
        var student =  new Student
        {
            Firstname = Faker.Name.First(),
            Lastname = Faker.Name.Last(),
            Email = Faker.Internet.Email(),
            City = Faker.Address.City(),
            Country = Faker.Address.Country(),
            StreetAddress = Faker.Address.StreetAddress(),
            Courses = new HashSet<Course>()
        };

        var newCourse = new Course
        {
            Name = Faker.Company.Name(),
            Professor = course.Professor
        };
        
        await courseRepository.AddOneAsync(newCourse);
        
        student.Courses.Add(courseRepository.GetById(course.Id));
        student.Courses.Add(newCourse);
        await studentRepository.AddOneAsync(student);

        context.SaveChanges(true);
        
       
        Assert.Equal(initialStudentsCount + 1, studentRepository.Count());
    }
    
    
}