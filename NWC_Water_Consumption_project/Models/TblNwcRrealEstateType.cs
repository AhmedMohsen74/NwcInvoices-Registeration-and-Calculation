using System;
using System.Collections.Generic;

namespace NWC_Water_Consumption_project.Models;

public partial class TblNwcRrealEstateType
{
    public string NwcRrealEstateTypesCode { get; set; } 

    public string? NwcRrealEstateTypesName { get; set; }

    public string? NwcRrealEstateTypesReasons { get; set; }

    public virtual ICollection<TblNwcInvoice> TblNwcInvoices { get; set; } = new List<TblNwcInvoice>();

    public virtual ICollection<TblNwcSubscriptionFile> TblNwcSubscriptionFiles { get; set; } = new List<TblNwcSubscriptionFile>();
}
