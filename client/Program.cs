using Grpc.Core;
using System;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountServiceRequest();

            ProductServiceRequest();

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        static void AccountServiceRequest()
        {
            try
            {
                Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
                var client = new AccountService.AccountServiceClient(channel);
                EmployeeName empName = client.GetEmployeeName(new EmployeeNameRequest { EmpId = "1" });
                if (empName == null || string.IsNullOrWhiteSpace(empName.FirstName) || string.IsNullOrWhiteSpace(empName.LastName))
                {
                    Console.WriteLine("Employee not found.");
                }
                else
                {
                    Console.WriteLine($"The employee name is {empName.FirstName} {empName.LastName}.");
                }
                channel.ShutdownAsync().Wait();
                Console.WriteLine("AccountServiceRequest Terminated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }

        static void ProductServiceRequest()
        {
            try
            {
                var productServiceChannel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
                var productServiceClient = new ProductService.ProductServiceClient(productServiceChannel);
                var product = productServiceClient.GetProductById(new ProductByIdRequest { ProductId = 1 });
                Console.WriteLine($"ProductUuid: {product.ProductUuid}");

                var product2 = productServiceClient.GetProductByUuid(new ProductByUuidRequest { ProductUuid = "Id Of Product 1"});
                Console.WriteLine($"ProductId: {product.ProductId}");

                productServiceChannel.ShutdownAsync().Wait();
                Console.WriteLine("ProductServiceRequest Terminated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}
