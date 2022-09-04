// See https://aka.ms/new-console-template for more information
if (args.Length < 1)
    Console.WriteLine("请输入服务地址");
var buffer = args[0].Split(":");
if (buffer.Length != 2)
    Console.WriteLine("服务地址格式错误");
var host = buffer[0];
var port = int.Parse(buffer[1]);
using TTransport transport = new TSocketTransport(host, port, new TConfiguration(), 1000);
TProtocol protocol = new TBinaryProtocol(transport);
var client = new CUGOJ.RPC.Gen.Services.Base.BaseService.Client(protocol);

try
{//TODO 写自己的测试代码
    Console.WriteLine((await client.MulGetProblemInfo(new CUGOJ.RPC.Gen.Services.Base.MulGetProblemInfoRequest()
    {
        ProblemIDList = new List<long>() { 1, 2 },
        IsGetProblemContent = true,
        Base = RPCTools.NewBase()
    })));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}