using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    public class SqlServerDroneDataLayer : BaseSqlServerDataLayer, IDroneDataLayer
    {

        #region Constructors
        public SqlServerDroneDataLayer(DronesDbContext context): base(context) { }
       

      
        #endregion

        #region Public methods
        public List<Drone> GetList()
        {
            var query = from item in this.Context?.Drones.Include(item => item.HealthStatus)
                        //where item.CreationDate > DateTime.Now
                        select item;

            return query.ToList();
        } 
        public void AddOne(Drone drone)
        {
            this.Context?.Drones.Add(drone);

            //var entry = this.context?.Entry(drone.HealthStatus);
            //entry.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            
            this.Context?.SaveChanges();
        }
        #endregion
        
    }
}
