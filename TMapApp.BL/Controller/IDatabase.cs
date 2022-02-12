using System.Collections.Generic;

namespace TMapApp.BL.Controller
{
    public interface IDatabase
    {
        List<KeyValuePair<string, string>> GetPointsInfo();
    }
}
