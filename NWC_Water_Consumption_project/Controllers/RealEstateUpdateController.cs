using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NWC_Water_Consumption_project.BusniessLayer;
using NWC_Water_Consumption_project.Models;
using System.Data;

namespace NWC_Water_Consumption_project.Controllers
{
    public class RealEstateUpdateController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();
        [HttpPost]
        public async Task<ActionResult> UpdateReal(string Code, string Name, string Reason)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName="@NWC_Rreal_Estate_Types_Code",
                    SqlDbType=System.Data.SqlDbType.Char,
                    Value=Code
                },
                new SqlParameter()
                {
                    ParameterName="@NWC_Rreal_Estate_Types_Name",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=Name
                },
                new SqlParameter()
                {
                    ParameterName="@NWC_Rreal_Estate_Types_Reasons",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=Reason
                }
            };

            var RealEstateUpdateResult = await context.Database.ExecuteSqlRawAsync($"Exec SpEditRealEstate @NWC_Rreal_Estate_Types_Code,@NWC_Rreal_Estate_Types_Name,@NWC_Rreal_Estate_Types_Reasons", param);

            if (RealEstateUpdateResult == 1) 
            {
                return RedirectToAction("RealEstateUpdate");
            }
            else
            {
                return View("RealEstateUpdate");
            }
        }
    }
}
