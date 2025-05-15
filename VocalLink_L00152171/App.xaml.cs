using VocalLink_L00152171.Services;
using VocalLink_L00152171.Views;

namespace VocalLink_L00152171
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; }
        public App()
        {
            InitializeComponent();

            // Set the database path
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                    "Products.db3");

            // delete existing DB 
            //if (File.Exists(dbPath))
            //    File.Delete(dbPath);

            Database = new DatabaseService(dbPath);

            MainPage = new AppShell();

            
        }
    }
}
