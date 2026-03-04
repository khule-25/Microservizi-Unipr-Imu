using Imu.ClientHttp.Abstraction;
using Imu.Shared;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net.Http.Json;

namespace Imu.ClientHttp;

public class ClientHttp(HttpClient httpClient) : IClientHttp
{
}
