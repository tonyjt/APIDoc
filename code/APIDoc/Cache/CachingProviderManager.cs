using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace Caching
{
    public class CachingProviderManager
    {
        //Initialization related variables and logic
        private static bool isInitialized = false;
        private static Exception initializationException;

        private static object initializationLock = new object();

        static CachingProviderManager()
        {
            Initialize();
        }

        public static CachingProviderBase Provider
        {
            get
            {
                if (!isInitialized)
                {
                    Initialize();
                }
                return defaultProvider;
            }
        }

        public static CachingProviderCollection Providers
        {
            get
            {
                if (!isInitialized)
                {
                    Initialize();
                }
                return providerCollection;
            }
        }

      //Public feature API
        private static CachingProviderBase defaultProvider;
        private static CachingProviderCollection providerCollection;

        private static void Initialize()
        {

            try
            {
                //Get the feature's configuration info
                CachingConfiguation qc =
                    (CachingConfiguation)ConfigurationManager.GetSection("CachingProvider");

                if (qc.DefaultProvider == null || qc.Providers == null || qc.Providers.Count < 1)
                    throw new ProviderException("You must specify a valid default provider.");

                //Instantiate the providers
                providerCollection = new CachingProviderCollection();
                ProvidersHelper.InstantiateProviders(qc.Providers, providerCollection, typeof(CachingProviderBase));
                providerCollection.SetReadOnly();
                defaultProvider = providerCollection[qc.DefaultProvider];
                if (defaultProvider == null)
                {
                    throw new ConfigurationErrorsException(
                        "You must specify a default provider for the feature.",
                        qc.ElementInformation.Properties["defaultProvider"].Source,
                        qc.ElementInformation.Properties["defaultProvider"].LineNumber);
                }
            }
            catch (Exception ex)
            {
                initializationException = ex;
                isInitialized = true;
                throw ex;
            }

            isInitialized = true; //error-free initialization
        }
    }
}
