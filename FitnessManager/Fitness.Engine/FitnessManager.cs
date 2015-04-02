namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;

    using Fitness.Models;
    using Fitness.Models.UserRegimens;
    using Fitness.Engine.Interfaces;

    /// <summary>
    /// Main abstract class of the Fitness Manager.
    /// </summary>
    public abstract class FitnessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManager"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the class UserManager.</param>
        public FitnessManager(UserManager userManager, IRenderer renderer)
        {
            this.UserManager = userManager;
            this.Renderer = renderer;
        }

        public IRenderer Renderer { get; set; }

        public UserManager UserManager { get; set; }


        /// <summary>
        /// Runs the application.
        /// </summary>
        public virtual void Start()
        {
            //Override main loop for your client
        }

        public virtual void HandleLogout(string username)
        {
            this.UserManager.Logout(username);
            this.Renderer.RenderMessage(Messages.LogoutMessage);
        }

        public virtual void HandleLogin(string username, string password)
        {
            this.UserManager.Login(username, password);
            this.Renderer.RenderMessage(Messages.LoggedInMessage);
        }

        public virtual void HandleUserRegistration(User user)
        {           
            this.UserManager.Register(user);
            this.Renderer.RenderMessage(Messages.RegisteredMessage);
        }

        /// <summary>
        /// Export the regimen to two PDF files.
        /// </summary>
        /// <param name="regimen">The regimen.</param>
        public void ExportRegimenToPdf(Regimen regimen)
        {
            // var diet = regimen.Diet;

            // var dataTable = new DataTable("Diet");
            // dataTable.Columns.Add(new DataColumn("ColumnHeader1", typeof(Int32)));
            // dataTable.Columns.Add(new DataColumn("ColumnHeader2", typeof(string)));
            // DataRow dataRow;
            // int rows = 5;
            // for (int i = 0; i < rows; i++)
            // {
            //     dataRow = dataTable.NewRow();
            //     dataRow["ColumnHeader1"] = null;    // 1st column content 
            //     dataRow["ColumnHeader2"] = null;    // 2nd column content
            //     dataTable.Rows.Add(dataRow);
            // }

            // dataTable.AcceptChanges();

            // FileAccess.WritePdf("Diet", dataTable, @"..\..\..\..\Diet.pdf");
        }
    }
}
