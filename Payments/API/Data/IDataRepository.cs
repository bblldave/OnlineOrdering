using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        // TODO: Getters

        void MapUpdate<T, V>(ref T entity, V DTO, params string[] propsToIgnore)
            where T : class
            where V : class;
    }
}
