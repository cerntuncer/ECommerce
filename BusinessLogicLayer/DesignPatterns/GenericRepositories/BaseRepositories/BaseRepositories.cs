using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using DatabaseAccessLayer.Enumerations;
using ECommerce.DatabaseAccessLayer.Contexts;
using ECommerce.DatabaseAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.BaseRepositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Dependency Injection ile alınmalı, ancak DbTool da kullanılabilir.
        protected readonly MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        void Save()
        {
            _db.SaveChanges();
        }

        // --- CUD (Create, Update, Delete) Metotları ---
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public void Delete(T item) // Soft Delete
        {
            item.Status = Status.Passive;
            item.UpdatedDate = DateTime.UtcNow;
            _db.Set<T>().Update(item);
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (var item in list)
            {
                item.Status = Status.Passive;
                item.UpdatedDate = DateTime.UtcNow;
            }
            _db.Set<T>().UpdateRange(list);
            Save();
        }

        public void Destroy(T item) // Hard Delete
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public void SetActive(T item)
        {
            if (item.Status != Status.Active)
            {
                item.Status = Status.Active;
                item.UpdatedDate = DateTime.UtcNow;
                Update(item);
            }
        }

        public void SetPassive(T item)
        {
            if (item.Status != Status.Passive)
            {
                item.Status = Status.Passive;
                item.UpdatedDate = DateTime.UtcNow;
                Update(item);
            }
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            item.UpdatedDate = DateTime.UtcNow;
            _db.SaveChanges();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (var item in list)
            {
                item.UpdatedDate = DateTime.UtcNow;
                _db.Entry(item).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }

        // --- READ (Sorgulama) Metotları ---
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Count(expression);
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            // Global Query Filter (MyContext'teki) sayesinde sadece aktif ve pasifler gelir.
            return _db.Set<T>().ToList();
        }

        public List<T> GetActives()
        {
            // Global Query Filter ayarlandığı için bu metodun GetActives() yerine 
            // GetAll() olarak kullanılması daha mantıklıdır. Yine de tanımı tutalım.
            return _db.Set<T>().Where(x => x.Status == Status.Active).ToList();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetDeleteds()
        {
            return _db.Set<T>().Where(x => x.Status == Status.Passive).ToList();
        }

        public List<T> GetModifieds()
        {
            return _db.Set<T>().Where(x => x.UpdatedDate.HasValue).ToList();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> selector)
        {
            return _db.Set<T>().Select(selector);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        public void UpdateRange(List<List<T>> list)
        {
            throw new NotImplementedException();
        }
    }
}