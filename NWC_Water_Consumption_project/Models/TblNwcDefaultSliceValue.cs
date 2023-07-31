using System;
using System.Collections.Generic;

namespace NWC_Water_Consumption_project.Models;

public partial class TblNwcDefaultSliceValue
{
    public string NwcDefaultSliceValuesCode { get; set; } = null!;

    public string? NwcDefaultSliceValuesName { get; set; }

    public decimal? NwcDefaultSliceValuesCondtion { get; set; }

    public decimal? NwcDefaultSliceValuesWaterPrice { get; set; }

    public decimal? NwcDefaultSliceValuesSanitationPrice { get; set; }

    public string? NwcDefaultSliceValuesReasons { get; set; }
}
