using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.SubscriptionContext;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            foreach (var item in articles)
            {
                System.Console.WriteLine(item.Id);
                System.Console.WriteLine(item.Title);
                System.Console.WriteLine(item.Url);
                System.Console.WriteLine("------------------------");
            }

            var courses = new List<Course>();

            var courseOOP = new Course("Fundamentos OOP", "fundametos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundametos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundametos-aspnet");

            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var carrers = new List<Career>();
            var careerDotNet = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem2 = new CareerItem(2, "Aprenda OOP", "", null);
            var careerItem = new CareerItem(1, "Comece por aqui", "", courseCsharp);
            var careerItem3 = new CareerItem(3, "Aprenda .NET", "", courseAspNet);
            careerDotNet.Items.Add(careerItem2);
            careerDotNet.Items.Add(careerItem);
            careerDotNet.Items.Add(careerItem3);
            carrers.Add(careerDotNet);

            foreach (var career in carrers)
            {
                System.Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    System.Console.WriteLine($"{item.Order} - {item.Title}");
                    System.Console.WriteLine(item.Course?.Title);
                    System.Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications)
                    {
                        System.Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }

                    System.Console.WriteLine("------------------------");
                }

                var payPalSubscription = new PayPalSubscription();
                var student = new Student();
                student.Subscriptions.Add(payPalSubscription);
            }
        }
    }
}
