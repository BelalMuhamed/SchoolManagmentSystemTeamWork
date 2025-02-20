using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.IGenericRepos
{
    public interface IgenericRepo<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);


        public void Delete(int id);
        public void Update(T item);
        public void Add(T item);

    }
}
