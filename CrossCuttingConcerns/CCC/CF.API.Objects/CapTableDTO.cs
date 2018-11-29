namespace CF.API.Objects
{
    public class CapTableDTO
    {
        public VCExpertsData vcExpertsData = new VCExpertsData();
    }

    public class VCExpertsData
    {
        public VCExpertsData()
        {
        }

        public object companyLevelData { get; set; }
        public object companyNoteInvestments { get; set; }
        public object seriesData { get; set; }

    }
}
