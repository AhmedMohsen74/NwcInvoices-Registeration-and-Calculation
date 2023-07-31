using Microsoft.AspNetCore.Mvc;
using NWC_Water_Consumption_project.BusniessLayer;
using NWC_Water_Consumption_project.Models;

namespace NWC_Water_Consumption_project.Controllers
{
    public class InvoiceRegisterationController : Controller
    {
        NwcWaterDbContext context = new NwcWaterDbContext();
        //For generationg invoiceNo and toDate
        static string InoviceNum = "";
        static DateTime NwcInvoicesTo;

        //declare slices
        static decimal FirstSlice = 0.0m;
        static decimal SecondSlice = 0.0m;
        static decimal ThirdSlice = 0.0m;
        static decimal ForthSlice = 0.0m;
        static decimal FifthSlice = 0.0m;

        static int NumberOFUnits;

        public JsonResult AmountOfConsumption(string CurrentCalc, string LastCalc)
        {
            int Result = (int.Parse(CurrentCalc) - int.Parse(LastCalc));
            string CurrentUsageCons = Result.ToString();
            return Json(new { ca1 = CurrentUsageCons });
        }

        /*
         static Tuple<List<int>, int> SplitNumber(int num)
        {
        List<int> result = new List<int>();
        while (num > 0 && result.Count < 4)
        {
            if (num <= 15)
            {
                result.Add(num);
                break;
            }
            else
            {
                result.Add(15);
                num -= 15;
            }
        }
        return Tuple.Create(result, num);
    }

    static void Main()
    {
        int num = 50;

        if (num != 60)
        {
            Tuple<List<int>, int> splitResult = SplitNumber(num);
            List<int> groups = splitResult.Item1;
            int remainingSum = splitResult.Item2;
            int groupSum = groups.Sum();
            Console.WriteLine("Groups: " + string.Join(", ", groups));
            Console.WriteLine("Group Sum: " + groupSum);
            Console.WriteLine("Remaining: " + remainingSum);

            int first = groups[0];
            int sec = groups[1];
            int th = groups[2];
            int f = groups[3];
            Console.WriteLine(first+" " + sec +" "+ th +" "+ f);
        }
        else
        {
            Tuple<List<int>, int> splitResult = SplitNumber(num);
            List<int> groups = splitResult.Item1;

            int groupSum = groups.Sum();
            Console.WriteLine("Groups: " + string.Join(", ", groups));
            Console.WriteLine("Group Sum: " + groupSum);

            int first = groups[0];
            int sec = groups[1];
            int th = groups[2];
            int f = groups[3];
            Console.WriteLine(first + " " + sec + " " + th + " " + f);

        }
    }
}
         */

        static Tuple<List<int>, int> SplitNumberToGetSlices(int AmountConsumptioom)
        {
            List<int> result = new List<int>();
            while (AmountConsumptioom > 0 && result.Count < 4)
            {
                if (AmountConsumptioom <= (15 * NumberOFUnits))
                {
                    result.Add(AmountConsumptioom);
                    break;
                }
                else
                {
                    result.Add((15 * NumberOFUnits));
                    AmountConsumptioom -= (15 * NumberOFUnits);
                }
            }
            return Tuple.Create(result, AmountConsumptioom);
        }

        public decimal CalculateWater(string waterCons, string unit)
        {

            int UsageOfWater = int.Parse(waterCons);

            NumberOFUnits = int.Parse(unit);

            Tuple<List<int>, int> splitResult = SplitNumberToGetSlices(UsageOfWater);
            List<int> groups = splitResult.Item1;

            int remainingSum = 0;

            decimal PriceOfWater = 0.0m;

            int MaxNumbSlicesWithUnits = (15 * int.Parse(unit));
            
            if (UsageOfWater != (4 * MaxNumbSlicesWithUnits)) // 4 is Number Of Slices
            {
                remainingSum = splitResult.Item2;
            }
            if (UsageOfWater <= 4 * MaxNumbSlicesWithUnits)
            {
                if (UsageOfWater <= MaxNumbSlicesWithUnits && UsageOfWater > 0) 
                {
                    int first = groups[0];
                    PriceOfWater = ((first * FirstSlice));
                }
                else if (UsageOfWater <= 2 * MaxNumbSlicesWithUnits && UsageOfWater > 0)
                {
                    int first = groups[0];
                    int second = groups[1];
                    PriceOfWater = ((first * FirstSlice) + (second * SecondSlice));
                }
                else if (UsageOfWater <= 3 * MaxNumbSlicesWithUnits && UsageOfWater > 0)
                {
                    int first = groups[0];
                    int second = groups[1];
                    int third = groups[2];

                    PriceOfWater = ((first * FirstSlice) + (second * SecondSlice) + (third * ThirdSlice));
                }
                else if (UsageOfWater <= 4 * MaxNumbSlicesWithUnits && UsageOfWater > 0)
                {
                    int first = groups[0];
                    int second = groups[1];
                    int third = groups[2];
                    int fourth = groups[3];
                    PriceOfWater = ((first * FirstSlice) + (second * SecondSlice) + (third * ThirdSlice) + (fourth * ForthSlice));
                }

            }
            else if (UsageOfWater > 4 * MaxNumbSlicesWithUnits )
            {
                int first = groups[0];
                int second = groups[1];
                int third = groups[2];
                int fourth = groups[3];
                int fifth = remainingSum;
                PriceOfWater = ((first * FirstSlice) + (second * SecondSlice) + (third * ThirdSlice) + (fourth * ForthSlice) + (fifth * FifthSlice));
            }
            else if (UsageOfWater == 0) 
            {
                return PriceOfWater;
            }
            return PriceOfWater;
        }

