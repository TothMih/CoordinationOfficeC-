using CoordinatorOffice.ApiClient.Models;
using CoordinatorOffice.ApiClient.Models.DTO;
using System.Text.Json;

namespace CoordinatorOffice.ApiClient.Repositories
{
    public interface IPagerRepository<T> : IGenericRepository<T>
    {
        public Task<TableDTO<T>> GetAllAsync(
            int page = 0,
            int itemsPerPage = 0,
            string? search = null,
            string? sortBy = null,
            bool ascending = true,
            JwtToken actual = null
            );
    }
}
