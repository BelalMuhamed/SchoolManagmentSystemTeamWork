using AutoMapper;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystemDAL.ViewModels;
using SchoolManagmentSystem.DAL.Extend;
using Microsoft.AspNetCore.Routing.Constraints;

namespace SchoolManagmentSystemBLL.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentVM>().AfterMap((src, desc) => {
                desc.UserId = src.UserId;
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
                desc.UserId = src.Id;

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

            CreateMap<Student, EditStudentVM>().AfterMap((src, desc) => {
                desc.StudentId = src.User.Id;
                desc.StudentName = src.User.UserName;
                desc.StudentEmail = src.User.Email;
                desc.PhoneNumber = src.User.PhoneNumber;
                desc.Address = src.User.Address;
                desc.DateOfBirth = src.User.DateOfBirth;
                desc.gender = src.User.Gender;
                desc.HireDate = src.User.HireDate;

                src.ClassId = src.ClassId;
                desc.ClassName = src.Class.Name;
               
            }).ReverseMap();
            CreateMap<EditStudentVM, Student>().AfterMap((src, desc) => {

                desc.User.UserName = src.StudentName;
                desc.User.Email = src.StudentEmail;
                desc.User.PhoneNumber = src.PhoneNumber;
                desc.User.Address = src.Address;
                desc.User.DateOfBirth = src.DateOfBirth;
                desc.User.Gender = src.gender;
                desc.User.HireDate = src.HireDate;
                desc.ClassId = src.ClassId;

            });
            CreateMap<Class, ClassVM>().AfterMap((src, desc) => {

                desc.ClassId = src.Id;
                desc.ClassName = src.Name;
                desc.ManagerId = src.ManagerId;
                desc.ManagerName = src.User.UserName;
                desc.Subjects = src.classsubjesct.Where(c => c.classId == desc.ClassId).Select(s => s.Subject).ToList();

            });
            CreateMap<Teacher, TeacherVM>().AfterMap((src, desc) => {
                desc.UserId = src.UserId;
                desc.TeacherName = src.User.UserName;
                desc.TeacherEmail = src.User.Email;
                desc.PhoneNumber = src.User.PhoneNumber;
                desc.Address = src.User.Address;
                desc.DateOfBirth = src.User.DateOfBirth;
                desc.gender = src.User.Gender;
                desc.HireDate = src.User.HireDate;
                desc.Password = src.User.PasswordHash;
            }).ReverseMap();
            CreateMap<ApplicationUser, TeacherVM>().AfterMap((src, desc) => {
                desc.UserId = src.Id;
                desc.TeacherName = src.UserName;
                desc.TeacherEmail = src.Email;
                desc.PhoneNumber = src.PhoneNumber;
                desc.Address = src.Address;
                desc.DateOfBirth = src.DateOfBirth;
                desc.gender = src.Gender;
                desc.HireDate = src.HireDate;
                desc.Password = src.PasswordHash;
            }).ReverseMap().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.TeacherName))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.TeacherEmail))
             .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<Teacher, EditTeacherVM>().AfterMap((src, desc) => {
                desc.TeacherId = src.UserId;
                desc.TeacherName = src.User.UserName;
                desc.TeacherEmail = src.User.Email;
                desc.PhoneNumber = src.User.PhoneNumber;
                desc.Address = src.User.Address;
                desc.DateOfBirth = src.User.DateOfBirth;
                desc.gender = src.User.Gender;
                desc.HireDate = src.User.HireDate;
            }).ReverseMap();
            CreateMap<TeacherAttendance, TeacherAttendanceVM>().AfterMap((src, desc) => {
                desc.TeacherId = src.TeacherId;
                desc.TeacherName = src.teacher.User.UserName;
                desc.Date = src.Date;
                desc.Status = src.Status;
            }).ReverseMap();
            CreateMap<Teacher, TeacherAttendanceVM>().AfterMap((src, desc) => {
                desc.TeacherId = src.UserId;
                desc.TeacherName = src.User.UserName;
                
            }).ReverseMap();

            CreateMap<Exam, ExamVM>().AfterMap((src, desc) => {
                desc.TeacherId = src.TeacherId;
                desc.Time = src.Time;
                desc.TotalDegree = src.TotalDegree;
                desc.MinDegree = src.MinDegree;
            }).ReverseMap();

            CreateMap<Question, QuestionVM>()
           .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
           .ReverseMap();

            CreateMap<Answer, AnswerVM>().ReverseMap();
        }








            }
          
        }


    

        

    
