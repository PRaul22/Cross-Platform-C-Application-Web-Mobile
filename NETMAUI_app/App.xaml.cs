using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Data;
using System.IO;
using Microsoft.Extensions.DependencyInjection;


namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI
{
    public partial class App : Application
    {
        static RentCarDatabase database;

        public static RentCarDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RentCarDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RentCarDB.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}