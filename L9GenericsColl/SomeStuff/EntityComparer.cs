using L9GenericsColl.Entities;
using System;


namespace L9GenericsColl.SomeStuff
{
    public class EntityComparer<T>  where T : BaseEntity
    {
        public virtual void CompareId(BaseEntity x, BaseEntity y)
        {
            if (Equals(x.Id, y.Id))
            {
                Console.WriteLine("You have two users with the same id");
            }
            else
            {
                Console.WriteLine("No problems with id");
            }
        }
    }
}
