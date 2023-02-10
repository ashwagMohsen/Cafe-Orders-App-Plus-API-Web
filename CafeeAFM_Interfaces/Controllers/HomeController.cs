using CafeeAFM.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CafeeAFM_Interfaces.Controllers
{
    public class HomeController : Controller
    {
        static int cou = 1;
        static ArrayList allofdata = new ArrayList();
        //static Dictionary<string, ArrayList> allofdata = new Dictionary<string, ArrayList>();
        static List<add_coffes> coffees = new List<add_coffes>();
        //static ArrayList coffees = new ArrayList();
        //static ArrayList sweets = new ArrayList();
        //static ArrayList books = new ArrayList();
        //static ArrayList wifi = new ArrayList();
        static List<add_sweets> sweets = new List<add_sweets>();
        static List<Book_Infos> books = new List<Book_Infos>();
        static List<Wifi_Infos> wifi = new List<Wifi_Infos>();
        static string connect = "false";
        public ActionResult Index()
        {
            return View();
        }
        string Baseurl = "https://localhost:44346/";
        [HttpGet]
        public async Task<ActionResult> Menu()
        {
            ArrayList allMenue = new ArrayList();
            List<add_coffes> EmpInfo = new List<add_coffes>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetAdditCoffee");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<add_coffes>>(EmpResponse);
                }
                //returning the employee list to view
                allMenue.Add(EmpInfo);
                // ViewBag.cofee = EmpInfo;
            }
            List<add_sweets> EmpInfo2 = new List<add_sweets>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetAdditSweets");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo2 = JsonConvert.DeserializeObject<List<add_sweets>>(EmpResponse);
                }
                //returning the employee list to view
                allMenue.Add(EmpInfo2);
                //ViewBag.sweet = EmpInfo2;
            }
            //if(ViewBag.cofee.Count != 0)
            //        {
            //    foreach (var value in ViewBag.cofee)
            //    {
            //        Console.WriteLine(value.Coffee.CoffeeName);
            //        Console.WriteLine(value.Addition.AddType);
            //        Console.WriteLine(value.Addition.Description);
            //    }
            //}
            // ViewBag.allMenue1 = allMenue;
            return View(allMenue);
        }
        [HttpGet]
        public async Task<ActionResult> Services()
        {
            List<Service> EmpInfo = new List<Service>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetServices");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<Service>>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }
        [HttpPost]
        public ActionResult MenuCoffee(string CoffeeName, string AddType, string Description)
        {
            if (ModelState.IsValid)
            {
                add_coffes newcoffees = new add_coffes();
                newcoffees.Coffee.CoffeeName = CoffeeName; newcoffees.Addition.AddType = AddType; newcoffees.Addition.Description = Description;
                //coffee.Coffee.CoffeeName=
                coffees.Add(newcoffees);
            }

            return RedirectToAction("Menu");
        }
        [HttpPost]
        public ActionResult MenuSweet(string SweetName, string AddType, string Description)
        {

            if (ModelState.IsValid)
            {
                add_sweets sweet = new add_sweets();
                sweet.Sweet.SweetName = SweetName; sweet.Addition.AddType = AddType; sweet.Addition.Description = Description;
                sweets.Add(sweet);
            }

            return RedirectToAction("Menu");
        }
        [HttpPost]
        public ActionResult ServicesBooks(Book_Infos book)
        {

            //Book_Infos new1 = new Book_Infos();
            //new1.Bookname = Bookname2;
            if (book != null)
            {
                books.Add(book);
            }
            return RedirectToAction("Services");
        }
        [HttpPost]
        public ActionResult ServicesWi_Fi(Wifi_Infos wi_fi)
        {
            if (wi_fi != null)
            {
                wifi.Add(wi_fi);
            }

            return RedirectToAction("Services");
        }
        [HttpGet]
        public ActionResult Orders()
        {
            allofdata.Clear();
            //if (coffees.Count != 0)
            //{
            //    allofdata.Add("coffees", coffees);
            //    allofdata.Add("coffees",);
            //}
            //else { allofdata.Add("coffees", coffees); }
            //if (sweets.Count != 0)
            //{
            //    allofdata.Add("sweets", sweets);
            //    allofdata.Add("coffees",);
            //}
            //if (books.Count != 0)
            //{
            //    allofdata.Add("books", books);
            //    allofdata.Add("coffees",);
            //}
            //if (wifi.Count != 0)
            //{
            //    allofdata.Add("wifi", wifi);
            //    allofdata.Add("coffees",);
            //}
            if (coffees.Count == 0)
            {
                allofdata.Add(0);
               
            }
            else
            {
                allofdata.Add(coffees);
            }
            if (sweets.Count == 0)
            {
                allofdata.Add(0);
            }
            else
            {
                allofdata.Add(sweets);
            }
            if (books.Count == 0)
            {
                allofdata.Add(0);
            }
            else { allofdata.Add(books); }
            if (wifi.Count == 0)
            {

                allofdata.Add(0);
            }
            else
            {
                allofdata.Add(wifi);
            }
            /*ViewBag.newlist =*/ ;

            return View(allofdata);
        }
        [HttpPost]
        public async Task<ActionResult> Orders(Order order, string Bookname, string Wifi_Period, string SweetName, string CoffeeName)
        {
            //List<string> strings = new List<string>();
            //strings.Add(Bookname); strings.Add(Wifi_Period); strings.Add(SweetName); strings.Add(CoffeeName); strings.Add(AddType);
            // List<Coffee> EmpInfo = new List<Coffee>();
            ArrayList EmpInfo = new ArrayList();
            if (SweetName == null) { SweetName = "null"; }
            if (CoffeeName == null) { CoffeeName = "null"; }
            if (Bookname == null) { Bookname = "null"; }
            if (Wifi_Period == null) { Wifi_Period = "null"; }
            // List<int> EmpInfo = new List<int>();
            using (var client2 = new HttpClient())
            {
                //Passing service base url
                client2.BaseAddress = new Uri(Baseurl);
                client2.DefaultRequestHeaders.Clear();
                //Define request data format
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client2.GetAsync($"api/GetallofdataIds/{Bookname}/{Wifi_Period}/{SweetName}/{CoffeeName}");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<ArrayList>(EmpResponse);

                    if (EmpInfo[2] != null) { order.SweetID = Convert.ToInt32(EmpInfo[2]); }
                    if (EmpInfo[3] != null) { order.Coffee_ID = Convert.ToInt32(EmpInfo[3]); }
                    if (EmpInfo[4] != null) { order.ServiceID = Convert.ToInt32(EmpInfo[4]); }
                    order.Quantity = 1; order.Total_Price = 1000;
                }
            }
            //post to services table for bookid & wifiid
            //Service service = new Service();
            //using (var client = new HttpClient())
            //{
            //    if (EmpInfo[4] != null) { service.ServiceID = Convert.ToInt32(EmpInfo[4]); }
            //    if (EmpInfo[0] != null) { service.BookID = Convert.ToInt32(EmpInfo[0]); }
            //    if (EmpInfo[1] != null) { service.Wifi_ID = Convert.ToInt32(EmpInfo[1]); }
            //    client.BaseAddress = new Uri("https://localhost:44346/api/");

            //    //HTTP POST
            //    var postTask = client.PostAsJsonAsync<Service>("/Values/Postservice", service);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //}

            //post to orders table
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Order>("Values/PostOrder", order);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {
                    allofdata.Clear();
                    coffees.Clear();
                    sweets.Clear();
                    books.Clear();
                    wifi.Clear();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(allofdata);

        }
        public ActionResult Admin()
        {
            if (connect == "true")
            {
                return View();

            }
            else if (connect == "false")
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Admin>("Values/PostLogin", admin);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {
                    connect = "true";
                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            connect = "false";
            return View();
        }
        //Hosted web API REST Service base url
        //string Baseurl = "https://localhost:44346/";
        //[HttpGet]
        //public async Task<ActionResult> AdminLogin(/*string Name, string Password*/)
        //{
        //    List<Admin> EmpInfo = new List<Admin>();
        //    using (var client = new HttpClient())
        //    {
        //        //Passing service base url
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //        HttpResponseMessage Res = await client.GetAsync("api/GetAdmin");

        //        if (Res.IsSuccessStatusCode)
        //        {
        //            //Storing the response details recieved from web api
        //            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

        //            //Deserializing the response recieved from web api and storing into the Employee list
        //            EmpInfo = JsonConvert.DeserializeObject<List<Admin>>(EmpResponse);
        //        }
        //        //returning the employee list to view
        //        return View(EmpInfo);
        //    }
        //        //=====================================================

        //}
        public ActionResult About()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            connect = "false";
            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> DisplayOrders()
        {
            List<Order> EmpInfo = new List<Order>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetOrders");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<Order>>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }
        //============================== Update =====================
        List<SelectListItem> items = new List<SelectListItem>();

        public async Task<ActionResult> update_coofe2()
        {
            if (connect == "true")
            {
                List<Coffee> EmpInfo = new List<Coffee>();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/GetCoffee");

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<Coffee>>(EmpResponse);
                    }
                    //returning the employee list to view
                }
                foreach (var item in EmpInfo)
                {
                    items.Add(new SelectListItem { Text = item.CoffeeName, Value = item.Coffee_ID.ToString() });
                }
                ViewBag.Coffee_ID = items;


                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
        [HttpPost]
        public async Task<ActionResult> update_coofe2(Coffee co, int? Serv_Id1)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //HTTP POST
                var postTask = client.PutAsJsonAsync<Coffee>($"Values/PutCoffee/{Serv_Id1}", co);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return RedirectToAction("update_coofe2");



        }
        public ActionResult update_book()
        {
            return View();
        }
        public ActionResult update_addition()
        {
            return View();
        }
        public ActionResult update_sweet()
        {
            return View();
        }
        public ActionResult update_typebook()
        {
            return View();
        }
        public ActionResult update_WiFi()
        {
            return View();
        }

        //============================== Add =====================
        public ActionResult ceate_book2()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ceate_book2(Book_Infos book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Book_Infos>("Values/Postceate_book2", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }
        public ActionResult ceate_book2type()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ceate_book2type(BookType book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<BookType>("Values/Postceate_book2type", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }
        public ActionResult additions_2()
        {

            return View();
        }
        [HttpPost]
        public ActionResult additions_2(Addition addi)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Addition>("Values/Postadditions_2", addi);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }
        public ActionResult coffe_2()
        {

            return View();
        }
        [HttpPost]
        public ActionResult coffe_2(Coffee co)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Coffee>("Values/Postcoffe_2", co);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }
        public ActionResult wi_fi_2()
        {

            return View();
        }
        [HttpPost]
        public ActionResult wi_fi_2(Wifi_Infos wf)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Wifi_Infos>("Values/Postwi_fi_2", wf);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }
        public ActionResult Sweet1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Sweet1(Sweet wf)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Sweet>("Values/PostPostSweet", wf);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)//result == "true"
                {

                    return RedirectToAction("Admin");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
        }

        //============================== Delete =====================
        //[HttpPost]
        //public ActionResult delete_Addition(Addition co, int Serv_Id1)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44346/api/");

        //        //HTTP POST
        //        var postTask = client.SendAsync<Addition>($"Values/PutCoffee/{Serv_Id1}", co);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)//result == "true"
        //        {

        //            return RedirectToAction("Index");
        //        }
        //    } }
        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
        //    public static async Task<HttpResponseMessage> DeleteAsJsonAsync<TValue>(this HttpClient httpClient, string requestUri, TValue value)
        //    {
        //        HttpRequestMessage request = new HttpRequestMessage
        //        {
        //            Content = JsonContent.Create(value),
        //            Method = HttpMethod.Delete,
        //            RequestUri = new Uri(requestUri, UriKind.Relative)
        //        };
        //        return await httpClient.SendAsync(request);
        //    }
        //    return View();
        //}
        public ActionResult delete_book()
        {
            return View();
        }
        public ActionResult delete_book_type()
        {
            return View();
        }
        public ActionResult delete_coffe()
        {
            return View();
        }
        public ActionResult delete_WiFi()
        {
            return View();
        }


        //List<SelectListItem> items2 = new List<SelectListItem>();
        //public async Task<ActionResult> Add_Coffee()
        //{
        //    if (connect == "true")
        //    {
        //        List<Coffee> EmpInfo = new List<Coffee>();
        //        using (var client = new HttpClient())
        //        {
        //            //Passing service base url
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //            HttpResponseMessage Res = await client.GetAsync("api/GetCoffee");

        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api
        //                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

        //                //Deserializing the response recieved from web api and storing into the Employee list
        //                EmpInfo = JsonConvert.DeserializeObject<List<Coffee>>(EmpResponse);
        //            }
        //            //returning the employee list to view
        //        }
        //        foreach (var item in EmpInfo)
        //        {
        //            items2.Add(new SelectListItem { Text = item.CoffeeName, Value = item.Coffee_ID.ToString() });
        //        }
        //        ViewBag.Coffee_ID = items2;

        //        //======================== Additions =======================================
        //        List<Addition> EmpInfo2 = new List<Addition>();
        //        using (var client = new HttpClient())
        //        {
        //            //Passing service base url
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //            HttpResponseMessage Res = await client.GetAsync("api/GetAdditions");

        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api
        //                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

        //                //Deserializing the response recieved from web api and storing into the Employee list
        //                EmpInfo2 = JsonConvert.DeserializeObject<List<Addition>>(EmpResponse);
        //            }
        //            //returning the employee list to view
        //        }
        //        foreach (var item in EmpInfo2)
        //        {
        //            items.Add(new SelectListItem { Text = item.AddType, Value = item.Add_ID.ToString() });
        //        }
        //        ViewBag.Addit_ID = items;

        //        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("AdminLogin");
        //    }
        //}
        //[HttpPost]
        //public async Task<ActionResult> Add_Coffee(int? Addit_Id1, int? Serv_Id1)
        //{
        //    Coffee co1 = new Coffee();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44346/api/");

        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync($"Values/PostAdd_Coffee/{Serv_Id1}/{Addit_Id1}", co1);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)//result == "true"
        //        {
        //            allofdata.Clear();
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    return RedirectToAction("Add_Coffee");



        //}
        //}
    }
}