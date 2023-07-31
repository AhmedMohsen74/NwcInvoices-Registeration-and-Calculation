using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NWC_Water_Consumption_project.Controllers
{


    public class SearchInvoiceController : Controller
    {

        NwcWaterDbContext context = new NwcWaterDbContext();

        [HttpPost]
        public JsonResult GetInvoiceData(string invoiceId)
        {

            
            var SearchRecordQuery = context.TblNwcInvoices.FirstOrDefault(x => x.NwcInvoicesNo == invoiceId);

            if (SearchRecordQuery == null)
            {
                TempData["Failed Message"] = "تأكد من رقم الفاتورة";
                return Json(invoiceId);
            }


            DateTime Date = Convert.ToDateTime(SearchRecordQuery.NwcInvoicesDate);
            string CurrentDate = Date.ToString("MM-dd-yyyy");

            DateTime fDate = Convert.ToDateTime(SearchRecordQuery.NwcInvoicesFrom);
            string FromtDate = Date.ToString("MM-dd-yyyy");

            DateTime tDate = Convert.ToDateTime(SearchRecordQuery.NwcInvoicesTo);
            string ToDate = Date.ToString("MM-dd-yyyy");

            string subcriperID = SearchRecordQuery.NwcInvoicesSubscriberNo.ToString();

            string SubscriptionID = SearchRecordQuery.NwcInvoicesSubscriptionNo.ToString();

            //query for subscriper name
            var QuerySubscriperID = (from nwc in context.TblNwcSubscriberFiles
                                     where nwc.NwcSubscriberFileId == subcriperID
                                     select nwc.NwcSubscriberFileName).ToList();

            string subscruperName = QuerySubscriperID[0].ToString();

            string NWCInvoicesPreviousConsumptionAmount = SearchRecordQuery.NwcInvoicesPreviousConsumptionAmount.ToString();

            string NWCInvoicesCurrentConsumptionAmount = SearchRecordQuery.NwcInvoicesCurrentConsumptionAmount.ToString();

            string NWCInvoicesAmountConsumption = SearchRecordQuery.NwcInvoicesAmountConsumption.ToString();

            string NwcInvoicesServiceFee = SearchRecordQuery.NwcInvoicesServiceFee.ToString();

            string NwcInvoicesTaxRate = SearchRecordQuery.NwcInvoicesTaxRate.ToString();

            string ThereIsSanitation = SearchRecordQuery.NwcInvoicesIsThereSanitation != true ? "لا" : "نعم".ToString();

            string NWCInvoicesConsumptionValue = SearchRecordQuery.NwcInvoicesConsumptionValue.ToString();

            string NWCInvoicesWastewaterConsumptionValue = SearchRecordQuery.NwcInvoicesWastewaterConsumptionValue.ToString();

            string NWC_Invoices_Total_Invoice = SearchRecordQuery.NwcInvoicesTotalInvoice.ToString();

            string NWC_Invoices_Total_Bill = SearchRecordQuery.NwcInvoicesTotalBill.ToString();

            //query for unit of subscription name
            var QueryOfUnit = (from sub in context.TblNwcSubscriptionFiles
                               where sub.NwcSubscriptionFileNo == SubscriptionID
                               select sub.NwcSubscriptionFileUnitNo).ToList();

            string UintOfSubScription = QueryOfUnit[0].ToString();

            return Json(new
            {
                da1 = CurrentDate,
                da2 = FromtDate,
                da3 = ToDate,
                da4 = UintOfSubScription,
                da5 = SubscriptionID,
                da6 = subcriperID,
                da7 = subscruperName,
                da8 = NWCInvoicesPreviousConsumptionAmount,
                da9 = NWCInvoicesCurrentConsumptionAmount,
                da10 = NWCInvoicesAmountConsumption,
                da11 = NwcInvoicesServiceFee,
                da12 = NwcInvoicesTaxRate,
                da13 = ThereIsSanitation,
                da14 = NWCInvoicesConsumptionValue,
                da15 = NWCInvoicesWastewaterConsumptionValue,
                da16 = NWC_Invoices_Total_Invoice,
                da17 = NWC_Invoices_Total_Bill
            });

        }
        public IActionResult CreateView()
        {
            var m = new TblNwcInvoice();
            return View("SearchInvoice", m);
        }
    }
}
