using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HelloMvvm.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task Add(string firstname, string lastname)
        {
            Debug.WriteLine($"Adding employee {firstname} {lastname}");
            return Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}