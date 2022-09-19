using System.Diagnostics;
using CUGOJ.RPC.Gen.Services.Core;
// See https://aka.ms/new-console-template for more information
if (args.Length < 1)
    Console.WriteLine("请输入服务地址");
var buffer = args[0].Split(":");
if (buffer.Length != 2)
    Console.WriteLine("服务地址格式错误");
var host = buffer[0];
var port = int.Parse(buffer[1]);
var hostByte = System.Text.UTF8Encoding.UTF8.GetBytes(host);
var ipAddress = System.Net.IPAddress.Parse(host);
using TTransport transport = new TSocketTransport(ipAddress, port, new TConfiguration(), 1000);
TProtocol protocol = new TBinaryProtocol(transport);
await transport.OpenAsync();

var client = new CUGOJ.RPC.Gen.Services.Core.CoreService.Client(protocol);

try
{//TODO 写自己的测试代码
    using var activity = new Activity("CUGOJ.Tester");
    activity.Start();
    // var req = new PingRequest(((long)(DateTime.Now - DateTime.UnixEpoch).TotalMilliseconds));
    // var req = new RestartRequest();
    var req = new AddServiceRequest(ServiceTypeEnum.Base);
    // var req = new GetUnRegisteredServicesRequest();
    req.Base = RPCTools.NewRootBase();
    req.Base.Extra["ServiceID"] = "testService";
    req.Base.Extra["UserID"] = "Tester";
    Console.WriteLine((await client.AddService(req)));
    // Console.WriteLine((await client.Restart(req)));
    // Console.WriteLine(await client.GetUnRegisteredServices(req));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}