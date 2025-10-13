namespace CatalogDataTransformer.Maps;

public static class CatalogMapper
{
    public static Models.CatalogTOC? ToDomain(IList<Data.Entities.CatalogTOC> catalogTOCs)
    {
        if (catalogTOCs == null || catalogTOCs.Count == 0)
            return null;

        var lookup = catalogTOCs.ToDictionary(n => n.NodeId, n => new Models.CatalogTOC
        {
            NodeId = n.NodeId,
            NodeName = n.NodeName,
            TOCProducts = ToDomain(n.TOCProducts),
            ParentId = n.ParentId,
            Left = n.Left,
            Right = n.Right
        });

        var roots = catalogTOCs
            .Where(n => n.ParentId == 0)
            .Select(n => lookup[n.NodeId])
            .ToList();

        foreach (var node in catalogTOCs.Where(n => n.ParentId != 0))
        {
            if (lookup.TryGetValue(node.ParentId, out var parent))
            {
                parent.TOCNodes.Add(lookup[node.NodeId]);
            }
        }

        return roots[0];
    }

    public static Models.TOCProduct ToDomain(Data.Entities.TOCProduct tocProduct)
    {
        return new Models.TOCProduct
        {
            ProductId = tocProduct.ProductId,
            NodeId = tocProduct.NodeId,
            SeqNo = tocProduct.SeqNo,
            ModelNumber = tocProduct.Product.StyleNumber,
            Description = tocProduct.Product.CatalogGenericDescription?.Description ?? string.Empty,
            EnhancedDescription = tocProduct.Product.CatalogGenericDescription?.Description ?? string.Empty
        };
    }

    public static IList<Models.TOCProduct> ToDomain(IList<Data.Entities.TOCProduct> tocProducts) =>
        tocProducts?.Select(ToDomain)
                    .Where(p => p != null)
                    .ToList()
        ?? new List<Models.TOCProduct>();
}
