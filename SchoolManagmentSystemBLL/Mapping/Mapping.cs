using AutoMapper;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagmentSystemDAL.ViewModels;


namespace SchoolManagmentSystemBLL.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentVM>().AfterMap((src, desc) => {
                desc.StudentId = src.UserId;
                desc.StudentName = src.User.UserName;
                desc.StudentEmail = src.User.Email;
                desc.PhoneNumber = src.User.PhoneNumber;
                desc.Address = src.User.Address;
                desc.DateOfBirth = src.User.DateOfBirth;
                desc.gender = src.User.Gender;
                desc.HireDate = src.User.HireDate;
              
                src.ClassId = src.ClassId;
                desc.ClassName = src.Class.Name;
                desc.Password = src.User.PasswordHash;
            }).ReverseMap();
        }
    }
}
