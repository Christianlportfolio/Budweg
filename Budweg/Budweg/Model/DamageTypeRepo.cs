using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Model
{
    public class DamageTypeRepo
    {
        ObservableCollection<DamageType> damageTypesList = new ObservableCollection<DamageType>();

        public ObservableCollection<DamageType> GetAllDamageTypes()
        {
            return damageTypesList;
        }

        public DamageType Read(int damageTypeId)
        {
            return damageTypesList.ToList().Find(x => x.DamageTypeId == damageTypeId);
        }

        public DamageTypeRepo()
        {
            damageTypesList.Add(new DamageType(1, "Fejlpakket"));
            damageTypesList.Add(new DamageType(2, "Nedsat bremse-effekt"));
            damageTypesList.Add(new DamageType(3, "Utæt"));
            damageTypesList.Add(new DamageType(4, "Kalibren hænger"));
            damageTypesList.Add(new DamageType(5, "Ødelagt gevind"));
            damageTypesList.Add(new DamageType(6, "Ødelagt hus"));
            damageTypesList.Add(new DamageType(7, "Kan ikke udluftes"));
            damageTypesList.Add(new DamageType(8, "Håndbremsefunktion"));
        }
    }
}
