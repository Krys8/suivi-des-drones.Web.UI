using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{/// <summary>
/// Drone de l'application
/// </summary>
    public class Drone
    {
        //[Key]
        #region Properties
        public string Matricule { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        
        public HealthStatus? HealthStatus { get; set; } = null;

        public decimal HealthStatusId { get; set; } = HealthStatus.Ok.Id;
        #endregion
    }
}
