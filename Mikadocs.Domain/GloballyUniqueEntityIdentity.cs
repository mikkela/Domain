using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mikadocs.Domain
{
    [Serializable]
    public abstract class GloballyUniqueEntityIdentity : ValueObject<Guid>
    {
        protected GloballyUniqueEntityIdentity(Guid value) : base(value)
        {
        }
    }

    public static class GloballyUniqueEntityIdentityFactory
    {
        public static T CreateNewEntityIdentity<T>() where T : GloballyUniqueEntityIdentity
        {
            return CreateEntityIdentity<T>(Guid.NewGuid());
        }

        public static T CreateEntityIdentity<T>(Guid value) where T : GloballyUniqueEntityIdentity
        {
            return (T)
                typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                    new[] { typeof(Guid) }, null).Invoke(new object[] { value });
        }
    }
}
