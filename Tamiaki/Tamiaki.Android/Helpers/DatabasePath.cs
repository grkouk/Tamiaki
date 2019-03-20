using System.IO;
using Tamiaki.Droid.Helpers;
using Tamiaki.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Tamiaki.Droid.Helpers
{

    public class DatabasePath : IDbPath
    {

        public DatabasePath()
        {
        }

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EFCoreDB.db");
        }
    }
}
