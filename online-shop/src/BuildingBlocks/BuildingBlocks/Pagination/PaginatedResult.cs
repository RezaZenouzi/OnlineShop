namespace BuildingBlocks.Pagination;

public class PaginatedResult<TEntity>
    where TEntity : class
{
    private static int _pageIndex;
    private static int _pageSize;
    private static long _count;
    private static IEnumerable<TEntity> _data;

    public PaginatedResult(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    {
        _pageIndex = pageIndex;
        _pageSize = pageSize;
        _count = count;
        _data = data;
    }

    public int PageIndex { get; } = _pageIndex;
    public int PageSize { get; } = _pageSize;
    public long Count { get; } = _count;
    public IEnumerable<TEntity> Data { get; } = _data;
}