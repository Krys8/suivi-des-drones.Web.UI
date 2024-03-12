using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace suivi_des_drones.Web.UI.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
        #region Fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IDroneRepository repository;
        #endregion

        #region Constructors
        public IndexModel(ILogger<IndexModel> logger,
                          IConfiguration configuration,
                          IDroneRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }
        #endregion

        #region Public methods
        public IActionResult OnGet()
        {
            IActionResult result = this.Page();

            this.SetListOfDrones();
            this.SetListOfStatus();

            return result;
        }
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    this.SetListOfDrones();
        //    this.SetListOfStatus();

        //    return this.Page();
        //}
        #endregion

        #region Internal methods
        private void SetListOfDrones()
        {
            //this.Drones.Add(new() { Matricule = "236654D", CreationDate = DateTime.Now });
            //this.Drones.Add(new() { Matricule = "464900Z", CreationDate = DateTime.Now.AddDays(-150) });

            //var dataLayer = new SqlServerDroneDataLayer ();
            this.Drones = this.repository.GetAll();
        }

        private void SetListOfStatus()
        {
            this.StatusList.Add(HealthStatus.Ok);
            this.StatusList.Add(HealthStatus.Broken);
            this.StatusList.Add(HealthStatus.Repair);
        }
        #endregion

        #region Properties
        public List<Drone> Drones { get; set; } = new();
        public List<HealthStatus> StatusList { get; set; } = new();
        #endregion





    }
}
