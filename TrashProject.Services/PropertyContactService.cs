using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashProject.Data;
using TrashProject.Models.PropertyContactModels;

namespace TrashProject.Services
{
    public class PropertyContactService
    {
        private readonly Guid _userId;

        public PropertyContactService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePropertyContact(PropertyContactCreate model)
        {
            var entity =
                new PropertyContact()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PropContactEmail = model.PropContactEmail,
                    PropContactPhoneNumber = model.PropContactPhoneNumber,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PropertyContacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PropertyContactListItem> GetPropertyContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PropertyContacts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PropertyContactListItem
                                {
                                    PropertyContactId = e.PropertyContactId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CreatedUtc = e.CreatedUtc
                                }
                );

                return query.ToArray();
            }
        }

        public PropertyContactDetail GetPropertyContactById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PropertyContacts
                        .Single(e => e.PropertyContactId == id && e.OwnerId == _userId);
                return
                    new PropertyContactDetail
                    {
                        PropertyContactId = entity.PropertyContactId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PropContactPhoneNumber = entity.PropContactPhoneNumber,
                        PropContactEmail = entity.PropContactEmail,
                        PropContactPosition = entity.PropContactPosition,
                        CreatedUtc = entity.CreatedUtc,
                        
                    };
            }
        }

        public bool UpdatePropertyContact(PropertyContactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PropertyContacts
                        .Single(e => e.PropertyContactId == model.PropertyContactId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PropContactEmail = model.PropContactEmail;
                entity.PropContactPhoneNumber = model.PropContactPhoneNumber;
                entity.PropContactPosition = model.PropContactPosition;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePropertyContact(int PropertyContactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PropertyContacts
                        .Single(e => e.PropertyContactId == PropertyContactId && e.OwnerId == _userId);

                ctx.PropertyContacts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

