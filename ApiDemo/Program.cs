using System.Net.Http;
using System.Text;
using System.Text.Json;
using ApiDemo.Models;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        Console.WriteLine("=== HTTP Verbs & Error Handling Demo ===");

        // Demonstrating core HTTP verbs
        await GetPostAsync(1);
        await CreatePostAsync();
        await UpdatePostPutAsync(1);
        await UpdatePostPatchAsync(1);
        await DeletePostAsync(1);

        // Demonstrating common errors
        await HandleNotFound();
        await HandleBadRequest();
        await HandleUnauthorized();
        await HandleForbidden();
        await HandleServerError();
        await HandleTimeout();
    }

    /// <summary>
    /// GET: Retrieve data from the server (safe and idempotent).
    /// </summary>
    static async Task GetPostAsync(int id)
    {
        Console.WriteLine("\n--- GET ---");
        string url = $"https://jsonplaceholder.typicode.com/posts/{id}";
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var post = JsonSerializer.Deserialize<Post>(json);
            Console.WriteLine($"Fetched Post {post?.Id}: {post?.Title}");
        }
        else
        {
            Console.WriteLine($"GET failed: {response.StatusCode}");
        }
    }

    /// <summary>
    /// POST: Create a new resource on the server.
    /// </summary>
    static async Task CreatePostAsync()
    {
        Console.WriteLine("\n--- POST ---");
        var newPost = new Post { UserId = 1, Title = "Hello World", Body = "This is a new post." };

        var json = JsonSerializer.Serialize(newPost);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        Console.WriteLine("POST status: " + response.StatusCode);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// PUT: Fully replace an existing resource.
    /// </summary>
    static async Task UpdatePostPutAsync(int id)
    {
        Console.WriteLine("\n--- PUT ---");
        var updatedPost = new Post { UserId = 1, Id = id, Title = "Updated Title", Body = "Updated Body" };

        var json = JsonSerializer.Serialize(updatedPost);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync($"https://jsonplaceholder.typicode.com/posts/{id}", content);
        Console.WriteLine("PUT status: " + response.StatusCode);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// PATCH: Partially update a resource (only send the changed fields).
    /// </summary>
    static async Task UpdatePostPatchAsync(int id)
    {
        Console.WriteLine("\n--- PATCH ---");
        var update = new { Title = "Patched Title" };

        var json = JsonSerializer.Serialize(update);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Patch, $"https://jsonplaceholder.typicode.com/posts/{id}")
        {
            Content = content
        };

        var response = await client.SendAsync(request);
        Console.WriteLine("PATCH status: " + response.StatusCode);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// DELETE: Remove a resource from the server.
    /// </summary>
    static async Task DeletePostAsync(int id)
    {
        Console.WriteLine("\n--- DELETE ---");
        var response = await client.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
        Console.WriteLine("DELETE status: " + response.StatusCode);
    }

    // ------------------ ERROR HANDLING ------------------

    /// <summary>
    /// 404 Not Found: Resource does not exist.
    /// </summary>
    static async Task HandleNotFound()
    {
        Console.WriteLine("\n--- Error: Not Found (404) ---");
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/999999");
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    /// <summary>
    /// 400 Bad Request: Server cannot process malformed data.
    /// </summary>
    static async Task HandleBadRequest()
    {
        Console.WriteLine("\n--- Error: Bad Request (400) ---");
        var content = new StringContent("Invalid JSON", Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    /// <summary>
    /// 401 Unauthorized: Missing or invalid authentication.
    /// (Simulated by calling an endpoint requiring auth.)
    /// </summary>
    static async Task HandleUnauthorized()
    {
        Console.WriteLine("\n--- Error: Unauthorized (401) ---");
        using var unauthorizedClient = new HttpClient();
        unauthorizedClient.DefaultRequestHeaders.Add("Authorization", "Bearer INVALID_TOKEN");

        var response = await unauthorizedClient.GetAsync("https://httpstat.us/401");
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    /// <summary>
    /// 403 Forbidden: Authenticated, but not allowed to access the resource.
    /// </summary>
    static async Task HandleForbidden()
    {
        Console.WriteLine("\n--- Error: Forbidden (403) ---");
        var response = await client.GetAsync("https://httpstat.us/403");
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    /// <summary>
    /// 500 Internal Server Error: Something went wrong on the server.
    /// </summary>
    static async Task HandleServerError()
    {
        Console.WriteLine("\n--- Error: Server Error (500) ---");
        var response = await client.GetAsync("https://httpstat.us/500");
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    /// <summary>
    /// Timeout: Server takes too long to respond.
    /// </summary>
    static async Task HandleTimeout()
    {
        Console.WriteLine("\n--- Error: Timeout ---");
        using var timeoutClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(1) };

        try
        {
            var response = await timeoutClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            Console.WriteLine($"Status: {response.StatusCode}");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Request timed out.");
        }
    }
}
