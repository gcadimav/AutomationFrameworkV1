namespace PageObjectLibrary.Base
{
    public class BaseStep: BaseDriver
    {
        public void NavigateToInitialSite()
        {
            GetDriver().Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
