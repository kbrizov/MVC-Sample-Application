using System;
using System.Collections.Generic;
using ApplicationMVC.EntityModels;

namespace ApplicationMVC.Data
{
    public static class InMemoryDataContext
    {
        private static IList<TestEntity> data;

        static InMemoryDataContext()
        {
            Data = InitializeData();
        }

        public static IList<TestEntity> Data
        {
            get
            {
                return data;
            }
            
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("data");
                }

                data = value;
            }
        }

        private static IList<TestEntity> InitializeData(int iterations = 100)
        {
            IList<TestEntity> data = new List<TestEntity>();

            for (int index = 1; index <= iterations; index++)
            {
                data.Add(new TestEntity()
                {
                    Id = index,
                    Number = index,
                    Text = string.Format("data: {0}", index)
                });
            }

            return data;
        }
    }
}
