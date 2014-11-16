using System.Data;

// ReSharper disable once CheckNamespace
namespace CLZDoctor.Domain
{
    public interface IBaseRepo
    {
        IDbConnection OpenConnection();
    }
}
