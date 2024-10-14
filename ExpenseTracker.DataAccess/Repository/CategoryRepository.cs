﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.DataAccess.Repository.IRepository;
using ExpenseTrackerWeb.Data;
using ExpenseTrackerWeb.Models;

namespace ExpenseTracker.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
