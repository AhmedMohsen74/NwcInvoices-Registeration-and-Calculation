using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWC_Water_Consumption_project.Models;


public partial class TblNwcInvoice
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

    [NotMapped]
    public int year { get; set; }

    [NotMapped]
    public int month { get; set; }

    [NotMapped]
    public int day { get; set; }

    [NotMapped]
    public string dateto { get; set; } 
    [NotMapped]
    public bool Sanitation { get; set; }

    [NotMapped]
    public int Unit { get; set; }

    [NotMapped]
    public string? Name { get; set; }

    [NotMapped]
    public int Counter { get; set; }

    [NotMapped]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public string? Date { get; set; }
    public virtual TblNwcRrealEstateType? NwcInvoicesRrealEstateTypesNavigation { get; set; }

    public virtual TblNwcSubscriberFile? NwcInvoicesSubscriberNoNavigation { get; set; }

    public virtual TblNwcSubscriptionFile? NwcInvoicesSubscriptionNoNavigation { get; set; }
}
