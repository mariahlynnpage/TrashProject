using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashProject.Data;
using TrashProject.Models.PropertyModels;

namespace TrashProject.Services
{
    public class PropertyService
    {
        private readonly Guid _userId;

        public PropertyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property()
                {
                    OwnerId = _userId,
                    PropertyName = model.PropertyName,
                    Address = model.Address,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Properties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PropertyListItem> GetProperties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Properties
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PropertyListItem
                                {
                                    PropertyId = e.PropertyId,
                                    PropertyName = e.PropertyName,
                                    CreatedUtc = e.CreatedUtc
                                }
                );

                return query.ToArray();
            }
        }

        public PropertyDetail GetPropertyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Properties
                        .Single(e => e.PropertyId == id && e.OwnerId == _userId);
                return
                    new PropertyDetail
                    {
                        PropertyId = entity.PropertyId,
                        PropertyName = entity.PropertyName,
                        Address = entity.Address,
                        CreatedUtc = entity.CreatedUtc,

                    };
            }
        }

        public bool UpdateProperty(PropertyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Properties
                        .Single(e => e.PropertyId == model.PropertyId && e.OwnerId == _userId);

                entity.PropertyName = model.PropertyName;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProperty(int PropertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Properties
                        .Single(e => e.PropertyId == PropertyId && e.OwnerId == _userId);

                ctx.Properties.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
