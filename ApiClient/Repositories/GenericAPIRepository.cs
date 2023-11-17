using CoordinatorOffice.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

using CoordinatorOffice.ApiClient.Models;
using CoordinatorOffice.Models.Models;
using CoordinatorOffice.ApiClient.Models.DTO;

namespace CoordinatorOffice.ApiClient.Repositories
{
    public class GenericAPIRepository<T> : BaseAPIRepository, IGenericRepository<T>
    {
        public GenericAPIRepository(string path, string? baseUrl = null, DelegatingHandler? handler = null) : base(baseUrl, path, handler)
        {
        }
        public async Task<ActualCoordinator> GetRefreshTokenAsync(JwtToken actual)
        {
            var response = await client.PostAsJsonAsync(_path + "/Refresh", actual);
            if (response.IsSuccessStatusCode)
            {
                ActualCoordinator freshToken = new ActualCoordinator();
                var content = response.Content.ReadAsStringAsync();
                content.Wait();
                string result = content.Result;
                // result.Replace("access_Token", "accessToken");
                //result.Replace("refresh_Token", "refreshToken");
                freshToken = JsonSerializer.Deserialize<ActualCoordinator>(result);
                //TODOO itt nem tölti fel a tokent.
                return freshToken;
            }


            return null;
        }

        public async Task<ActualCoordinator> GetLoginAsync(CoordinatorLogins log)
        {
            var response = await client.PostAsJsonAsync(_path + "/login", log);

            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync();
                content.Wait();
                string result = content.Result;

                ActualCoordinator actual = JsonSerializer.Deserialize<ActualCoordinator>(result);

                return actual;
            }
            return null;
        }

        public async Task<List<T>> GetAllAsync()
        {

            return await client.GetFromJsonAsync<List<T>>(_path);
        }

        public async Task<T> GetByIdAsync(int coordinatorId)
        {
            return await client.GetFromJsonAsync<T>(_path + "/" + coordinatorId);
        }

        public async Task<bool> ExistsByIdAsync(int coordinatorId, JwtToken actual = null)
        {
            var old = _path;
            if (_path.Contains("ser"))
            {
                _path = "api/Admin/coordinator";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
                HttpResponseMessage responseMessage = await client.GetAsync(_path + "/" + coordinatorId);
                _path = old;
                return responseMessage.IsSuccessStatusCode;
            }
            else
            {
                HttpResponseMessage responseMessage = await client.GetAsync(_path + "/" + coordinatorId);
                return responseMessage.IsSuccessStatusCode;
            }

        }
        public async Task<HttpResponseMessage> ChangeItemAsync(T entity, JwtToken actual)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
            var old = _path;
            Study study = new Study();
            CSite site = new CSite();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            if (entity.GetType() == study.GetType())
            {
                _path = "api/admin/study";
                responseMessage = await client.PutAsJsonAsync(_path + "/Modify", entity);

            }

            if (entity.GetType() == site.GetType())
            {
                _path = "api/admin/site";
                responseMessage = await client.PostAsJsonAsync(_path + "/Modify", entity);
            }
            _path = old;
            return responseMessage;
        }
        public async Task<HttpResponseMessage> NewItemAsync(T entity, JwtToken actual)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
            var old = _path;
            Study study = new Study();
            CSite site = new CSite();
            if (entity.GetType() == study.GetType())
            {
                _path = "api/admin/study";
            }

            if (entity.GetType() == study.GetType())
            {
                _path = "api/admin/study";
            }
            var responseMessage = await client.PostAsJsonAsync(_path + "/add", entity);
            _path = old;
            return responseMessage;
        }
        public async Task<HttpResponseMessage> InsertAsync(T entity, JwtToken actual)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
            var responseMessage = await client.PostAsJsonAsync(_path + "/add", entity);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> UpdateAsync(T entity, JwtToken actual)
        {
            var old = _path;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
            if (_path.Contains("ser"))
            {
                _path = "api/Admin/User";
            }
            var responseMessage = await client.PutAsJsonAsync(_path + "/Modify", entity);
            _path = old;

            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteAsync(int coordinatorId, JwtToken actual)
        {
            var old = _path;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", actual.Access_Token);
            if (_path.Contains("ser"))
            {
                _path = "api/Admin/coordinator";
                HttpResponseMessage responseMessage = await client.DeleteAsync(_path + "/Delete/" + coordinatorId);
                _path = old;
                return responseMessage;

            }
            if (_path.Contains("Study"))
            {
                _path = "api/Admin/study";
                HttpResponseMessage responseMessage = await client.DeleteAsync(_path + "/Delete/" + coordinatorId);
                _path = old;
                return responseMessage;

            }
            if (_path.Contains("Site"))
            {
                _path = "api/Admin/site";
                HttpResponseMessage responseMessage = await client.DeleteAsync(_path + "/Delete/" + coordinatorId);
                _path = old;
                return responseMessage;

            }
            else
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync(_path + "/Delete/" + coordinatorId);
                return responseMessage;
            }
        }
    }
}
