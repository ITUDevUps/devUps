namespace minitwit_backend.Data;

public interface IDataMigrationRepository : IDisposable
{
    internal Task<int> TryUpdateMessageDate(int amount = 100);
}