namespace UnitTestingCourse.Examples.Example4.SoC.Bad
{
    public class ImplementationInOneFileService
    {
        public byte[] GenerateReport(int id)
        {
            var reportData = GetDataFilteredById(id);
            var mappedData = MapData(reportData);
            var reportInBytes = GetReport(mappedData);
            return reportInBytes;
        }

        private object GetDataFilteredById(in int id)
        {
            throw new System.NotImplementedException();
        }

        private object MapData(object reportData)
        {
            throw new System.NotImplementedException();
        }

        private byte[] GetReport(object mappedData)
        {
            throw new System.NotImplementedException();
        }
    }
}