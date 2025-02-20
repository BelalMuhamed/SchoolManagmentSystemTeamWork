using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.IGenericRepos
{
    public interface IgenericRepo<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);


        public void Delete(int id);
        public void Update(T item);
        public Task Add(T item);

    }
}
