using System.Globalization;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tiveriad.Commons.Tests;
using Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;
using Xunit;
using Xunit.Sdk;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public class CommandTestModule:TestBase<Startup>
{
    
    [Fact]
    public async Task Add_Entity()
    {
        var repository = GetService<CourseRepository>();
        var course = new Course() { Name = Faker.Company.Name() };

        if (repository == null)
            throw new NullException("repository");
            
        await repository.AddOneAsync(course);
    }
    
    [Fact]
    public async Task Add_Entities_Many_To_Many()
    {
        var courseRepository = GetService<CourseRepository>();
        var studentRepository = GetService<StudentRepository>();
        var context = GetRequiredService<DbContext>();
        
        var initialStudentsCount = studentRepository?.Count();

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

        var  course = courseRepository?.Queryable.RandomElement(x=>true);
        if (course == null)
            throw new NullException("Course");
        
        student.Courses.Add(course);
        
        if (studentRepository == null)
            throw new NullException("studentRepository");
        
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
        
        var initialStudentsCount = studentRepository?.Count();


        var  course = courseRepository?.Queryable.RandomElement(x=>true);
        
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
        
        if (course == null)
            throw new NullException("course");

        var newCourse = new Course
        {
            Name = Faker.Company.Name(),
            Professor = course.Professor
        };
        
        if (courseRepository == null)
            throw new NullException("courseRepository");
        
        await courseRepository.AddOneAsync(newCourse);

        var oldCourse = courseRepository.GetById(course.Id);
        if (oldCourse == null)
            throw new NullException("oldCourse");
        student.Courses.Add(oldCourse);
        student.Courses.Add(newCourse);
        
        if (studentRepository == null)
            throw new NullException("studentRepository");
        await studentRepository.AddOneAsync(student);

        context.SaveChanges(true);
        
       
        Assert.Equal(initialStudentsCount + 1, studentRepository.Count());
    }
    
    
}