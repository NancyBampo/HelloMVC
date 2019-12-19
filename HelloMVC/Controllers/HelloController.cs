using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller   
    {
        private static int count = 0;
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            /*if (string.IsNullOrEmpty(name))
            {
                name = "Nancy";
            }*/
            string html = "<form method='post'>" +
                "<input type = 'text' name ='name'/>" +
                "<select size='1' name='language' id='lang_id' runat='server'>" +
                    "<option selected='selected'value='default'>Please Select a Launguage</option>"+
                    "<option value='English'>English</option>"+
                    "<option value='Spanish'>Spanish</option>"+
                    "<option value='French'>French</option>"+
                    "<option value='Twi'>Twi</option>"+
                    "<option value='Amharic'>Amharic</option>"+
                "</select>"+
                "<input type ='submit' value = 'Greet me!'/>" +
                "</form>";

            return Content(html, "text/html");
            //return Redirect("/Hello/Goobye");
        }

        public static string CreateMessage(string name, string language)
        {
            string lang;

            lang = "";
            if (string.IsNullOrEmpty(name))
            {
                name = "World";
            }
            if (language == "default")
            {
                lang = "Hello";
                return (string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }

            else if (language == "English")
            {
                lang = "Hello";
                return(string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }
            else if(language == "Spanish")
            {
                lang = "Hola";
                return (string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }
            else if(language == "French")
            {
                lang = "Bonjour";
                return (string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }
            else if(language == "Twi")
            {
                lang = "Maakye";
                return (string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }
            else if(language == "Amharic")
            {
                lang = "Selam";
                return (string.Format("<h1>{0}, {1}!</h1>", lang, name));
            }

            string message = $"<h1>{lang}</h1><h1>{name}</h1>";
            return message;
        }
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Home(string name, string language)
        {
            string message = CreateMessage(name, language);
            count++;

            return Content(message + "<br><p>You have been greeted " + count + " times</p>", "text/html");
        }

        //Hello/Goodbye
        //alter the route to this controller to be: /Hello/Aloha
        //[Route("/Hello/Aloha")]

        // handle requests to /Hello/Nancy(URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello, {0} </h1>", name), "text/html");
        }
        public IActionResult Goodbye()
        {
            return Content("<h1>Goodbye</>", "text/html");
        }
    }
}
