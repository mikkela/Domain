using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mikadocs.Domain
{
    [Serializable]
    public abstract class NumberBasedEntityIdentity : ValueObject<long>
    {
        protected NumberBasedEntityIdentity(long value) : base(value)
        {
        }
    }

    public static class NumberBasedEntityIdentityFactory
    {
        public static T CreateEntityIdentity<T>(long value) where T : NumberBasedEntityIdentity
        {
            return (T)
                typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                    new[] { typeof(long) }, null).Invoke(new object[] { value });
        }
    }
}