        public JsonResult CalcEveryThing(string AmoutConsumption, string UnitsNumber, string ServiceFee, string Tax_Rate, string IsThereSanitation)
        {

            decimal ConsumptionValue = CalculateWater(AmoutConsumption, UnitsNumber);
            string txtConsumptionValuee = ConsumptionValue.ToString();

            decimal ConsumptionValueWithSanitation = WaterConsumptionWithSanitation(ConsumptionValue, IsThereSanitation);
            string txtConsumptionValueWithSanitation = ConsumptionValueWithSanitation.ToString();


            string value = ServiceFee;
            decimal servicePrice = Convert.ToDecimal(value);

            decimal InvoicePrice = 0.0m;
            InvoicePrice = (ConsumptionValue + ConsumptionValueWithSanitation);
            string TxtInvoicePrice = InvoicePrice.ToString();


            decimal TaxValue = 0.0m;
            TaxValue = InvoicePrice * (decimal.Parse(Tax_Rate) / 100); //ex 232.25 * 0.15 = 34.8375 taxValue

            decimal InvoicePriceTotalBill = 0.0m;
            InvoicePriceTotalBill = TaxValue + InvoicePrice + servicePrice;  // Ex: 34.8375 + 5 + 232.25 = 267.09
            string txtInvoicePriceTotalBill = InvoicePriceTotalBill.ToString();  

            return Json(new { da1 = txtConsumptionValuee, da2 = txtConsumptionValueWithSanitation, da3 = TxtInvoicePrice, da4 = txtInvoicePriceTotalBill });
        }


        public decimal WaterConsumptionWithSanitation(decimal WaterConsumption, string IsThereSanitation)
        {
            decimal PriceOfWaterConsumptionWithSanitation = 0.0m;

            string TxtWasteWater = IsThereSanitation;
            if (TxtWasteWater == "نعم")
            {
                PriceOfWaterConsumptionWithSanitation = WaterConsumption * .5m;
            }
            return PriceOfWaterConsumptionWithSanitation;
        }

