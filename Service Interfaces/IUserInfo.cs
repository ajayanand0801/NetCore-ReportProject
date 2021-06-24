using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Interfaces
{
    public interface IUserInfo
    {
        Task<byte[]>  GenerateReport();
    }
}
