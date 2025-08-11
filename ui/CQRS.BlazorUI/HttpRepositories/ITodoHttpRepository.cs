using System.Net.Http.Json;
using System.Text.Json;
using CQRS.BlazorUI.Models;

namespace CQRS.BlazorUI.HttpRepositories;

public interface ITodoHttpRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem> PostAsync(TodoItem item);
    Task<bool> DeleteAsync(int id);
    Task<bool> CompleteAsync(int id);
}

public class TodoHttpRepository : ITodoHttpRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public TodoHttpRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        try
        {
            var todos = await _httpClient.GetFromJsonAsync<List<TodoItem>>("todos", _jsonSerializerOptions);
            return todos ?? new List<TodoItem>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            return new List<TodoItem>();
        }
    }

    public async Task<TodoItem> PostAsync(TodoItem item)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("todos", item);
            response.EnsureSuccessStatusCode();

            var createdItem = await response.Content.ReadFromJsonAsync<TodoItem>(_jsonSerializerOptions);
            return createdItem ?? new TodoItem();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            return new TodoItem();
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"todos/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> CompleteAsync(int id)
    {
        try
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"todos/{id}/complete");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            return false;
        }
    }
}