using MBalbanero_Exam.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MBalbanero_Exam.Services
{
    public class EtherscanService : IEthereumService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public EtherscanService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Etherscan:ApiKey"];
        }

        public async Task<EthereumInfo> GetEthereumInfoAsync(string address)
        {
            var info = new EthereumInfo { Address = address };

            // 1. Get balance
            var balanceUrl = $"https://api.etherscan.io/api?module=account&action=balance&address={address}&tag=latest&apikey={_apiKey}";
            var balanceResponse = await _httpClient.GetStringAsync(balanceUrl);
            var balanceJson = JObject.Parse(balanceResponse);
            info.Balance = balanceJson["result"]?.ToString();

            await Task.Delay(1000);

            // 2. Get current gas price
            var gasUrl = $"https://api.etherscan.io/api?module=gastracker&action=gasoracle&apikey={_apiKey}";
            var gasResponse = await _httpClient.GetStringAsync(gasUrl);
            var gasJson = JObject.Parse(gasResponse);
            info.GasPrice = gasJson["result"]?["ProposeGasPrice"]?.ToString();

            await Task.Delay(1000);

            // 3. Get current block number
            var blockUrl = $"https://api.etherscan.io/api?module=proxy&action=eth_blockNumber&apikey={_apiKey}";
            var blockResponse = await _httpClient.GetStringAsync(blockUrl);
            var blockJson = JObject.Parse(blockResponse);
            info.BlockNumber = Convert.ToInt64(blockJson["result"].ToString(), 16); // hex to decimal
            //info.BlockNumbertest = blockJson["result"].ToString();

            return info;
        }
    }
}
