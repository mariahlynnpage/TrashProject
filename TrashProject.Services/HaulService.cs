using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrashProject.Data;
using TrashProject.Models.HaulModels;

namespace TrashProject.Services
{
    public class HaulService
    {



        private readonly Guid _userId;

        public HaulService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHaul(HaulCreate model)
        {
            var entity =
                new Haul()
                {
                    OwnerId = _userId,
                    CompactorId = model.CompactorId,
                    HaulerInfoId = model.HaulerInfoId,
                    PropertyId = model.PropertyId,
                    PropertyContactId = model.PropertyContactId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Hauls.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        public IEnumerable<HaulListItem> GetHaul()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Hauls
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new HaulListItem
                                {
                                    HaulId = e.HaulId,
                                    Compactor = e.Compactor,
                                    HaulerName = e.HaulerInfo,
                                    PropertyName = e.Property,
                                    PropertyContactName = e.PropertyContact,
                                    CreatedUtc = e.CreatedUtc
                                }
                );

                return query.ToArray();
            }
        }

        public HaulDetail GetHaulById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hauls
                        .Single(e => e.HaulId == id && e.OwnerId == _userId);
                return
                    new HaulDetail
                    {
                        HaulId = entity.HaulId,
                        CompactorId = entity.CompactorId,
                        Compactor = entity.Compactor,
                        HaulerInfoId = entity.HaulerInfoId,
                        HaulerInfo = entity.HaulerInfo,
                        PropertyContactId = entity.PropertyContactId,
                        PropertyContact = entity.PropertyContact,
                        PropertyId = entity.PropertyId,
                        Property = entity.Property,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public HaulEdit GetHaulEditById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hauls
                        .Single(e => e.HaulId == id && e.OwnerId == _userId);
                    var haulEdit = new HaulEdit
                    {
                        HaulId = entity.HaulId,
                        CompactorId = entity.CompactorId,
                        HaulerInfoId = entity.HaulerInfoId,
                        PropertyContactId = entity.PropertyContactId,
                        PropertyId = entity.PropertyId,
                    };

                haulEdit.Compactors = new List<SelectListItem>();
                haulEdit.HaulerInformation = new List<SelectListItem>();
                haulEdit.PropertyContacts = new List<SelectListItem>();
                haulEdit.Properties = new List<SelectListItem>();

                return haulEdit;
            }
        }

        public bool UpdateHaul(HaulEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hauls
                        .Single(e => e.HaulId == model.HaulId && e.OwnerId == _userId);

                entity.CompactorId = model.CompactorId;
                entity.HaulerInfoId = model.HaulerInfoId;
                entity.PropertyId = model.PropertyId;
                entity.PropertyContactId = model.PropertyContactId;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteHaul(int HaulId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hauls
                        .Single(e => e.HaulId == HaulId && e.OwnerId == _userId);

                ctx.Hauls.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
