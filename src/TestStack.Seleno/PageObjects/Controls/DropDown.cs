﻿using OpenQA.Selenium;
using By = TestStack.Seleno.PageObjects.Locators.By;

namespace TestStack.Seleno.PageObjects.Controls
{
    public class DropDown : SelectableHtmlControl
    {
        public string SelectedElementText { get { return SelectedElement.Text; } }
        
        protected override IWebElement SelectedElement
        {
            get
            {
                var selector = string.Format("$('#{0} option:selected')", Id);
                return Find().ElementWithWait(By.jQuery(selector), WaitInSecondsUntilElementAvailable);
            }
        }

        public void SelectElementByText(string optionText)
        {
            var scriptToExecute = string.Format("$('#{0} option:contains(\"{1}\")').attr('selected',true)", Id, optionText);
            Execute().ExecuteScript(scriptToExecute);
        }

        public override void SelectElement<TProperty>(TProperty value)
        {
            var scriptToExecute = string.Format("$('#{0}').val('{1}')", Id, value);
            Execute().ExecuteScript(scriptToExecute);
        }
    }
}