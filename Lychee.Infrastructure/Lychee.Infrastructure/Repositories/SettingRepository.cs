using System;
using System.Collections.Generic;
using System.Linq;
using Lychee.Infrastructure.Entities;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Infrastructure.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly IRepository<Setting> _settingRepository;
        protected virtual List<Setting> _settings { get; set; }

        public SettingRepository(IRepository<Setting> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public virtual ICollection<Setting> GetAllSettings()
        {
            if (_settings != null) return _settings;

            _settings = _settingRepository.GetAll().ToList();
            return _settings;
        }

        public virtual Setting GetSetting(string key)
        {
            if (_settings == null)
                GetAllSettings();

            return _settings.FirstOrDefault(x => x.Key == key);
        }

        public virtual T GetSettingValue<T>(string key)
        {
            if (_settings == null)
                GetAllSettings();

            var setting = GetSetting(key);
            if (setting == null)
                return default;

            return (T) Convert.ChangeType(setting.Value, typeof(T));
        }
    }
}
