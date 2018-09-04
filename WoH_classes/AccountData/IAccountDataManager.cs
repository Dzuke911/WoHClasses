using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WoH_classes.AccountData
{
    public interface IAccountDataManager
    {
        Task<JObject> GetAccountDataAsync(string userName);
    }
}
