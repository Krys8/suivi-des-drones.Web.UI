using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Application.Repositories
{/// <summary>
 /// Repository qui gère les drones, la création, la lecture etc...
 /// </summary>
 /// <returns></returns>
    public class DroneRepository : IDroneRepository
    {
        #region Fields
        private readonly IDroneDataLayer dataLayer;
        #endregion

        #region Constructors
        public DroneRepository(IDroneDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        #endregion



        /// <summary>
        /// Retourne la liste complete des drones
        /// </summary>
        /// <returns></returns>
        #region Public methods

        public List<Drone> GetAll()
        {
            List<Drone> list = this.dataLayer.GetList();

            return list;
        }

        public void Save(Drone drone)
        {
            drone.HealthStatusId = HealthStatus.Broken.Id;

            this.dataLayer.AddOne(drone);
        }
        #endregion
    }
}
