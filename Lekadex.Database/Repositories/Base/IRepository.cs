using Lekadex.Database.Entities.Base;

namespace Lekadex
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        bool AddNew(Entity entity);
        bool Delete(Entity entity);
    }
}
