using L9GenericsColl.Enums;


namespace L9GenericsColl.Entities
{
    public abstract class User : BaseEntity
    {
        
        public string Name { get; set; }

        public UserState State { get; set; }


    }
}
