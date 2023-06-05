using Npgsql;
using NpgsqlTypes;
using SHAGovWebApi.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SHAGovWebApi.Repository
{
    public class DataLayer
    {
        public static string ConString = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();
        public dataSet GetMemberInformationJSON(string pmrssm_id)
        {
            dataSet dsObj = new dataSet();            
            using (NpgsqlConnection con = new NpgsqlConnection(ConString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("select*from sp_EmpList('Nitin')", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 2500;
                    //cmd.Parameters.Add("@pmrssm_id",NpgsqlTypes.NpgsqlDbType.Varchar,20).Value = pmrssm_id;
                    try
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        da.Fill(ds);
                        dsObj.ResultSet = ds;
                        dsObj.Msg = "Success";
                        con.Close();
                    }
                    catch (SqlException sqlEx)
                    {
                        dsObj.ResultSet = null;
                        dsObj.Msg = sqlEx.Message;
                    }
                    finally { con.Close(); }
                    return dsObj;
                }
            }
        }
        public dataSet ChandanTestMemberInfo(string pmrssm_id)
        {
            dataSet dsObj = new dataSet();
            using (SqlConnection con = new SqlConnection("Data Source=192.168.4.100;Initial Catalog=UK_SHA;Persist Security Info=false;User ID=sa; password=ex_1958_pro"))
            {
                using (SqlCommand cmd = new SqlCommand("pgetMemberInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2500;
                    cmd.Parameters.Add("@pmrssm_id", SqlDbType.VarChar, 10).Value = pmrssm_id;
                    try
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        dsObj.ResultSet = ds;
                        dsObj.Msg = "Success";
                        con.Close();
                    }
                    catch (SqlException sqlEx)
                    {
                        dsObj.ResultSet = null;
                        dsObj.Msg = sqlEx.Message;
                    }
                    finally { con.Close(); }
                    return dsObj;
                }
            }
        }
        public string SyncChandanPatientData(SyncChandanPatientData obj)
        {
            string processInfo = string.Empty;                              
            using (NpgsqlConnection con = new NpgsqlConnection(ConString))
            {
                string callProc = "call sp_SyncChandanPatientData(:_SGHS_Card,:_abhaNo,:_claim_id,:_visit_id,:_benef_Name,:_tyepOfEmployee,:_empcode,:_dob,:_depttCode,:_depttName,:_tres_code,:_tres_Name,:_totalcost,:_discount,:_net,:_billFile,:_prescrFile,:_vendorID,:_PayVendSyncFlag,:_PayVendSyncDate,:_resultMsg)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(callProc, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 2500;
                    cmd.Parameters.AddWithValue("_SGHS_Card", NpgsqlDbType.Varchar, 20).Value = obj.SGHS_Card;
                    cmd.Parameters.AddWithValue("_abhaNo", NpgsqlDbType.Varchar, 20).Value = obj.abhaNo;
                    cmd.Parameters.AddWithValue("_claim_id", NpgsqlDbType.Varchar, 100).Value = obj.claim_id;
                    cmd.Parameters.AddWithValue("_visit_id", NpgsqlDbType.Varchar, 20).Value = obj.visit_id;
                    cmd.Parameters.AddWithValue("_benef_Name", NpgsqlDbType.Varchar, 100).Value = obj.benef_Name;
                    cmd.Parameters.AddWithValue("_tyepOfEmployee", NpgsqlDbType.Varchar, 20).Value = obj.tyepOfEmployee;
                    cmd.Parameters.AddWithValue("_empcode", NpgsqlDbType.Varchar, 20).Value = obj.empcode;
                    cmd.Parameters.AddWithValue("_dob", NpgsqlDbType.Date, 20).Value = obj.d_o_b;
                    cmd.Parameters.AddWithValue("_depttCode", NpgsqlDbType.Varchar, 20).Value = obj.depttCode;
                    cmd.Parameters.AddWithValue("_depttName", NpgsqlDbType.Varchar, 200).Value = obj.depttName;
                    cmd.Parameters.AddWithValue("_tres_code", NpgsqlDbType.Varchar, 20).Value = obj.tres_code;
                    cmd.Parameters.AddWithValue("_tres_Name", NpgsqlDbType.Varchar, 200).Value = obj.tres_Name;
                    cmd.Parameters.AddWithValue("_totalcost", NpgsqlDbType.Numeric).Value = obj.totalcost;
                    cmd.Parameters.AddWithValue("_discount", NpgsqlDbType.Numeric).Value = obj.discount;
                    cmd.Parameters.AddWithValue("_net", NpgsqlDbType.Numeric).Value = obj.net;
                    cmd.Parameters.AddWithValue("_billFile", NpgsqlDbType.Varchar, 200).Value = obj.billFile;
                    cmd.Parameters.AddWithValue("_prescrFile", NpgsqlDbType.Varchar, 200).Value = obj.prescrFile;
                    cmd.Parameters.AddWithValue("_vendorID", NpgsqlDbType.Varchar, 20).Value = obj.vendorID;
                    cmd.Parameters.AddWithValue("_PayVendSyncFlag", NpgsqlDbType.Varchar, 1).Value = obj.PayVendSyncFlag;
                    cmd.Parameters.AddWithValue("_PayVendSyncDate", NpgsqlDbType.Date, 20).Value = obj.PayVendSyncDate;
                    cmd.Parameters.AddWithValue("_resultMsg", NpgsqlDbType.Varchar, 100).Value = "";
                    cmd.Parameters["_resultMsg"].Direction = ParameterDirection.InputOutput;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        processInfo = (string)cmd.Parameters["_resultMsg"].Value.ToString();
                        con.Close();
                    }
                    catch (SqlException sqlEx)
                    {
                        processInfo = "Error Found   : " + sqlEx.Message;
                    }
                    finally { con.Close(); }
                    return processInfo;
                }
            }
        }
    }
}