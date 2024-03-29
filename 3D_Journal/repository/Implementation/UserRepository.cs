﻿using domain.Identity;
using Microsoft.EntityFrameworkCore;
using repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<AppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<AppUser>();
        }
        public IEnumerable<AppUser> GetAll()
        {
            return entities
                .Include(z => z.ProfileImage)
                .Include(z => z.Projects)
                .Include("Projects.LikedByUsers")
                .Include("Projects.MainImage")
                .Include("Projects.PurchasedBy")
                .Include(z => z.PurchasedProjects)
                .Include("PurchasedProjects.Project")
                .AsEnumerable();
        }

        public AppUser Get(string id)
        {
            return entities
               .Include(z => z.ProfileImage)
               .Include(z=>z.Projects)
               .Include("Projects.LikedByUsers")
               .Include("Projects.MainImage")
               .Include("Projects.PurchasedBy")
               .Include(z=>z.PurchasedProjects)
               .Include("PurchasedProjects.Project")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<AppUser> search(string text)
        {
            return entities
              .Include(z => z.ProfileImage)
              .Where(x => x.Email.Contains(text) || x.FirstName.Contains(text) || x.LastName.Contains(text))
              .ToListAsync().Result;
        }
    }
}
