using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApplication1
{
    public class PageObject
    {

        private String header;
        private bool isClicked = true;
        private IWebElement getLink;
        private int a = 1;
        private List<string> clickedLinksList = new List<string> { "init" };
        private int counter = 0;
        public IWebDriver webDriver = new ChromeDriver();

        public void OpenRandomWikiPage()
        {
            webDriver.Url = "https://en.wikipedia.org/wiki/Special:Random";
        }

        public String GetHeader()
        {
            return header;
        }

        public int GetCounter()
        {
            return counter;
        }

        public void CheckArticleHeader()
        {
            try
            {
                IWebElement checkHeader = webDriver.FindElement(By.Id("firstHeading"));
                header = checkHeader.Text;
            }
            catch (NoSuchElementException)
            {
            }
        }
   
        public void CheckLinkIfClicked()
        {
            foreach (string clicked in clickedLinksList)
            {
                if (clicked == getLink.Text)
                {
                    a++;
                    isClicked = true;
                    break;
                }
                if (clicked != getLink.Text)
                {
                    isClicked = false;
                }
            }
        }

        public void ClickLink()
        {
            clickedLinksList.Add(getLink.Text);
            getLink.Click();
            isClicked = true;
            a = 1;
            counter++;
        }
        public void GetValidLink()
        {
            while (isClicked)
            {
                try
                {
                    getLink = webDriver.FindElement(By.XPath("//*[@id='mw-content-text']/div/p[1]/a[" + a + "]"));
                }
                catch (NoSuchElementException)
                {
                    TrySecondParagraph();
                    return;
                }
                CheckLinkIfClicked();
            }
            getLink = webDriver.FindElement(By.XPath("//*[@id='mw-content-text']/div/p[1]/a[" + a + "]"));
            ClickLink();
        }

        public void TrySecondParagraph()
        {
            while (isClicked)
            {
                try
                {
                    getLink = webDriver.FindElement(By.XPath("//*[@id='mw-content-text']/div/p[2]/a[" + a + "]"));
                }
                catch (NoSuchElementException)
                {
                    TryAnotherLink();
                    return;
                }
                CheckLinkIfClicked();
            }
            getLink = webDriver.FindElement(By.XPath("//*[@id='mw-content-text']/div/p[2]/a[" + a + "]"));
            ClickLink();
        }

        public void TryAnotherLink()
        {
            try
            {
                getLink = webDriver.FindElement(By.XPath("//*[@id='mw-content-text']/div/p[1]/b/a"));
                ClickLink();
            }
            catch (NoSuchElementException)
            {
                webDriver.Url = "https://en.wikipedia.org/wiki/Special:Random";
            }
        }

        public void Reset()
        {
            header = "";
            counter = 0;
            clickedLinksList = new List<string> { "init" };

        }
    }
}
























