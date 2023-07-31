using System.ComponentModel.DataAnnotations;

namespace BusniessLayer
{
    public class Nwc_invoices
    {
        public string NwcInvoicesNo { get; set; } = null!;

        public string? NwcInvoicesYear { get; set; }

        public string? NwcInvoicesRrealEstateTypes { get; set; }

        public string? NwcInvoicesSubscriptionNo { get; set; }

        public string? NwcInvoicesSubscriberNo { get; set; }
        public DateTime? NwcInvoicesDate { get; set; }
        public DateTime? NwcInvoicesFrom { get; set; }
        public DateTime? NwcInvoicesTo { get; set; }

        public decimal? NwcInvoicesPreviousConsumptionAmount { get; set; }

        public decimal? NwcInvoicesCurrentConsumptionAmount { get; set; }

        public decimal? NwcInvoicesAmountConsumption { get; set; }

        public decimal? NwcInvoicesServiceFee { get; set; }

        public decimal? NwcInvoicesTaxRate { get; set; }

        public bool? NwcInvoicesIsThereSanitation { get; set; }

        public decimal? NwcInvoicesConsumptionValue { get; set; }

        public decimal? NwcInvoicesWastewaterConsumptionValue { get; set; }

        public decimal? NwcInvoicesTotalInvoice { get; set; }

        public decimal? NwcInvoicesTaxValue { get; set; }

        public decimal? NwcInvoicesTotalBill { get; set; }

        public string? NwcInvoicesTotalReasons { get; set; }
    }
}