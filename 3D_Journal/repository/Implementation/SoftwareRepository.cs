using domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repository.Implementation
{
    public class SoftwareRepository:ISoftwareRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Software> entities;

        public SoftwareRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Software>();
        }
        public List<Software> GetAllWithLogo()
        {
            return entities.Include(x => x.Logo).ToListAsync().Result;
        }

        public List<Software> GetAllWithLogoFromIdList(List<Guid> ids)
        {
            return entities.Include(x => x.Logo).ToListAsync().Result.Where(x=>ids.Contains(x.Id)).ToList();
        }

        public Software GetWithLogo(Guid id)
        {
            return entities.Include(x => x.Logo).ToListAsync().Result.Where(x => id==x.Id).FirstOrDefault();
        }
    }
}
