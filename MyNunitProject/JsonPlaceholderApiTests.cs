using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


namespace MyNunitProject
{
    [TestFixture]
    public class JsonPlaceholderApiTests
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";
        private readonly RestClient _client = new RestClient(BaseUrl);

        // GET Request: Get a post by ID
        [Test]
        public void GetPostById_ShouldReturnCorrectPost()
        {
            var request = new RestRequest("/posts/1", Method.Get);
            RestResponse response = _client.Execute(request);

            // Assert status code is 200 (OK)
            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            // Parse response body
            var responseBody = JObject.Parse(response.Content);

            // Assert that the post details are correct
            Assert.That((int)responseBody["userId"], Is.EqualTo(1));
            Assert.That((int)responseBody["id"], Is.EqualTo(1));
            Assert.That((string)responseBody["title"], Is.Not.Null);
            Assert.That((string)responseBody["body"], Is.Not.Null);

            // Log
            TestContext.WriteLine("GET REQUEST");
            LogRequest(request);
            TestContext.WriteLine(" ");
            TestContext.WriteLine("Response: " + response.Content);
        }

        // POST Request: Create a new post
        [Test]
        public void CreateNewPost_ShouldReturnCreatedPost()
        {
            var request = new RestRequest("/posts", Method.Post);

            // Sample new post data
            var newPost = new
            {
                userId = 1,
                title = "New Test Post",
                body = "This is a new post created for testing purposes."
            };
            request.AddJsonBody(newPost);

            RestResponse response = _client.Execute(request);

            // Assert status code is 201 (Created)
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "Expected status code 201");

            // Parse response body
            var responseBody = JObject.Parse(response.Content);

            // Assert that the response body contains the correct post details
            Assert.That((int)responseBody["userId"], Is.EqualTo(newPost.userId));
            Assert.That((string)responseBody["title"], Is.EqualTo(newPost.title));
            Assert.That((string)responseBody["body"], Is.EqualTo(newPost.body));


            // Log
            TestContext.WriteLine("POST REQUEST");
            LogRequest(request);
            TestContext.WriteLine(" ");
            TestContext.WriteLine("Response: " + response.Content);
        }

        // PUT Request: Update an existing post
        [Test]
        public void UpdatePost_ShouldReturnUpdatedPost()
        {
            var request = new RestRequest("/posts/1", Method.Put);

            // Updated post data
            var updatedPost = new
            {
                userId = 1,
                id = 1,
                title = "Updated Test Post Title",
                body = "This is the updated body of the post for testing purposes."
            };
            request.AddJsonBody(updatedPost);

            RestResponse response = _client.Execute(request);

            // Assert status code is 200 (OK)
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Expected status code 200");

            // Parse response body
            var responseBody = JObject.Parse(response.Content);

            // Assert that the response body contains the updated post details
            Assert.That((int)responseBody["userId"], Is.EqualTo(updatedPost.userId));
            Assert.That((int)responseBody["id"], Is.EqualTo(updatedPost.id));
            Assert.That((string)responseBody["title"], Is.EqualTo(updatedPost.title));
            Assert.That((string)responseBody["body"], Is.EqualTo(updatedPost.body));

            // Log
            TestContext.WriteLine("PUT REQUEST");
            LogRequest(request);
            TestContext.WriteLine(" ");
            TestContext.WriteLine("Response: " + response.Content);
        }

        // DELETE Request: Delete a post
        [Test]
        public void DeletePost_ShouldReturnNoContent()
        {
            var request = new RestRequest("/posts/1", Method.Delete);

            // Execute delete request
            RestResponse response = _client.Execute(request);

            // Assert status code is 200 (OK) or 204 (No Content) for successful delete
            Assert.That((int)response.StatusCode, Is.EqualTo(200).Or.EqualTo(204));

            // To further validate deletion, try to GET the deleted post and expect a 404
            var getRequest = new RestRequest("/posts/1", Method.Get);
            var getResponse = _client.Execute(getRequest);

            // Log
            TestContext.WriteLine("DELETE REQUEST");
            LogRequest(request);
            TestContext.WriteLine(" ");
            TestContext.WriteLine("Response: " + response.Content);

            // Assert status code is 404 (Not Found)
            //Assert.That((int)getResponse.StatusCode, Is.EqualTo(404), "Expected 404 after deleting post");
        }

        private void LogRequest(RestRequest request )
        {
            // Log method, URL, headers, and body of the request
            TestContext.WriteLine("Request:" );
            TestContext.WriteLine($"Method: {request.Method}");
            TestContext.WriteLine($"URL: {BaseUrl + request.Resource}");

            // Log Body - check for JSON body or form data
            var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
            if (body != null)
            {
                TestContext.WriteLine("Body: " + body.Value.ToString());
            }
            else
            {
                TestContext.WriteLine("Body: No Body");
            }
        }
    }
}

