using System;
using System.IO;
using Cotemar.DependencyServices;
using Cotemar.Droid.DependencyServices;
using Cotemar.Settings;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteDependecyServiceAndroid))]
namespace Cotemar.Droid.DependencyServices
{
    public class SqlLiteDependecyServiceAndroid : ISqlLiteDependecyService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppConfiguration.Values.NameDB);
        }
    }
}