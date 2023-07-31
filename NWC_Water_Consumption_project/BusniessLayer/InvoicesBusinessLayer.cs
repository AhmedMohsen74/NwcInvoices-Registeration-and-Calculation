using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using NWC_Water_Consumption_project.Models;
using System.Configuration;
using System.Data.SqlClient;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace NWC_Water_Consumption_project.BusniessLayer
{
    public class InvoicesBusinessLayer
    {
        public bool addInvoice(TblNwcInvoice invoice)
        {

            int id = 0;
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string query = "SpAddInvoices";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter p_NWC_Invoices_No = new SqlParameter();
                p_NWC_Invoices_No.ParameterName = "@NWC_Invoices_No";
                p_NWC_Invoices_No.Value = invoice.NwcInvoicesNo;
                cmd.Parameters.Add(p_NWC_Invoices_No);


                SqlParameter p_NWC_Invoices_Year = new SqlParameter();
                p_NWC_Invoices_Year.ParameterName = "@NWC_Invoices_Year";
                p_NWC_Invoices_Year.Value = DateTime.Now.Year;
                cmd.Parameters.Add(p_NWC_Invoices_Year);

                SqlParameter p_NWC_Invoices_Rreal_Estate_Types = new SqlParameter();
                p_NWC_Invoices_Rreal_Estate_Types.ParameterName = "@NWC_Invoices_Rreal_Estate_Types";
                p_NWC_Invoices_Rreal_Estate_Types.Value = invoice.NwcInvoicesRrealEstateTypes;
                cmd.Parameters.Add(p_NWC_Invoices_Rreal_Estate_Types);

                SqlParameter p_NWC_Invoices_Subscription_No = new SqlParameter();
                p_NWC_Invoices_Subscription_No.ParameterName = "@NWC_Invoices_Subscription_No";
                p_NWC_Invoices_Subscription_No.Value = invoice.NwcInvoicesSubscriptionNo;
                cmd.Parameters.Add(p_NWC_Invoices_Subscription_No);

                SqlParameter p_NWC_Invoices_Subscriber_No = new SqlParameter();
                p_NWC_Invoices_Subscriber_No.ParameterName = "@NWC_Invoices_Subscriber_No";
                p_NWC_Invoices_Subscriber_No.Value = invoice.NwcInvoicesSubscriberNo;
                cmd.Parameters.Add(p_NWC_Invoices_Subscriber_No);

                SqlParameter p_NWC_Invoices_Date = new SqlParameter();
                p_NWC_Invoices_Date.ParameterName = "@NWC_Invoices_Date";
                p_NWC_Invoices_Date.Value = invoice.NwcInvoicesDate;
                cmd.Parameters.Add(p_NWC_Invoices_Date);

                SqlParameter p_NWC_Invoices_From = new SqlParameter();
                p_NWC_Invoices_From.ParameterName = "@NWC_Invoices_From";
                p_NWC_Invoices_From.Value = invoice.NwcInvoicesFrom;
                cmd.Parameters.Add(p_NWC_Invoices_From);

                SqlParameter p_NWC_Invoices_To = new SqlParameter();
                p_NWC_Invoices_To.ParameterName = "@NWC_Invoices_To";
                p_NWC_Invoices_To.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_To);

                SqlParameter p_NWC_Invoices_Previous_Consumption_Amount = new SqlParameter();
                p_NWC_Invoices_Previous_Consumption_Amount.ParameterName = "@NWC_Invoices_Previous_Consumption_Amount";
                p_NWC_Invoices_Previous_Consumption_Amount.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Previous_Consumption_Amount);

                SqlParameter p_NWC_Invoices_Current_Consumption_Amount = new SqlParameter();
                p_NWC_Invoices_Current_Consumption_Amount.ParameterName = "@NWC_Invoices_Current_Consumption_Amount";
                p_NWC_Invoices_Current_Consumption_Amount.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Current_Consumption_Amount);

                SqlParameter p_NWC_Invoices_Amount_Consumption = new SqlParameter();
                p_NWC_Invoices_Amount_Consumption.ParameterName = "@NWC_Invoices_Amount_Consumption";
                p_NWC_Invoices_Amount_Consumption.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Amount_Consumption);

                SqlParameter p_NWC_Invoices_Service_Fee = new SqlParameter();
                p_NWC_Invoices_Service_Fee.ParameterName = "@NWC_Invoices_Service_Fee";
                p_NWC_Invoices_Service_Fee.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Service_Fee);

                SqlParameter p_NWC_Invoices_Tax_Rate = new SqlParameter();
                p_NWC_Invoices_Tax_Rate.ParameterName = "@NWC_Invoices_Tax_Rate";
                p_NWC_Invoices_Tax_Rate.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Tax_Rate);

                SqlParameter p_NWC_Invoices_Is_There_Sanitation = new SqlParameter();
                p_NWC_Invoices_Is_There_Sanitation.ParameterName = "@NWC_Invoices_Is_There_Sanitation";
                p_NWC_Invoices_Is_There_Sanitation.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Is_There_Sanitation);

                SqlParameter p_NWC_Invoices_Consumption_Value = new SqlParameter();
                p_NWC_Invoices_Consumption_Value.ParameterName = "@NWC_Invoices_Consumption_Value";
                p_NWC_Invoices_Consumption_Value.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Consumption_Value);

                SqlParameter p_NWC_Invoices_Wastewater_Consumption_Value = new SqlParameter();
                p_NWC_Invoices_Wastewater_Consumption_Value.ParameterName = "@NWC_Invoices_Wastewater_Consumption_Value";
                p_NWC_Invoices_Wastewater_Consumption_Value.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Wastewater_Consumption_Value);

                SqlParameter p_NWC_Invoices_Total_Invoice = new SqlParameter();
                p_NWC_Invoices_Total_Invoice.ParameterName = "@NWC_Invoices_Total_Invoice";
                p_NWC_Invoices_Total_Invoice.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Total_Invoice);

                SqlParameter p_NWC_Invoices_Tax_Value = new SqlParameter();
                p_NWC_Invoices_Tax_Value.ParameterName = "@NWC_Invoices_Tax_Value";
                p_NWC_Invoices_Tax_Value.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Tax_Value);

                SqlParameter p_NWC_Invoices_Total_Bill = new SqlParameter();
                p_NWC_Invoices_Total_Bill.ParameterName = "@NWC_Invoices_Total_Bill";
                p_NWC_Invoices_Total_Bill.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Total_Bill);

                SqlParameter p_NWC_Invoices_Total_Reasons = new SqlParameter();
                p_NWC_Invoices_Total_Reasons.ParameterName = "@NWC_Invoices_Total_Reasons";
                p_NWC_Invoices_Total_Reasons.Value = invoice.NwcInvoicesTo;
                cmd.Parameters.Add(p_NWC_Invoices_Total_Reasons);

                cn.Open();
                id = cmd.ExecuteNonQuery();
                cn.Close();
            }
            if (id > 0)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
