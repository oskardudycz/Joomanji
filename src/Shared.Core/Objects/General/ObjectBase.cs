using Shared.Core.Core;
using Shared.Objects.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Objects
{
    public class ObjectBase : IBusinessObject
    {
    }

    public abstract class ObjectWithIdBase : ObjectBase, IHasId
    {
        object IHasId.ID { get; set; }
    }

    public abstract class ObjectWithIdBase<T> : IHasId<T>
    {
        public T ID { get; set; }

        object IHasId.ID
        {
            get { return ID; }
            set { ID = (T)value; }
        }
    }

    public abstract class ObjectWithGuidIdBase : ObjectWithIdBase<Guid>, IHasGuidId
    {
    }

    public abstract class ObjectWithIntIdBase :ObjectWithIdBase<int>, IHasIntId
    {
    }
}
