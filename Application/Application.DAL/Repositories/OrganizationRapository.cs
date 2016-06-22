using Application.DAL.Entities;
using Application.DAL.Interfaces;
using Application.DAL.Models;
using System;
using System.Collections.Generic;


namespace Application.DAL.Repositories
{
    public class OrganizationRepository : IRepository<Organization>
    {
        private AppContext db;

        public OrganizationRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Organization> GetAll()
        {
            return db.Organizations;
        }

        public Organization Get(int id)
        {
            return db.Organizations.Find(id);
        }

        public void Create(Organization book)
        {
            db.Organizations.Add(book);
        }

        public void Update(Organization book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Organization> Find(Func<Organization, Boolean> predicate)
        {
            return db.Organizations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Organization book = db.Organizations.Find(id);
            if (book != null)
                db.Organizations.Remove(book);
        }
    }
}
