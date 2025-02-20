using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.IGenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.GenericRepo
{
    public class GenericRepo<T> : IgenericRepo<T> where T : class
    {
        public readonly ApplicationDbContext context;

        public GenericRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T DeletedItem = GetById(id);
            context.Set<T>().Remove(DeletedItem);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }



        public void Update(T item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}
