public ResponseObject ExportFileGetInfoSerial(string requestData)
        {
            ResponseObject res = new ResponseObject()
            {
                ReturnCode = ReturnCode.Success
            };
            try
            {
                string[] allFiles = Directory.GetFiles(Path.Combine(CoreConfig.ExportInfoSerial), "*.csv");
                string ZipName = string.Format("History_Transaction_Momo.zip");
                string zipPath = Path.Combine(CoreConfig.ExportInfoSerialZip, ZipName);
                File.Delete(zipPath);
                foreach (var file in allFiles)
                {
                    File.Delete(file);
                }
                if (!Directory.Exists(Path.Combine(CoreConfig.ExportInfoSerial)))
                {
                    Directory.CreateDirectory(Path.Combine(CoreConfig.ExportInfoSerial));
                }
                ExportFileGetInfoSerialRequest request = new ExportFileGetInfoSerialRequest();
                var base64EncodedBytes = Convert.FromBase64String(requestData);
                var parsedString = Encoding.ASCII.GetString(base64EncodedBytes);
                request = JsonConvert.DeserializeObject<ExportFileGetInfoSerialRequest>(parsedString);
                if (request.DayFromDate == 0)
                {
                    request.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0); // Set đầu tháng hiện tại
                }
                else
                {
                    var dtFD = DateTime.Now.AddDays(-request.DayFromDate);
                    request.FromDate = new DateTime(dtFD.Year, dtFD.Month, dtFD.Day, 0, 0, 0, 0); //00:00:00 AM
                }
                request.ToDate = DateTime.Now.AddDays(-request.DayToDate);
                if (request.ToDate != DateTime.Now)
                {
                    var dtTD = DateTime.Now.AddDays(-request.DayToDate);
                    request.ToDate = new DateTime(dtTD.Year, dtTD.Month, dtTD.Day, 23, 59, 59); //23:59:59 PM
                }
                ExportFileGetInfoSerialResponse resData = new ExportFileGetInfoSerialResponse()
                {
                    Code = ReturnCode.Success
                };
                foreach (var Provider in request.Providers)
                {
                    res.ResponseData = dao.ExportFileGetInfoSerial(request, Provider, resData);
                    string fileName = string.Format("History_Transaction_Momo_{0}.csv", Provider.ProviderName);
                    string filePath = Path.Combine(CoreConfig.ExportInfoSerial, fileName);
                    StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
                    string newLine = string.Empty;
                    string title = "CreateDate" + "," + "ServiceID" + "," + "TransactionID" + "," + "Serial" + "," + "Price" + "," + "ExpireDate" + "," + "SaleDate";
                    sw.WriteLine(title);
                    foreach (var tran in resData.Transactions)
                    {
                        dynamic Info = JsonConvert.DeserializeObject<dynamic>(tran.Info);
                        foreach (var item in Info)
                        {
                            sw.WriteLine(tran.CreateDate + "," + tran.ServiceID + "," + tran.TransactionID + "," + item.Serial + "," + item.Price + "," + item.ExpriedDate + "," + tran.CreateDate);
                        }
                    }
                    sw.Close();
                }
                //string[] files = Directory.GetFiles(Path.Combine(CoreConfig.ExportInfoSerial), "*.csv");
                if (!File.Exists(zipPath))
                {
                    ZipFile.CreateFromDirectory(Path.Combine(CoreConfig.ExportInfoSerial), zipPath);
                    //    var zip = System.IO.Compression.ZipFile.Open(zipPath, System.IO.Compression.ZipArchiveMode.Create);
                    //    foreach (var file in files)
                    //    {
                    //        zip.CreateEntryFromFile(file, Path.GetFileName(file), System.IO.Compression.CompressionLevel.Optimal);
                    //    }
                    //    zip.Dispose();
                }
                return res;
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                res.ReturnCode = ReturnCode.SystemError;
                return res;
            }
        }

        public void SendAttachment(string requestData)
        {
            SendAttachmentRequest request = new SendAttachmentRequest();
            var base64EncodedBytes = Convert.FromBase64String(requestData);
            request = JsonConvert.DeserializeObject<SendAttachmentRequest>(Encoding.ASCII.GetString(base64EncodedBytes));
            string ZipName = string.Format("History_Transaction_Momo.zip");
            request.Path = Path.Combine(CoreConfig.ExportInfoSerialZip, ZipName);
            TemplateModel template = new TemplateModel();
            try
            {
                SmtpClient client = new SmtpClient(request.Host);
                client.Port = request.Port;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(request.From, request.FromPassword);
                MailMessage msg = new MailMessage(request.From, request.To);
                msg.Subject = request.Subject;
                msg.Body = template.BodyEmail;
                msg.Attachments.Add(new Attachment(request.Path));
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }