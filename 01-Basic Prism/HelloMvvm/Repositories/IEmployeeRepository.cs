using System.Threading.Tasks;

namespace HelloMvvm.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(string firstname, string lastname);
    }
}