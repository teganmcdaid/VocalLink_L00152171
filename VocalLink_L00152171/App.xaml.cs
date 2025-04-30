using VocalLink_L00152171.Services;

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
            Database = new DatabaseService(dbPath);

            MainPage = new AppShell();
        }
    }
}
