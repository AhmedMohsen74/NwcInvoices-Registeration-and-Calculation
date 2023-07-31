using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWC_Water_Consumption_project.Models;


public partial class TblNwcSubscriptionFile
{
    public string NwcSubscriptionFileNo { get; set; } = null!;

    public string? NwcSubscriptionFileSubscriberCode { get; set; }

    public string? NwcSubscriptionFileRrealEstateTypesCode { get; set; }

    public decimal? NwcSubscriptionFileUnitNo { get; set; }

    public bool? NwcSubscriptionFileIsThereSanitation { get; set; }

    public decimal? NwcSubscriptionFileLastReadingMeter { get; set; }

    public string? NwcSubscriptionFileReasons { get; set; }

#nullable disable
    [NotMapped]
    public int Counter { get; set; }

    [NotMapped]
    public string Name { get; set; }

    [NotMapped]
    public string Real_Estate_Type { get; set; }

    [NotMapped]
    public string? PhoneNumber { get; set; }

    [NotMapped]
    public string Yes_or_No { get; set; }

#nullable enable
    public virtual TblNwcRrealEstateType? NwcSubscriptionFileRrealEstateTypesCodeNavigation { get; set; }

    public virtual TblNwcSubscriberFile? NwcSubscriptionFileSubscriberCodeNavigation { get; set; }

    public virtual ICollection<TblNwcInvoice> TblNwcInvoices { get; set; } = new List<TblNwcInvoice>();
}
