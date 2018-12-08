using DogHouse.Core.Services;
using static GoSheets;

namespace DogHouse.Services
{
    /// <summary>
    /// GoogleSheetsRemoteCSVReader is an implementation
    /// of the IRemoteCSVReader. It uses the google
    /// sheets to read from a csv sheet.
    /// </summary>
    public class GoogleSheetsRemoteCSVReader : BaseService<IRemoteCSVReader>, IRemoteCSVReader
    {
        #region Main Methods
        public string[][] FetchRemoteCSV(string url) => GetGoogleSheet(url);
        #endregion
    }
}
