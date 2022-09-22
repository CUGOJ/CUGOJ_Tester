using CUGOJ.RPC.Gen.Services.Base;
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

var client = new CUGOJ.RPC.Gen.Services.Base.BaseService.Client(protocol);

try
{

    // var req = new SaveUserInfoRequest();
    // req.User = new UserStruct
    // {
    //     Status = UserStatusEnum.ENABLE,
    //     Type = UserTypeEnum.GOD,
    //     Realname = "zyz",
    //     Avatar = "",
    //     Nickname = "艹",
    //     Signature = "只因",
    //     Email = "323.com",
    //     Phone = "32",
    //     ID = 36
    // };
    // req.UserLoginInfo = new UserLoginInfoStruct
    // {
    //     Username = "0",
    //     Password = "3",
    //     Salt = "3"
    // };
    // req.Base = RPCTools.NewRootBase();
    // req.Base.Extra["ServiceID"] = "testService";
    // req.Base.Extra["UserID"] = "Tester";
    // Console.WriteLine(await client.SaveUserInfo(req));

    // var req = new MulGetUserInfoRequest();
    // req.UserIDList = new List<long> { 32, 36 };
    // req.IsGetUserDetail = true;
    // req.Base = RPCTools.NewRootBase();
    // req.Base.Extra["ServiceID"] = "testService";
    // req.Base.Extra["UserID"] = "Tester";
    // Console.WriteLine(await client.MulGetUserInfo(req));

    // Random random = new();
    // for (int i = 1; i <= 200;i++)
    // {
    //     var req = new SaveProblemInfoRequest();
    //     req.Problem = new ProblemStruct
    //     {
    //         Content = random.NextInt64().ToString(),
    //         Status = ProblemStatusEnum.PUBLIC,
    //         Type = ProblemTypeEnum.OJ,
    //         AcceptedCount = random.Next(),
    //         SubmissionCount = random.Next(),
    //         Source = new ProblemSourceStruct
    //         {
    //             ID = 1,
    //             Name = "zF",
    //             Url = "https:/12312312312d.com"
    //         },
    //         ShowID = "132",
    //         Writer = new UserStruct
    //         {
    //             ID = 32,
    //             Realname = "zx"
    //         },
    //         Title = "..n",
    //     };
    //     req.Base = RPCTools.NewRootBase();
    //     req.Base.Extra["ServiceID"] = "testService";
    //     req.Base.Extra["UserID"] = "Tester";
    //     Console.WriteLine(await client.SaveProblemInfo(req));
    //     Thread.Sleep(100);
    // }


    // var req = new MulGetProblemInfoRequest();
    // req.IsGetProblemContent = true;
    // req.ProblemIDList = new List<long> { 6, 7 };
    // req.Base = RPCTools.NewRootBase();
    // req.Base.Extra["ServiceID"] = "testService";
    // req.Base.Extra["UserID"] = "Tester";
    // Console.WriteLine(await client.MulGetProblemInfo(req));

    var req = new GetProblemListRequest();
    req.Cursor = 100;
    req.Limit = 25;
    req.Base = RPCTools.NewRootBase();
    req.Base.Extra["ServiceID"] = "testService";
    req.Base.Extra["UserID"] = "Tester";
    Console.WriteLine(await client.GetProblemList(req));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}