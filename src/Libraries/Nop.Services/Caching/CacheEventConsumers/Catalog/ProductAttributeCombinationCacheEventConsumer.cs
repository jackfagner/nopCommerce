﻿using Nop.Core.Domain.Catalog;
using Nop.Services.Caching.CachingDefaults;

namespace Nop.Services.Caching.CacheEventConsumers.Catalog
{
    /// <summary>
    /// Represents a product attribute combination cache event consumer
    /// </summary>
    public partial class ProductAttributeCombinationCacheEventConsumer : CacheEventConsumer<ProductAttributeCombination>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductAttributeCombination entity)
        {
            var cacheKey = NopCatalogCachingDefaults.ProductAttributeMappingsAllCacheKey.ToCacheKey(entity.ProductId);
            Remove(cacheKey);

            cacheKey = NopCatalogCachingDefaults.ProductAttributeCombinationsAllCacheKey.ToCacheKey(entity.ProductId);
            Remove(cacheKey);

            RemoveByPrefix(NopCatalogCachingDefaults.ProductAttributesAllPrefixCacheKey);
        }
    }
}
