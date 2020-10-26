using System;
using TechTalk.SpecFlow;

namespace OffiRent.API.Test.StepDefinitions
{
    [Binding]
    public class ActivateOfficesSteps
    {
        [Given(@"offi-provider has Premium Account")]
        public void GivenOffi_ProviderHasPremiumAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"offi-provider is in the deactivated office window")]
        public void GivenOffi_ProviderIsInTheDeactivatedOfficeWindow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"offi-provider has not a Premium Account")]
        public void GivenOffi_ProviderHasNotAPremiumAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"offi-provider clicks in Activate product")]
        public void WhenOffi_ProviderClicksInActivateProduct()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system change the office status to activated")]
        public void ThenTheSystemChangeTheOfficeStatusToActivated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system shows the message This Account is not premium")]
        public void ThenTheSystemShowsTheMessageThisAccountIsNotPremium()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
