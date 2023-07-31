using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWC_Water_Consumption_project.Models;

public partial class TblNwcSubscriberFile
{
    public string NwcSubscriberFileId { get; set; } = null!;

    public string? NwcSubscriberFileName { get; set; }

    public string? NwcSubscriberFileCity { get; set; }

    public string? NwcSubscriberFileArea { get; set; }

    public string? NwcSubscriberFileMobile { get; set; }

    public string? NwcSubscriberFileReasons { get; set; }

    [NotMapped]
    public int NumbOfsubsc { get; set; }

    [NotMapped]
    public int Counter { get; set; }
    public virtual ICollection<TblNwcInvoice> TblNwcInvoices { get; set; } = new List<TblNwcInvoice>();

    public virtual ICollection<TblNwcSubscriptionFile> TblNwcSubscriptionFiles { get; set; } = new List<TblNwcSubscriptionFile>();
}
