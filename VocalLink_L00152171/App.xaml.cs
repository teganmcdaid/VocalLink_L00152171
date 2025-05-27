// <copyright file="App.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171
{
    using VocalLink_L00152171.Services;
    using VocalLink_L00152171.Views;

    /// <summary>
    /// application class for the VocalLink application.
    /// </summary>
    public partial class App : Application
    {
        private static DatabaseService database;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            // Set the database path
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Products.db3");

            // delete existing DB
            // if (File.Exists(dbPath))
            //    File.Delete(dbPath);
            Database = new DatabaseService(dbPath);

            this.MainPage = new AppShell();
        }

        /// <summary>
        /// Gets the database service instance used throughout the application.
        /// </summary>
        public static DatabaseService Database { get => database; private set => database = value; }
    }
}
