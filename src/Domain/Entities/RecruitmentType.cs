using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    /// <summary>
    /// İşe alım türünü ifade eder
    /// Örneğin;Sözleşmeli Personel Alımı , Öğretim Görevlisi Alımı vs.
    /// </summary>
    public class RecruitmentType
    {
        public int RecruitmentTypeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
