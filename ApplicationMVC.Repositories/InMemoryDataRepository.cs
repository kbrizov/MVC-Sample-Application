using System;
using System.Linq;
using System.Collections.Generic;
using ApplicationMVC.Data;
using ApplicationMVC.EntityModels;

namespace ApplicationMVC.Repositories
{
    public class InMemoryDataRepository : IRepository<TestEntity>
    {
        private IList<TestEntity> dataSet;

        public InMemoryDataRepository()
        {
            this.dataSet = InMemoryDataContext.Data;
        }

        public TestEntity Add(TestEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.dataSet.Add(item);

            return item;
        }

        public void Delete(int id)
        {
            var toBeDeleted = this.GetById(id);
            this.dataSet.Remove(toBeDeleted);
        }

        public IQueryable<TestEntity> GetAll()
        {
            return this.dataSet.AsQueryable();
        }

        public TestEntity GetById(int id)
        {
            var entity = this.GetAll().Where(item => item.Id == id).First();

            return entity;
        }

        public TestEntity Update(int id, TestEntity item)
        {
            var toBeUpdated = this.GetById(id);

            toBeUpdated.Id = item.Id;
            toBeUpdated.Number = item.Number;
            toBeUpdated.Text = item.Text;

            return toBeUpdated;
        }
    }
}
