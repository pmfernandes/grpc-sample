using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace server
{
    class AccountsImpl: AccountService.AccountServiceBase
    {
        // Server side handler of the GetEmployeeName RPC
        public override Task<EmployeeName> GetEmployeeName(EmployeeNameRequest request, ServerCallContext context)
        {
            Console.WriteLine($"{nameof(AccountService)} | {nameof(GetEmployeeName)} | Request: {request.EmpId}");
            EmployeeData empData = new EmployeeData();
            return Task.FromResult( empData.GetEmployeeName(request) );
        }
    }
}
