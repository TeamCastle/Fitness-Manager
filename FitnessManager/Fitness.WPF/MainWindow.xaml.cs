namespace Fitness.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using Fitness.Data.Repositories.UsersRepositories;
    using Fitness.Engine;

    /// <summary>
    /// Class containing a program that starts the Fitness Manager for Wpf.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var usersFromDb = new UsersFromDbRepository();
            var usersFromExcel = new UsersFromExcelRepository();
            var usersFromStaticList = new UsersFromStaticListRepository();

            var usersFromRepository = new UsersFromRepository(usersFromDb, usersFromExcel, usersFromStaticList);

            var userManager = new UserManager(usersFromRepository);

            var fitnessManager = new FitnessManagerWpf(userManager);
            fitnessManager.Start();
        }
    }
}
