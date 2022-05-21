namespace CancelaAntesDeConsumir;

public class CepService : ICepService
{
    private readonly HttpClient _client = new HttpClient();
    
    public async Task<string?> GetEnderecoAsync(string cep, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("\nAguardar 4 segundos");
            await Task.Delay(4000, cancellationToken);
            Console.WriteLine("\nBuscando CEP");
            HttpResponseMessage response = await _client.GetAsync($"https://viacep.com.br/ws/{cep}/json/",cancellationToken);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("\nFeito");
            return await response.Content.ReadAsStringAsync();
            
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nHttpRequestException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("\nTaskCanceledException Caught!");
            Console.WriteLine("Task Canceled");
        }
        return null;    
    }
}