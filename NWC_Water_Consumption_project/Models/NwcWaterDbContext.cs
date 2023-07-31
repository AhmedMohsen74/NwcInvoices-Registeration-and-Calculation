using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NWC_Water_Consumption_project.Models;

public partial class NwcWaterDbContext : DbContext
{
    public NwcWaterDbContext()
    {
    }

    public NwcWaterDbContext(DbContextOptions<NwcWaterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblNwcDefaultSliceValue> TblNwcDefaultSliceValues { get; set; }

    public virtual DbSet<TblNwcInvoice> TblNwcInvoices { get; set; }

    public virtual DbSet<TblNwcRrealEstateType> TblNwcRrealEstateTypes { get; set; }

    public virtual DbSet<TblNwcSubscriberFile> TblNwcSubscriberFiles { get; set; }

    public virtual DbSet<TblNwcSubscriptionFile> TblNwcSubscriptionFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MOHSEN;Database=NWC_WaterDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_100_CI_AI");

        modelBuilder.Entity<TblNwcDefaultSliceValue>(entity =>
        {
            entity.HasKey(e => e.NwcDefaultSliceValuesCode).HasName("PK_NWC_Default_Slice_Values_Code");

            entity.ToTable("TBL_NWC_Default_Slice_Values");

            entity.Property(e => e.NwcDefaultSliceValuesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Default_Slice_Values_Code");
            entity.Property(e => e.NwcDefaultSliceValuesCondtion)
                .HasColumnType("decimal(3, 0)")
                .HasColumnName("NWC_Default_Slice_Values_Condtion");
            entity.Property(e => e.NwcDefaultSliceValuesName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Name");
            entity.Property(e => e.NwcDefaultSliceValuesReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Reasons");
            entity.Property(e => e.NwcDefaultSliceValuesSanitationPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Sanitation_Price");
            entity.Property(e => e.NwcDefaultSliceValuesWaterPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Water_Price");
        });

        modelBuilder.Entity<TblNwcInvoice>(entity =>
        {
            entity.HasKey(e => e.NwcInvoicesNo).HasName("PK__TBL_NWC___0400398FAD04EE4E");

            entity.ToTable("TBL_NWC_Invoices");

            entity.Property(e => e.NwcInvoicesNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_No");
            entity.Property(e => e.NwcInvoicesAmountConsumption)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("NWC_Invoices_Amount_Consumption");
            entity.Property(e => e.NwcInvoicesConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Consumption_Value");
            entity.Property(e => e.NwcInvoicesCurrentConsumptionAmount)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("NWC_Invoices_Current_Consumption_Amount");
            entity.Property(e => e.NwcInvoicesDate)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_Date");
            entity.Property(e => e.NwcInvoicesFrom)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_From");
            entity.Property(e => e.NwcInvoicesIsThereSanitation).HasColumnName("NWC_Invoices_Is_There_Sanitation");
            entity.Property(e => e.NwcInvoicesPreviousConsumptionAmount)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("NWC_Invoices_Previous_Consumption_Amount");
            entity.Property(e => e.NwcInvoicesRrealEstateTypes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Rreal_Estate_Types");
            entity.Property(e => e.NwcInvoicesServiceFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Service_Fee");
            entity.Property(e => e.NwcInvoicesSubscriberNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Subscriber_No");
            entity.Property(e => e.NwcInvoicesSubscriptionNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Subscription_No");
            entity.Property(e => e.NwcInvoicesTaxRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Rate");
            entity.Property(e => e.NwcInvoicesTaxValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Value");
            entity.Property(e => e.NwcInvoicesTo)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_To");
            entity.Property(e => e.NwcInvoicesTotalBill)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Bill");
            entity.Property(e => e.NwcInvoicesTotalInvoice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Invoice");
            entity.Property(e => e.NwcInvoicesTotalReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Invoices_Total_Reasons");
            entity.Property(e => e.NwcInvoicesWastewaterConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Wastewater_Consumption_Value");
            entity.Property(e => e.NwcInvoicesYear)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Year");

            entity.HasOne(d => d.NwcInvoicesRrealEstateTypesNavigation).WithMany(p => p.TblNwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesRrealEstateTypes)
                .HasConstraintName("FK_NWC_Invoices_Rreal_Estate_Types");

            entity.HasOne(d => d.NwcInvoicesSubscriberNoNavigation).WithMany(p => p.TblNwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesSubscriberNo)
                .HasConstraintName("FK_NWC_Invoices_Subscriber_No");

            entity.HasOne(d => d.NwcInvoicesSubscriptionNoNavigation).WithMany(p => p.TblNwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesSubscriptionNo)
                .HasConstraintName("FK_NWC_Invoices_Subscription_No");
        });

        modelBuilder.Entity<TblNwcRrealEstateType>(entity =>
        {
            entity.HasKey(e => e.NwcRrealEstateTypesCode).HasName("Pk_ReaL_estate_Code");

            entity.ToTable("TBL_NWC_Rreal_Estate_Types");

            entity.Property(e => e.NwcRrealEstateTypesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Rreal_Estate_Types_Code");
            entity.Property(e => e.NwcRrealEstateTypesName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Name");
            entity.Property(e => e.NwcRrealEstateTypesReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Reasons");
        });

        modelBuilder.Entity<TblNwcSubscriberFile>(entity =>
        {
            entity.HasKey(e => e.NwcSubscriberFileId).HasName("Pk_NWC_Subscriber_id");

            entity.ToTable("TBL_NWC_Subscriber_File");

            entity.Property(e => e.NwcSubscriberFileId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscriber_File_Id");
            entity.Property(e => e.NwcSubscriberFileArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Area");
            entity.Property(e => e.NwcSubscriberFileCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_City");
            entity.Property(e => e.NwcSubscriberFileMobile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Mobile");
            entity.Property(e => e.NwcSubscriberFileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Name");
            entity.Property(e => e.NwcSubscriberFileReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Reasons");
        });

        modelBuilder.Entity<TblNwcSubscriptionFile>(entity =>
        {
            entity.HasKey(e => e.NwcSubscriptionFileNo).HasName("PK__TBL_NWC___FFCE2F6B34FF05FD");

            entity.ToTable("TBL_NWC_Subscription_File");

            entity.Property(e => e.NwcSubscriptionFileNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_No");
            entity.Property(e => e.NwcSubscriptionFileIsThereSanitation).HasColumnName("NWC_Subscription_File_Is_There_Sanitation");
            entity.Property(e => e.NwcSubscriptionFileLastReadingMeter)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("NWC_Subscription_File_Last_Reading_Meter");
            entity.Property(e => e.NwcSubscriptionFileReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscription_File_Reasons");
            entity.Property(e => e.NwcSubscriptionFileRrealEstateTypesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_Rreal_Estate_Types_Code");
            entity.Property(e => e.NwcSubscriptionFileSubscriberCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_Subscriber_Code");
            entity.Property(e => e.NwcSubscriptionFileUnitNo)
                .HasColumnType("decimal(2, 0)")
                .HasColumnName("NWC_Subscription_File_Unit_No");

            entity.HasOne(d => d.NwcSubscriptionFileRrealEstateTypesCodeNavigation).WithMany(p => p.TblNwcSubscriptionFiles)
                .HasForeignKey(d => d.NwcSubscriptionFileRrealEstateTypesCode)
                .HasConstraintName("FK_NWC_Subscription_File_Rreal_Estate_Types_Code");

            entity.HasOne(d => d.NwcSubscriptionFileSubscriberCodeNavigation).WithMany(p => p.TblNwcSubscriptionFiles)
                .HasForeignKey(d => d.NwcSubscriptionFileSubscriberCode)
                .HasConstraintName("FK_NWC_Subscription_File_Subscriber_Code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
