﻿using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace PegaBugWinService
{
    /// <summary>
    /// This is where you put all the information about the windows service that you want to install
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public ProjectInstaller()
        {
            serviceInstaller = new ServiceInstaller();
            serviceInstaller.ServiceName = "WindowsService";
            serviceInstaller.DisplayName = "WindowsService";
            serviceInstaller.Description = "Service that captures everything that happens with a SQL Server Table";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.DelayedAutoStart = true;
            serviceInstaller.ServicesDependedOn = new string[] { "Tcpip", "Dhcp", "Dnscache" }; //you will need this
            Installers.Add(serviceInstaller);
            
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceProcessInstaller.Account = ServiceAccount.User;
            Installers.Add(serviceProcessInstaller);

            this.AfterInstall += new InstallEventHandler(ServiceInstaller_AfterInstall);
        }

        public string GetContextParameter(string key)
        {
            string sValue = "";
            try
            {
                sValue = this.Context.Parameters[key].ToString();
            }
            catch
            {
                sValue = "";
            }
            return sValue;
        }


        // Override the 'OnBeforeInstall' method.
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            string username = GetContextParameter("user").Trim();
            string password = GetContextParameter("password").Trim();

            if (username != "")
                serviceProcessInstaller.Username = username;
            if (password != "")
                serviceProcessInstaller.Password = password;
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController("WindowsService"))
            {
                sc.Start();
            }
        }
    }
}
     