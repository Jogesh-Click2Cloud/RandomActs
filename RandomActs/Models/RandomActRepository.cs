using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RandomActs.Models
{ 
    public class RandomActRepository : IRandomActRepository
    {
        RAOKContext context = new RAOKContext();

        public IQueryable<RandomAct> All
        {
            get { return context.RandomActs; }
        }

        public IQueryable<RandomAct> AllIncluding(params Expression<Func<RandomAct, object>>[] includeProperties)
        {
            IQueryable<RandomAct> query = context.RandomActs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public RandomAct Find(int id)
        {
            return context.RandomActs.Find(id);
        }

        public void InsertOrUpdate(RandomAct randomact)
        {
            if (randomact.RandomActId == default(int)) {
                // New entity
                context.RandomActs.Add(randomact);
            } else {
                // Existing entity
                context.Entry(randomact).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var randomact = context.RandomActs.Find(id);

            // First delete the RandomActActors
            IQueryable<RandomActActor> raa = context.RandomActActors.Where(x => x.RandomActId == id);
            context.RandomActActors.RemoveRange(raa);

            // And then delete the RandomAct
            context.RandomActs.Remove(randomact);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}