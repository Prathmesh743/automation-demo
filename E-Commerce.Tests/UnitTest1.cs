using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http.Json;
namespace E_Commerce.Tests;

public class Tests
{

    private string url="https://reqres.in/";
     RestClient client;
     RestRequest request;
    [SetUp]
    public async Task Setup()
    {
        client = new RestClient(url);
        //request= new RestRequest("/v3.1/all",Method.Get);

    }

    //[Test]
    public async Task Test1()
    {
         var response= await client.ExecuteGetAsync(request);
          //var response = await client.GetJsonAsync(request);
         if(response.IsSuccessful)
         {
            Console.WriteLine("successful");
            Console.WriteLine(response.Content);
            Assert.Pass();
         }
         else
         {
             Console.WriteLine("Unsuccessful");
         }
        //Assert.Pass();
    }

    [Test]
    public async Task Test2()
    {
        ///v3.1/name/peru
        var args= new {
            id= 1
        };

         request= new RestRequest("api/users/1",Method.Get);
        //request= new RestRequest("/v3.1/name/{name}");
        //var response= await client.ExecuteGetAsync(request,args,cancellationToken);
        var response = await client.GetJsonAsync<userDetails>("api/users/1");
        //Console.WriteLine(response.st)
        Console.WriteLine(response.Data.Email);
    }

    
}