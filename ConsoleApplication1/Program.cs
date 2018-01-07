
using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;





namespace Philosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            
 
            System.Console.WriteLine("Please choose a number of cycles:");
            System.Int32.TryParse(System.Console.ReadLine(), out userInput);

            while (true) { 

            if (userInput > 0)
            {

                 PageObject pageObject = new PageObject();

                for (var i = 1; i <= userInput; i++)
                {

                    pageObject.OpenRandomWikiPage();

                    while (pageObject.GetHeader() != "Philosophy")
                    {
                        pageObject.CheckArticleHeader();
                        if (pageObject.GetHeader() != "Philosophy")
                        {
                            pageObject.GetValidLink();
                        }
                    }
                    System.Console.WriteLine("Number of steps needed in {0}. cycle: {1}", i, pageObject.GetCounter());
                    pageObject.Reset();
                }

                    System.Console.WriteLine("Feel free to try again, choose a number of cycles:");
                    System.Int32.TryParse(System.Console.ReadLine(), out userInput);

                }
            else
            {
                System.Console.WriteLine("Invalid choice, please try again:");
                    System.Int32.TryParse(System.Console.ReadLine(), out userInput);
                }
        }
        }
    }
}
