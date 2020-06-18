using System;
using TechTalk.SpecFlow;

namespace CrudTest.Spec.Steps
{
    [Binding]
    public class CreateCustomerSteps
    {
        [Given(@"I have CreateCustomer link")]
        public void GivenIHaveCreateCustomerLink()
        {
            ScenarioContext.Current.Pending();
            
        }
        
        [When(@"I clicked on")]
        public void WhenIClickedOn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"CreateCustomer Page must be shown")]
        public void ThenCreateCustomerPageMustBeShown()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
