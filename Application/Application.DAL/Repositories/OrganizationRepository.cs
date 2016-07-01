using Application.DAL.EF;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Application.DAL.Repositories
{
    public class OrganizationRepository : IRepository<OrganizationEntity>
    {
        private AppContext db;

        public OrganizationRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrganizationEntity> GetAll()
        {
            return db.Organizations;
        }

        public OrganizationEntity Get(int id)
        {
            return db.Organizations.Find(id);
        }

        public void Create(OrganizationEntity book)
        {
            db.Organizations.Add(book);
        }

        public void Update(OrganizationEntity book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<OrganizationEntity> Find(Func<OrganizationEntity, Boolean> predicate)
        {
            return db.Organizations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            OrganizationEntity organization = db.Organizations.Find(id);
            if (organization != null)
                db.Organizations.Remove(organization);
        }
    }
}
