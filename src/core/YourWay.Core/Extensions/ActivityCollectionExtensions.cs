using YourWay.Activities;

namespace YourWay.Extensions;

public static class ActivityCollectionExtensions
{
    public static IEnumerable<IActivity> Find(this IEnumerable<IActivity> collection, IEnumerable<Guid> ids)
    {
        var idList = ids?.ToList();
        return idList != null ? collection.Where(x => idList.Contains(x.Id)) : default;
    }
}