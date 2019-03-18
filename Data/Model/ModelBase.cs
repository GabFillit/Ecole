using System;

namespace Data.Model
{
    public abstract class ModelBase
    {
        public long Id { get; protected set; }
        public Guid Guid { get; protected set; }
        public string Name { get; set; }

        public ModelBase()
        {
            Guid = Guid.NewGuid();
        }
    }
}