using AutoMapper;
using WebApiDbMigrations.Entity;
using WebApiDbMigrations.Models;

namespace WebApiDbMigrations.EmpMapping
{
    public class APIMapping:Profile
    {
        public APIMapping()
        {
            //CreateMap<Student, StudentsDetailDto>();
            CreateMap<Employee, EmpViewModel>();
        }
    }
}
