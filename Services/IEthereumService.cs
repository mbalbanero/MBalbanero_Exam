using MBalbanero_Exam.Models;
using System.Threading.Tasks;

namespace MBalbanero_Exam.Services
{
    public interface IEthereumService
    {
        Task<EthereumInfo> GetEthereumInfoAsync(string address);
    }
}
