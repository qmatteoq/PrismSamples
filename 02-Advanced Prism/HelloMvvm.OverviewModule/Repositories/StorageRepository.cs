using System.Diagnostics;

namespace HelloMvvm.OverviewModule.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        public void AddItem(string item)
        {
            Debug.WriteLine($"Item added: {item}");
        }
    }
}
