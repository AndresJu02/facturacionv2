using System.Net.Http;
using System.Threading.Tasks;

public class ClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ObtenerCliente(int idCliente)
    {
        var response = await _httpClient.GetAsync($"http://clienteservice/api/clientes/{idCliente}");
        return await response.Content.ReadAsStringAsync();
    }
}
