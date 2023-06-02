using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SiteSetting:BaseEntity
    {
        public int SiteSettingId { get; set; }
        public string SystemName { get; set; }
        public string SiteLogoPath { get; set; }

    }
}
