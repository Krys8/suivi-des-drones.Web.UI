using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Interfaces.Infrastructures
{/// <summary>
/// Isole l'acces a la base de données
/// </summary>
    public interface IDroneDataLayer
    {/// <summary>
    /// Retourne la liste complete
    /// </summary>
    /// <returns></returns>
        List<Drone> GetList();
        /// <summary>
        /// Permet l'ajout d'un nouveau drone en base de données
        /// </summary>
        /// <param name="drone"></param>
        void AddOne(Drone drone);
    }
}
