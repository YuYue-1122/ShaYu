using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Model.Result.App
{
    public class ProfitResult
    {
        public string InstallDate { get; set; }
        public int AppCount { get; set; }
        public decimal UnitPrice { get; set; }
        public string Profit { get; set; }
        public decimal ClerkProportion { get; set; }
    }
}
