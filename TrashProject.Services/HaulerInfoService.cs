using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashProject.Data;
using TrashProject.Models.HaulerInfoModels;

namespace TrashProject.Services
{
    public class HaulerInfoService
    {
        private readonly Guid _userId;

        public HaulerInfoService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHaulerInfo(HaulerInfoCreate model)
        {
            var entity =
                new HaulerInfo()
                {
                    OwnerId = _userId,
                    HaulerName = model.HaulerName,
                    HaulerPhoneNumber = model.HaulerPhoneNumber,
                    HaulerEmail = model.HaulerEmail,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HaulerInformation.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HaulerInfoListItem> GetHaulerInfo()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HaulerInformation
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new HaulerInfoListItem
                                {
                                    HaulerId = e.HaulerId,
                                    HaulerName = e.HaulerName,
                                    CreatedUtc = e.CreatedUtc
                                }
                );

                return query.ToArray();
            }
        }

        public HaulerInfoDetail GetHaulerInfoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HaulerInformation
                        .Single(e => e.HaulerId == id && e.OwnerId == _userId);
                return
                    new HaulerInfoDetail
                    {
                        HaulerId = entity.HaulerId,
                        HaulerName = entity.HaulerName,
                        HaulerEmail = entity.HaulerEmail,
                        HaulerPhoneNumber = entity.HaulerPhoneNumber,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public bool UpdateHaulerInfo(HaulerInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HaulerInformation
                        .Single(e => e.HaulerId == model.HaulerId && e.OwnerId == _userId);

                entity.HaulerName = model.HaulerName;
                entity.HaulerPhoneNumber = model.HaulerPhoneNumber;
                entity.HaulerEmail = model.HaulerEmail;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHaulerInfo(int HaulerInfoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HaulerInformation
                        .Single(e => e.HaulerId == HaulerInfoId && e.OwnerId == _userId);

                ctx.HaulerInformation.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