        public void UpdateTaxValue(decimal NwcInvoicesTaxRate, decimal NwcInvoicesTotalInvoice, string NwcInvoicesNo)
        {
            try
            {
                decimal TaxValue = 0.0m;
                TaxValue = (NwcInvoicesTotalInvoice * (NwcInvoicesTaxRate / 100));

                var invoice = context.TblNwcInvoices
                            .Where(x => x.NwcInvoicesNo == NwcInvoicesNo).FirstOrDefault();
                if (invoice != null)
                {
                    invoice.NwcInvoicesTaxValue = TaxValue;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateLastReadingInSubscription(decimal NwcInvoicesTaxRate, decimal NwcInvoicesTotalInvoice, string NwcInvoicesNo, decimal NwcInvoicesCurrentConsumptionAmount, string NwcInvoicesSubscriptionNo)
        {
            try
            { 
                var SubscriptionFile = context.TblNwcSubscriptionFiles
                .Where(x => x.NwcSubscriptionFileNo == NwcInvoicesSubscriptionNo)
                .FirstOrDefault();
                SubscriptionFile.NwcSubscriptionFileLastReadingMeter = NwcInvoicesCurrentConsumptionAmount;
                context.SaveChanges();
                //
                UpdateTaxValue(NwcInvoicesTaxRate, NwcInvoicesTotalInvoice, NwcInvoicesNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GetSubscriberData(string SubscriptionID)
        {

            string SubscriptionCode = "";
            string IsThereSanitation = "";
            string SubscriptionFileLastReading = "";
            string SubscriptionFileUnitNo = "";
            string SubscriberFileName = "";

            var query = (from s in context.TblNwcSubscriptionFiles
                         join subsc in context.TblNwcSubscriberFiles
                         on s.NwcSubscriptionFileSubscriberCode equals subsc.NwcSubscriberFileId
                         where s.NwcSubscriptionFileNo == SubscriptionID
                         select new
                         {
                             s.NwcSubscriptionFileSubscriberCode,
                             s.NwcSubscriptionFileIsThereSanitation,
                             s.NwcSubscriptionFileLastReadingMeter,
                             s.NwcSubscriptionFileUnitNo,
                             subsc.NwcSubscriberFileName
                         }).ToList();
            foreach (var s in query)
            {
                SubscriptionCode = s.NwcSubscriptionFileSubscriberCode.ToString();
                IsThereSanitation = s.NwcSubscriptionFileIsThereSanitation != true ? "لا" : "نعم";
                SubscriptionFileLastReading = s.NwcSubscriptionFileLastReadingMeter.ToString();
                SubscriptionFileUnitNo = s.NwcSubscriptionFileUnitNo.ToString();
                SubscriberFileName = s.NwcSubscriberFileName.ToString();
            }
            return Json(new
            {
                da1 = SubscriptionCode,
                da2 = IsThereSanitation,
                da3 = SubscriptionFileLastReading,
                da4 = SubscriptionFileUnitNo,
                da5 = SubscriberFileName
            });
        }

        [HttpPost]
        public ActionResult SaveInvoice(TblNwcInvoice invoice)
        {
            if (Request.Form["NwcInvoicesTo"].ToString() != "" && Request.Form["NwcInvoicesDate"].ToString() != "" && Request.Form["NwcInvoicesFrom"].ToString() != "" && Request.Form["NwcInvoicesCurrentConsumptionAmount"].ToString() != "" && Request.Form["NwcInvoicesServiceFee"].ToString() != "" && Request.Form["NwcInvoicesTaxRate"].ToString() != "")  
            {
                string NwcInvoicesNo = Request.Form["NwcInvoicesNo"];
                DateTime NwcInvoicesDate = Convert.ToDateTime(Request.Form["NwcInvoicesDate"]);
                string Year = NwcInvoicesDate.ToString("yy");
                string NwcInvoicesSubscriberNo = Request.Form["NwcInvoicesSubscriberNo"];

                var query = context.TblNwcSubscriptionFiles
                  .Where(x => x.NwcSubscriptionFileSubscriberCode == NwcInvoicesSubscriberNo)
                   .Select(x => x.NwcSubscriptionFileRrealEstateTypesCode).FirstOrDefault();

                string NwcInvoicesRrealEstateTypes = "";
                if (query != null)
                {
                    NwcInvoicesRrealEstateTypes = query;
                }

                string NwcInvoicesSubscriptionNo = Request.Form["NwcInvoicesSubscriptionNo"];
                string SubscriberName = Request.Form["SubscriberName"];
                DateTime NwcInvoicesFrom = Convert.ToDateTime(Request.Form["NwcInvoicesFrom"]);
                DateTime NwcInvoicesTo = Convert.ToDateTime(Request.Form["NwcInvoicesTo"]);
                decimal NwcInvoicesPreviousConsumptionAmount = Convert.ToDecimal(Request.Form["NwcInvoicesPreviousConsumptionAmount"]);
                decimal NwcInvoicesCurrentConsumptionAmount = Convert.ToDecimal(Request.Form["NwcInvoicesCurrentConsumptionAmount"]);
                decimal NwcInvoicesAmountConsumption = Convert.ToDecimal(Request.Form["NwcInvoicesAmountConsumption"]);
                decimal NwcInvoicesServiceFee = Convert.ToDecimal(Request.Form["NwcInvoicesServiceFee"]);
                decimal NwcInvoicesTaxRate = Convert.ToDecimal(Request.Form["NwcInvoicesTaxRate"]);
                string NwcInvoicesIsThereSanitation = Request.Form["NwcInvoicesIsThereSanitation"];
                decimal NwcInvoicesConsumptionValue = Convert.ToDecimal(Request.Form["NwcInvoicesConsumptionValue"]);
                decimal NwcInvoicesWastewaterConsumptionValue = Convert.ToDecimal(Request.Form["NwcInvoicesWastewaterConsumptionValue"]);
                decimal NwcInvoicesTotalInvoice = Convert.ToDecimal(Request.Form["NwcInvoicesTotalInvoice"]);
                decimal NwcInvoicesTaxValue = Convert.ToDecimal(Request.Form["NwcInvoicesTaxValue"]);
                decimal NwcInvoicesTotalBill = Convert.ToDecimal(Request.Form["NwcInvoicesTotalBill"]);

                if (NwcInvoicesIsThereSanitation == "لا")
                {
                    invoice.Sanitation = false;
                }
                else
                {
                    invoice.Sanitation = true;
                }

                bool ValueOfSanitation = invoice.Sanitation;
                int Unit = Convert.ToInt32(Request.Form["Unit"]);
                invoice.Unit = Unit;
                invoice.NwcInvoicesNo = NwcInvoicesNo;
                invoice.NwcInvoicesYear = Year;
                invoice.NwcInvoicesRrealEstateTypes = NwcInvoicesRrealEstateTypes;
                invoice.NwcInvoicesSubscriptionNo = NwcInvoicesSubscriptionNo;
                invoice.Name = SubscriberName;
                invoice.NwcInvoicesSubscriberNo = NwcInvoicesSubscriberNo;
                invoice.NwcInvoicesDate = NwcInvoicesDate;
                invoice.NwcInvoicesFrom = NwcInvoicesFrom;
                invoice.NwcInvoicesTo = NwcInvoicesTo;
                invoice.NwcInvoicesPreviousConsumptionAmount = NwcInvoicesPreviousConsumptionAmount;
                invoice.NwcInvoicesCurrentConsumptionAmount = NwcInvoicesCurrentConsumptionAmount;
                invoice.NwcInvoicesAmountConsumption = NwcInvoicesAmountConsumption;
                invoice.NwcInvoicesServiceFee = NwcInvoicesServiceFee;
                invoice.NwcInvoicesTaxRate = NwcInvoicesTaxRate;
                invoice.NwcInvoicesIsThereSanitation = ValueOfSanitation;
                invoice.NwcInvoicesConsumptionValue = NwcInvoicesConsumptionValue;
                invoice.NwcInvoicesWastewaterConsumptionValue = NwcInvoicesWastewaterConsumptionValue;
                invoice.NwcInvoicesTotalInvoice = NwcInvoicesTotalInvoice;
                invoice.NwcInvoicesTaxValue = NwcInvoicesTaxValue;
                invoice.NwcInvoicesTotalBill = NwcInvoicesTotalBill;

                context.TblNwcInvoices.Add(invoice);
                context.SaveChanges();
                UpdateLastReadingInSubscription(NwcInvoicesTaxRate, NwcInvoicesTotalInvoice, NwcInvoicesNo, NwcInvoicesCurrentConsumptionAmount, NwcInvoicesSubscriptionNo);
                TempData["SuccessMessage"] = "! تم حفظ البيانات بنجاح";
            }
            else
            {
                TempData["ErrorMessage"] = ".خطأ.. اعد المحاولة وتأكد من تعبئة البيانات";
            }
            return RedirectToAction("CreateView");
        }

        public ActionResult CreateView()
        {
            var model = new TblNwcInvoice();
            while (true)
            {
                //ex 2023-2-1

                DateTime now = DateTime.Now;
                int year = now.Year;
                int month = now.Month;
                int day = now.Day;

                string Time_Now = now.ToString("yyyy-MM-dd");
                DateTime to = Convert.ToDateTime(Time_Now);

                string ToDate = $"{year}-{month}-{day}";

                Random random = new Random();
                int randomNumber = random.Next(1, 500);
                string NumbOfInvoiceNo = $"{year}-{month}-{randomNumber}";

                var recordtoSearch = context.TblNwcInvoices.FirstOrDefault(r => r.NwcInvoicesNo == NumbOfInvoiceNo);

                if (recordtoSearch == null)
                {
                    model.NwcInvoicesNo = NumbOfInvoiceNo;
                    model.dateto = ToDate;
                    InoviceNum = NumbOfInvoiceNo;
                    break;
                }
                else
                {
                    continue;
                }
            }

            var query = context.TblNwcDefaultSliceValues.Take(5)
                 .Select(r => r.NwcDefaultSliceValuesWaterPrice).ToList();

            if (query.Any())
            {
                FirstSlice = Convert.ToDecimal(query[0]);
                SecondSlice = Convert.ToDecimal(query[1]);
                ThirdSlice = Convert.ToDecimal(query[2]);
                ForthSlice = Convert.ToDecimal(query[3]);
                FifthSlice = Convert.ToDecimal(query[4]);
            }
            return View("InvoiceRegisteration", model);
        }
    }
}
