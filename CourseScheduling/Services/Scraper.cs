//using HtmlAgilityPack;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;



//namespace CourseScheduling.Services
//{
//    public class Course
//    {
//        public string Title { get; set; }
//        public string CourseName { get; set; }
//        public int Credits { get; set; }
//    }
//    public class Scraper
//    {
//        private static readonly HttpClient client = new HttpClient();

//        public async Task<List<Course>> ScrapeCourseCatalogAsync(string url)
//        {
//            var courses = new List<Course>();

//            // Load the web page
//            var response = await client.GetStringAsync(url);
//            var htmlDoc = new HtmlDocument();
//            htmlDoc.LoadHtml(response);

            
//            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//div[@class='course']")) // adjust XPath as needed
//            {
//                var title = node.SelectSingleNode(".//h2").InnerText.Trim();
//                var description = node.SelectSingleNode(".//p").InnerText.Trim();
//                var credits = int.Parse(node.SelectSingleNode(".//span[@class='credits']").InnerText.Trim());

//                courses.Add(new Course { Title = title, CourseName = description, Credits = credits });
//            }

//            return courses;
//        }
//    }
//}
