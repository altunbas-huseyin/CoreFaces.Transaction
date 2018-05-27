using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Transaction.Models
{
    public class TransactionSettings
    {
        public string FileUploadFolderPath { get; set; } = "";
        public string TransactionLicenseDomain { get; set; } = "";
        public string TransactionLicenseKey { get; set; } = "";
    }
}
