﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Bogus;
using System.IO;

namespace NikeAccountGen
{
    class Program
    {
        public static void SendkeySlow(string text, IWebElement element)

        {
            var faker = new Faker("en");


            foreach (Char str in text)
            {
                int delay = faker.Random.Number(200, 400);
                element.SendKeys(Convert.ToString(str));
                Thread.Sleep(delay);
            }

        }

        public static void Main(string[] args)
        {

            int gennumber;

            Console.WriteLine("Please Enter how many acccounts you want to generate.");

            gennumber = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < gennumber; i++)
            {
                var faker2 = new Faker("en");

                var pofemail = faker2.Name.FirstName() + faker2.Name.LastName() + Convert.ToString(faker2.Random.Number(1243211, 45237728)) + "@yourcatchall.com";

                var Fname = faker2.Name.FirstName();

                var Lname = faker2.Name.LastName();

                string passwlower = faker2.Name.LastName();

                var randomint = faker2.Random.Number(0, 10);

                string passwupper = faker2.Name.Prefix();

                passwlower.ToLower();
                passwupper.ToUpper();

                var Passw = faker2.Internet.Password() + randomint + passwlower + passwupper;

                var GenUserAgent = faker2.Internet.UserAgent();
                // USERAGENT generated by BOGUS could be unusable. 


                var Bmonth = faker2.Random.Number(10, 12);

                var Bday = faker2.Random.Number(10, 30);

                var Byear = faker2.Random.Number(1970, 2002);

                string Birthday = Convert.ToString(Bmonth) + Convert.ToString(Bday) + Convert.ToString(Byear);


                IWebElement Email;
                IWebElement Password;
                IWebElement FirstName;
                IWebElement LastName;
                IWebElement Date;
                IWebElement Gend;
                IWebElement Register;

                Console.WriteLine("Sleeping for 2500ms...");
                Thread.Sleep(2500);

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--user-agent=" + GenUserAgent);
                // You can change your useragent here.
                
                IWebDriver driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl("https://www.nike.com/register");

                int SleepingTime = 2000;

                while (true)
                {
                    try
                    {

                        Console.WriteLine("Finding elements...");

                        Email = driver.FindElement(By.XPath("//*[@type='email']"));
                        //Console.WriteLine("Found Email Element.");

                        Password = driver.FindElement(By.XPath("//*[@type='password']"));
                        //Console.WriteLine("Found Password Element.");

                        FirstName = driver.FindElement(By.XPath("//*[@placeholder='First Name']"));
                        //Console.WriteLine("Found FirstName Element.");

                        LastName = driver.FindElement(By.XPath("//*[@placeholder='Last Name']"));
                        //Console.WriteLine("Found LastName Element.");

                        Date = driver.FindElement(By.XPath("//*[@type='date']"));
                        //Console.WriteLine("Found Birthday Element.");

                        Gend = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[4]/form/div[7]/ul/li[1]/span"));
                        //Console.WriteLine("Found Gender Selection Element.");

                        Register = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[4]/form/div[9]/input"));
                        //Console.WriteLine("Found Register Element.");
                    }

                    catch (NoSuchElementException)
                    {

                        SleepingTime += 1000;

                        driver.Close();


                        IWebDriver newdriver = new ChromeDriver(options);
                        driver = newdriver;

                        driver.Navigate().GoToUrl("https://www.nike.com/register");

                        Console.WriteLine("Can't find the next Element, restarting...");
                        Console.WriteLine("Sleeping for " + SleepingTime + "ms...");

                        Thread.Sleep(SleepingTime);

                        continue;
                    }

                    var faker = new Faker("en");


                    Console.WriteLine("Filling Birthday...");
                    Console.WriteLine("Fingerprinting...");

                    try
                    {
                        Date.SendKeys(Birthday);
                    }
                    catch (ElementNotSelectableException)
                    {
                        continue;
                    }


                    Console.WriteLine("Typing Email...");
                    Email.Click();
                    SendkeySlow(pofemail, Email);

                    Console.WriteLine("Typing Password...");
                    Password.Click();
                    SendkeySlow(Passw, Password);

                    Console.WriteLine("Typing FirstName...");
                    FirstName.Click();
                    SendkeySlow(Fname, FirstName);

                    Console.WriteLine("Typing LastName...");
                    LastName.Click();
                    SendkeySlow(Lname, LastName);



                    Thread.Sleep(faker2.Random.Number(100, 500));

                    Console.WriteLine("Selecting Gender...");
                    Gend.Click();

                    Console.WriteLine("Registering...");
                    Thread.Sleep(faker2.Random.Number(3200, 4000));

                    Register.Click();
                    Console.WriteLine("Registeration Finished...");

                    Console.WriteLine("Prepare writing to textfile");
                    Thread.Sleep(4000);


                    File.AppendAllLines("accounts.txt", new[] { pofemail + ":" + Passw });

                    driver.Quit();

                    break;

                }
            }

        }
    }
}
