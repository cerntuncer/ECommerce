using ECommerce.DatabaseAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // --- CUD (Create, Update, Delete) & Durum Yönetimi ---
        void Add(T item);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<List<T>> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);
        void SetActive(T item);
        void SetPassive(T item);

        // --- Sorgulama (Read) ---
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetDeleteds();
        List<T> GetModifieds();

        T Find(int id);
        T GetById(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
        IQueryable<X> Select<X>(Expression<Func<T, X>> selector);
    }
}