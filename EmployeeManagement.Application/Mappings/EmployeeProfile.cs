using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Domain.Aggregates;

namespace EmployeeManagement.Application.Mappings;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<ViewEmployee, Employee>().ReverseMap();
        CreateMap<FormEmployee, Employee>().ReverseMap();
        CreateMap<FormEmployee, ViewEmployee>().ReverseMap();
    }
}