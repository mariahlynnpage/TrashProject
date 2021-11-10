using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashProject.Data;
using TrashProject.Models.CompactorModels;

namespace TrashProject.Services
{
    public class CompactorService
    {
        private readonly Guid _userId;

        public CompactorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompactor(CompactorCreate model)
        {
            var entity =
                new Compactor()
                {
                    OwnerId = _userId,
                    CompactorName = model.CompactorName,
                    IsContaminated = model.IsContaminated,
                    IsTrash = model.IsTrash,
                    IsDryWaste = model.IsDryWaste,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Compactors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompactorListItem> GetCompactors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Compactors
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CompactorListItem
                                {
                                    CompactorId = e.CompactorId,
                                    CompactorName = e.CompactorName,
                                    CreatedUtc = e.CreatedUtc
                                }
                );

                return query.ToArray();
            }
        }

        public CompactorDetail GetCompactorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Compactors
                        .Single(e => e.CompactorId == id && e.OwnerId == _userId);
                return
                    new CompactorDetail
                    {
                        CompactorId = entity.CompactorId,
                        CompactorName = entity.CompactorName,
                        IsDryWaste = entity.IsDryWaste,
                        IsTrash = entity.IsTrash,
                        IsContaminated = entity.IsContaminated,
                    };
            }
        }

        public bool UpdateCompactor(CompactorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Compactors
                        .Single(e => e.CompactorId == model.CompactorId && e.OwnerId == _userId);

                entity.CompactorName = model.CompactorName;
                entity.IsContaminated = model.IsContaminated;
                entity.IsDryWaste = model.IsDryWaste;
                entity.IsTrash = model.IsTrash;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompactor(int CompactorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Compactors
                        .Single(e => e.CompactorId == CompactorId && e.OwnerId == _userId);

                ctx.Compactors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
