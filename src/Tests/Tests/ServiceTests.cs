﻿#region Using Statements
    using System;
    using System.IO;
    using System.Collections.ObjectModel;
    using System.ServiceProcess;

    using Xunit;

    using System.Management.Automation;
    using System.Management.Automation.Runspaces;

    using Cake.Core.Diagnostics;
    using Cake.Core.IO;
    using Cake.Powershell;
#endregion



namespace Cake.Services.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void Should_Service_IsInstalled()
        {
            IServiceManager manager = CakeHelper.CreateServiceManager();

            bool result1 = manager.IsInstalled("MpsSvc");
            bool result2 = manager.IsInstalled("TestSer");

            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Should_Get_Service()
        {
            IServiceManager manager = CakeHelper.CreateServiceManager();

            ServiceController controller = manager.GetService("MpsSvc");

            Assert.True(controller != null, "Check Rights");
        }

        [Fact]
        public void Should_Change_Service_State()
        {
            IServiceManager manager = CakeHelper.CreateServiceManager();
            bool result = false;

            if (manager.IsRunning("MpsSvc"))
            {
                result = manager.Stop("MpsSvc");
            }
            else
            {
                result = manager.Start("MpsSvc");
            }

            Assert.True(result, "Check Rights");
        }
    }
}
