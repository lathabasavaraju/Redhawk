using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using RedHawk.Model.InboundModel;

namespace RedHawk.Service.DataAccessLayer
{
    public class InboundDAL
    {
        string sqlConnectionString = "Data Source=AL-SPAN-3;Initial Catalog = Redhawk; Integrated Security = True";

        public IEnumerable<InboundModel> GetInboundXml()
        {
            try
            {
                List<InboundModel> inboundModelList = new List<InboundModel>();

                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                SqlCommand sqlCommand = new SqlCommand("assp_GetCEAInboundXML", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    InboundModel inboundModel = new InboundModel();
                    inboundModel.CeaXmlId = Convert.ToInt32(rdr["CEA_xml_id"]);
                    inboundModel.PolicyId = Convert.ToInt32(rdr["policy_id"]);
                    inboundModel.CompanyId = Convert.ToInt32(rdr["company_id"]);
                    inboundModel.PolicyNumber = rdr["policy_number"].ToString();
                    inboundModel.FileName = rdr["filename"].ToString();
                    inboundModel.TransactionType = rdr["transactiontype"].ToString();
                    inboundModel.ProcessingStatus = rdr["proccessingstatus"].ToString();
                    inboundModel.PolicyExpirationDate = rdr["policy_expiration_date"].ToString();
                    inboundModel.PolicyEffectiveDate = rdr["policy_effective_date"].ToString();
                    inboundModel.CompanionPolicyNumber = rdr["companion_policy_number"].ToString();

                    inboundModelList.Add(inboundModel);
                }

                sqlConnection.Close();


                return inboundModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<InboundModel> InboundSearch(InboundSearchModel inboundSearchModel)
        {
            try
            {
                List<InboundModel> inboundModelList = new List<InboundModel>();

                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                SqlCommand sqlCommand = new SqlCommand("assp_CEAInboundXMLSearch", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CompanionPolicyNumber", inboundSearchModel.CompanionPolicyNumber);
                sqlCommand.Parameters.AddWithValue("@FileName", inboundSearchModel.FileName);
                sqlCommand.Parameters.AddWithValue("@CompanyId", inboundSearchModel.CompanyId);
                sqlCommand.Parameters.AddWithValue("@CEAXMLId", inboundSearchModel.CeaXmlId);
                sqlCommand.Parameters.AddWithValue("@FileDate", inboundSearchModel.FileDate);
                sqlCommand.Parameters.AddWithValue("@TransactionType", inboundSearchModel.TransactionType);
                sqlCommand.Parameters.AddWithValue("@ProcessingStatus", inboundSearchModel.ProcessingStatus);

                sqlConnection.Open();
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    InboundModel inboundModel = new InboundModel();
                    inboundModel.CeaXmlId = Convert.ToInt32(rdr["CEA_xml_id"]);
                    inboundModel.PolicyId = Convert.ToInt32(rdr["policy_id"]);
                    inboundModel.CompanyId = Convert.ToInt32(rdr["company_id"]);
                    inboundModel.PolicyNumber = rdr["policy_number"].ToString();
                    inboundModel.FileName = rdr["filename"].ToString();
                    inboundModel.TransactionType = rdr["transactiontype"].ToString();
                    inboundModel.ProcessingStatus = rdr["proccessingstatus"].ToString();
                    inboundModel.PolicyExpirationDate = rdr["policy_expiration_date"].ToString();
                    inboundModel.PolicyEffectiveDate = rdr["policy_effective_date"].ToString();
                    inboundModel.CompanionPolicyNumber = rdr["companion_policy_number"].ToString();

                    inboundModelList.Add(inboundModel);
                }

                sqlConnection.Close();


                return inboundModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateInboundXML(int ceaXmlId, string editedInboundXmlString, string processingStatus)
        {
            int result = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("assp_CEAInboundXMLTableUpdate", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@CEAXMLId", ceaXmlId);
                    sqlCommand.Parameters.AddWithValue("@InboundXml", editedInboundXmlString);
                    sqlCommand.Parameters.AddWithValue("@ProcessingStatus", processingStatus);

                    sqlConnection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
        }

        public InboundEditModel GetInboundXmlEditData(int ceaXmlId)
        {
            try
            {
                List<InboundEditModel> inboundEditModelList = new List<InboundEditModel>();
                InboundEditModel inboundEditModel = new InboundEditModel();
                if (ceaXmlId != 0)
                {
                    SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                    SqlCommand sqlCommand = new SqlCommand("assp_GetXMLDataCEAInboundXML", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CEAXmlId", ceaXmlId);
                    sqlConnection.Open();
                    SqlDataReader rdr = sqlCommand.ExecuteReader();

                    while (rdr.Read())
                    {
                        inboundEditModel.InboundXml = rdr["inboundxml"].ToString();

                        inboundEditModelList.Add(inboundEditModel);
                    }
                    sqlConnection.Close();
                }
                return inboundEditModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}