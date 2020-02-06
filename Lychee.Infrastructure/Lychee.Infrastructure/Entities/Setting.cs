using System.ComponentModel.DataAnnotations;

namespace Lychee.Infrastructure.Entities
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

    }
}
