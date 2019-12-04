namespace UnitTestingCourse.Examples.Example4.SoC.Good
{
    public class ImplementationSplittedBetweenFilesService
    {
        private readonly GetDataService _getDataService;
        private readonly Mapper _mapper;
        private readonly ReportGenerator _reportGenerator;

        public ImplementationSplittedBetweenFilesService(GetDataService getDataService, Mapper mapper, ReportGenerator reportGenerator)
        {
            _getDataService = getDataService;
            _mapper = mapper;
            _reportGenerator = reportGenerator;
        }

        public byte[] GenerateReport(int id)
        {
            var reportData = _getDataService.GetDataFilteredById(id);
            var mappedData = _mapper.MapData(reportData);
            var reportInBytes = _reportGenerator.Generate(mappedData);
            return reportInBytes;
        }
    }
}