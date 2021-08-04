public ExportFileGetInfoSerialResponse ExportFileGetInfoSerial(ExportFileGetInfoSerialRequest request, ProviderExportSerial Pro, ExportFileGetInfoSerialResponse res)
        {
            string strSP = SqlCommandStore.uspExportFileGetInfoSerial;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = request.FromDate;
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = request.ToDate;
                    cmd.Parameters.Add("@ServiceIDs", SqlDbType.NVarChar).Value = string.Join(",", Pro.ServiceIDs);
                    cmd.Parameters.Add("@AgentIDs", SqlDbType.NVarChar).Value = string.Join(",", request.AgentIDs);
                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    
                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    DataRow[] rows = new DataRow[ds.Tables[0].Rows.Count];
                    ds.Tables[0].Rows.CopyTo(rows, 0);
                    res.Transactions = rows.Select(row => new TransactionModel(row)).ToList();
                }
                if (res.Code != ReturnCode.Success)
                {
                    return res;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }