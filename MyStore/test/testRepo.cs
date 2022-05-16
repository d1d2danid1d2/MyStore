using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.test
{
    public interface ItestRepo
    {
        Category GetById(int id);
    }
    public class testRepo : ItestRepo
    {
        private readonly StoreContext context;

        public testRepo(StoreContext context)
        {
            this.context = context;
        }
        public Category GetById(int id)
        { 
            return context.Categories.Find(id);
        }
          
    }
}
