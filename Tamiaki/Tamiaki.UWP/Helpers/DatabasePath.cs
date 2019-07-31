using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamiaki.Helpers;

namespace Tamiaki.UWP.Helpers
{
    public class DatabasePath:IDbPath
    {
        public DatabasePath()
        {
            
        }
        public string GetDbPath()
        {
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "TamiakiDB.db");
        }
    }
}
