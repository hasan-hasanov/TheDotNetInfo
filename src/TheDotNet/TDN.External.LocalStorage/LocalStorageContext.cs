using Blazored.LocalStorage;

namespace TDN.External.LocalStorage
{
    public class LocalStorageContext
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorageContext(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SetItemAsync<T>(string key, T data, CancellationToken ct = default)
        {
            await _localStorage.SetItemAsync(key, data, ct);
            await _localStorage.SetItemAsync("lastUpdate", DateTime.Now, ct);
        }

        public async Task<(T, DateTime)> GetItemAsync<T>(string key, CancellationToken ct = default)
        {
            var result = await _localStorage.GetItemAsync<T>(key, ct);
            var lastUpdate = await _localStorage.GetItemAsync<DateTime>("lastUpdate", ct);

            return (result, lastUpdate);
        }
    }
}
