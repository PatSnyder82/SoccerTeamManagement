using Core.Abstractions;

namespace Services.Abstractions
{
    public interface ILookupServiceBase<T> : IEntityServiceBase<T> where T : LookupBase
    {
    }
}