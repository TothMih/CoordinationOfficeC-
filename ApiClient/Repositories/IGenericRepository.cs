using CoordinatorOffice.ApiClient.Models;

namespace CoordinatorOffice.ApiClient.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<ActualCoordinator> GetRefreshTokenAsync(JwtToken actual);
        Task<HttpResponseMessage> NewItemAsync(T entity, JwtToken actual);
        Task<HttpResponseMessage> ChangeItemAsync(T entity, JwtToken actual);
        Task<ActualCoordinator> GetLoginAsync(CoordinatorLogins log);
        /// <summary>
        /// Lekérdezi az összes elemet
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Lekérdez egy elemet azonosító alapján
        /// </summary>
        /// <param name="coordinatorId"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int coordinatorId);
        /// <summary>
        /// Létezik-e az elem, azonosító alapján
        /// </summary>
        /// <param name="coordinatorId"></param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(int coordinatorId, JwtToken actual = null);
        /// <summary>
        /// Beilleszt egy új elemet
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> InsertAsync(T entity, JwtToken actual);
        /// <summary>
        /// Módosít egy meglévő elemet azonosító alapján
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateAsync(T entity, JwtToken actual);
        /// <summary>
        /// Törli a megadott elemet azonosító alapján
        /// </summary>
        /// <param name="coordinatorId"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(int coordinatorId, JwtToken actual);
    }
}
