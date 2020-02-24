using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.AllPages.Init();
            Driver.GoTo(FW.Config.Test.Url);
            Driver.WindowMaximize();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Passed)
            {
                FW.Log.Info("Outcome: Passed");
            }
            else if (outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Warning("Outcome: " + outcome);
            }

            Driver.Quit();
        }
    }
}
