using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    public record HealthStatus
    {
        #region Fields
        public static HealthStatus Ok = new HealthStatus() { Id = 0, Label = "Ok" };
        public static HealthStatus Repair = new HealthStatus() { Id = -1, Label = "Cassé" };
        public static HealthStatus Broken = new HealthStatus() { Id = -2, Label = "En réparation" };
        #endregion


        #region Properties
        public decimal Id { get; init; }
        public string Label { get; init; } = default!;

        public List<Drone> Drones { get; set; }
        #endregion


    }
}
