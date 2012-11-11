using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace Caching
{
    public class CachingProviderCollection : ProviderCollection
    {
            public override void Add(ProviderBase provider)
            {
                if (provider == null)
                    throw new ArgumentNullException("The provider parameter cannot be null.");

                if (!(provider is CachingProviderBase))
                    throw new ArgumentException("The provider parameter must be of type CachingProviderBase.");

                base.Add(provider);
            }

            new public CachingProviderBase this[string name]
            {
                get { return (CachingProviderBase)base[name]; }
            }

            public void CopyTo(CachingProviderBase[] array, int index)
            {
                base.CopyTo(array, index);
            }
        
    }
}
