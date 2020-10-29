using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cotemar.Models.Catalogs
{
    public partial class ProgressReportListModel
    {
        [JsonProperty("Progress_Reports")]
        public List<Progress_Report> ProgressReports { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }

    public partial class Progress_Report
    {
        [JsonProperty("ReportId")]
        public int ReportId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
