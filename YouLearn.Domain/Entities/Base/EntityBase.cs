using prmToolkit.NotificationPattern;
using System;

namespace YouLearn.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {


        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }


    }
}
