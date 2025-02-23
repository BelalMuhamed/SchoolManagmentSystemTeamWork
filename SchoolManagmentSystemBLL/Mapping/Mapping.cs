﻿using AutoMapper;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagmentSystemDAL.ViewModels;
using SchoolManagmentSystem.DAL.Extend;


namespace SchoolManagmentSystemBLL.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentVM>().AfterMap((src, desc) => {
                
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
            CreateMap<ApplicationUser, StudentVM>().AfterMap((src, desc) => {

                desc.StudentName = src.UserName;
                desc.StudentEmail = src.Email;
                desc.PhoneNumber = src.PhoneNumber;
                desc.Address = src.Address;
                desc.DateOfBirth = src.DateOfBirth;
                desc.gender = src.Gender;
                desc.HireDate = src.HireDate;
                desc.Password = src.PasswordHash;
                

               
            }).ReverseMap().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.StudentName))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.StudentEmail))
    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); ;
            
        }
    }
}
