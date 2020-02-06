using System.Collections.Generic;
using Lychee.Infrastructure.Entities;

namespace Lychee.Infrastructure.Interfaces
{
    public interface ISettingRepository
    {
        ICollection<Setting> GetAllSettings();
        Setting GetSetting(string key);
        T GetSettingValue<T>(string key);
    }
}
