
using Grpc.Net.Client;
using GrpcService;
using ProductExpService;

var message = new HelloRequest
{
    Name = "Adi"
};


var channel = GrpcChannel.ForAddress("http://localhost:5147");
var client = new Greeter.GreeterClient(channel);
var srerveReply = await client.SayHelloAsync(message);


var empty = new Empty
{

};

var productclient = new ProductExp.ProductExpClient(channel);
var srerveReply1 = productclient.GetProductList(empty);



Console.WriteLine("Products Count : "+srerveReply1.Items.Count);
Console.ReadLine();



