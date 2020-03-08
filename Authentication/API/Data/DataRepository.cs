using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataRepository : IDataRepository
    {
        private DataContext Context { get; }

        public DataRepository(DataContext dataContext)
            => Context = dataContext;

        public void Add<T>(T entity) where T : class
            => Context.Add(entity);

        public void Delete<T>(T entity) where T : class
            => Context.Remove(entity);

        public void MapUpdate<T, V>(ref T entity, V DTO, params string[] propsToIgnore)
            where T : class
            where V : class
        {
            if (entity != null && DTO != null)
            {
                Type entityType = typeof(T);
                Type DtoType = typeof(V);
                if (typeof(T) == typeof(V))
                {
                    foreach (System.Reflection.PropertyInfo prop in entityType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                    {
                        object entityPropValue = entityType.GetProperty(prop.Name).GetValue(entity, null);
                        object DtoPropValue = DtoType.GetProperty(prop.Name).GetValue(DTO, null);
                        if (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")
                        {
                            MapUpdate(ref entityPropValue, DtoPropValue);
                        }
                        if (entityPropValue != DtoPropValue)
                        {
                            if (!propsToIgnore.Contains(prop.Name))
                            {
                                entityType.GetProperty(prop.Name).SetValue(entity, DtoPropValue);
                            }

                        }
                    }
                }
            }
        }

        public async Task<bool> SaveAll()
            => await Context.SaveChangesAsync() > 0;
    }
}
