﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.domain.Model;

namespace Testes.domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task Delete( Guid id );
        public Task<T> GetById( Guid id );
        public Task<IEnumerable<T>> Search(Func<T, bool> predicate);
        public Task<IEnumerable<T>> GetAll();
    }

}
