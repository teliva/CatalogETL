using CatalogDataTransformer.Models;
using Data.Entities;

namespace CatalogDataTransformer.Maps;

public static class CatalogMapper
{
    public static IList<Models.CatalogTOC> ToDomain(IList<Data.Entities.CatalogTOC> catalogTOCs)
    {
        var lookup = catalogTOCs.ToDictionary(n => n.NodeId, n => new Models.CatalogTOC
        {
            NodeId = n.NodeId,
            NodeName = n.NodeName,
            

        });

        List<Models.CatalogTOC> roots = new();

        foreach (var catalogTOC in catalogTOCs)
        {
            if (catalogTOC.ParentId == 0)
            {
                // Root node
                roots.Add(lookup[catalogTOC.NodeId]);
            }
            else if (lookup.TryGetValue(catalogTOC.ParentId, out var parent))
            {
                parent.TOCNodes.Add(lookup[catalogTOC.NodeId]);
            }
        }

        return roots;
    }
}