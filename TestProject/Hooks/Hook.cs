using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectLibrary.Initializer;
using PageObjectLibrary.Steps.AutomationPractice.Navigation;

namespace TestProject.Hooks
{
    [TestClass]
    public class Hook: InitializeDriver
    {
        public NavigationSteps navigationSteps;

        [TestInitialize]
        public void TestSetup()
        {
            OpenBrowser();
            navigationSteps = new NavigationSteps();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            CloseBrowser();
        }
    }
}
