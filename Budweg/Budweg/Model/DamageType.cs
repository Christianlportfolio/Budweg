using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Model
{
    public class DamageType
    {
        public int DamageTypeId { get; set; }
        public string DamageTypeDescription { get; set; }

        public DamageType(int damageTypeId, string damageTypeDescription)
        {
            DamageTypeId = damageTypeId;
            DamageTypeDescription = damageTypeDescription;
        }

        public DamageType(int damageTypeId)
        {
            DamageTypeId = damageTypeId;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", DamageTypeId, DamageTypeDescription);
        }
    }
}
