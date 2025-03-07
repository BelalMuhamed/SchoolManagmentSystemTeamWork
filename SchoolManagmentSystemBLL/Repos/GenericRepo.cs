using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
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
        public async Task Add(T item)
        {
           await context.Set<T>().AddAsync(item);
        }

        public async void Delete(int id)
        {
            T DeletedItem =await  GetById(id);
            context.Set<T>().Remove(DeletedItem);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }



        public  void Update(T item)
        {
             context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public async Task AddRange(IEnumerable<T> items)
        {
            await context.Set<T>().AddRangeAsync(items);
        }
        public void DeleteAsync(T Entity)
        {
            context.Set<T>().Remove(Entity);
        }
        public List<T> Filter(Func<T, bool> predicate)
        {
            return context.Set<T>()?.Where(predicate).ToList();
        }
    }
}
