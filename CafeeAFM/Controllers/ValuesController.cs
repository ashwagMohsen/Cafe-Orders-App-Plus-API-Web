using CafeeAFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Http.Cors;
using System.Data.Entity;
namespace CafeeAFM.Controllers
{
    // [EnableCors(origins: "http://localhost:57992", headers: "*", methods: "*")]

    public class ValuesController : ApiController
    {

        // GET api/values
        private Model1 db = new Model1();
        //Model1 m = new Model1();
        // GET api/values
        //=========================== GET =================================
        //[Route("api/GetAdmin")]
        //public List<Admin> GetAdmin()
        //{
        //    List<Admin> Coffees = db.Admins.ToList();

        //    if (Coffees == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {

        //        return Coffees;
        //    }
        //}
        [Route("api/GetCoffee")]
        public List<Coffee> GetCoffee()
        {
            List<Coffee> Coffees = db.Coffees.ToList();

            if (Coffees.Count == 0)
            {
                return null;
            }
            else
            {

                return Coffees;
            }
        }
        [Route("api/GetOrders")]
        public List<Order> GetOrders()
        {
            List<Order> orders = db.Orders.ToList();
            //var Coffee1 = db.Coffees.Where(a=>a.Coffee_ID== orders.c);
            if (orders.Count == 0)
            {
                return null;
            }
            else
            {
              
                return orders;
            }
        }
        public int GetOrderId()
        {
            List<Order> Coffees = db.Orders.ToList();
       
            if (Coffees.Count== 0)
            {
                return 0;
            }
            else
            {
                var lastId = Coffees[Coffees.Count - 1].OrderID;
                return lastId;
            }
        }
        public int GetServiceId()
        {
            List<Service> Coffees = db.Services.ToList();

            if (Coffees.Count == 0)
            {
                return 0;
            }
            else
            {
                var lastId = Coffees[Coffees.Count - 1].ServiceID;
                return lastId;
            }
        }
        [Route("api/GetallofdataIds/{id?}/{id2?}/{id3?}/{id4?}")]
        public ArrayList GetallofdataIds([FromUri] string id, [FromUri] string id2,[FromUri] string id3, [FromUri] string id4)
        {
            ArrayList allofdataIds = new ArrayList();
            allofdataIds.Clear();
            if (id == "null")
            {
                allofdataIds.Add(null);
            }
            else { int Coffees = db.Book_Infos.Where(a => a.Bookname == id).ToList()[0].Book_ID; allofdataIds.Add(Coffees); }
            if (id2 == "null")
            {
                allofdataIds.Add(null);
            }
            else
            {
                 int wifi_Infos = db.Wifi_Infos.Where(a => a.Wifi_Period == id2).ToList()[0].Wifi_ID;
                allofdataIds.Add(wifi_Infos);
            }
            if (id3 == "null")
            {
                allofdataIds.Add(null);
            }
            else
            {
               int sweets = db.Sweets.Where(a => a.SweetName == id3).ToList()[0].SweetID;
                allofdataIds.Add(sweets);
            }
            if (id4 == "null")
            {
                allofdataIds.Add(null);
            }
            else
            {
                int coffees = db.Coffees.Where(a => a.CoffeeName == id4).ToList()[0].Coffee_ID;
                allofdataIds.Add(coffees);
            }
            if (id == "null" || id2 =="null")
            {
                allofdataIds.Add(null);
            }
            else
            {
                int newlastid = GetServiceId()/*+1*/;
                allofdataIds.Add(newlastid);
            }


            if (allofdataIds.Count == 0)
            {
                return null;
            }
            else
            {

                return allofdataIds;
            }
        }

        [Route("api/GetAdditCoffee")]
        public List<add_coffes> GetAdditCoffee()
        {
            List<add_coffes> add_coffess = db.add_coffes.ToList();

            if (add_coffess.Count == 0)
            {
                return null;
            }
            else
            {

                return add_coffess;
            }
        }
        [Route("api/GetSweets")]
        public List<Sweet> GetSweets()
        {
            List<Sweet> sweets = db.Sweets.ToList();

            if (sweets.Count == 0)
            {
                return null;
            }
            else
            {

                return sweets;
            }
        }
        [Route("api/GetAdditSweets")]
        public List<add_sweets> GetAdditSweets()
        {
            List<add_sweets> add_sweetss = db.add_sweets.ToList();
            //allOfData.Add(Coffees);
            //allOfData.Add(services);
            //allOfData.Add(sweets);

            if (add_sweetss.Count == 0)
            {
                return null;
            }
            else
            {

                return add_sweetss;
            }
        }
        [Route("api/GetService")]
        public List<BookType> GetService()
        {
            List<BookType> BookTypes = db.BookTypes.ToList();

            //foreach (var i in add_coffess)
            //{
            //}
            //IQueryable<Service> services = db.Services;
            if (BookTypes.Count == 0)
            {
                return null;
            }
            else
            {

                return BookTypes;
            }
        }
        [Route("api/GetServices")]
        public List<Service> GetServices()
        {
            List<Service> Services = db.Services.ToList();

            //foreach (var i in add_coffess)
            //{
            //}
            //IQueryable<Service> services = db.Services;
            if (Services.Count == 0)
            {
                return null;
            }
            else
            {

                return Services;
            }
        }
        [Route("api/GetBooks")]
        public List<Book_Infos> GetBooks()
        {
            List<Book_Infos> Book_Infoss = db.Book_Infos.ToList();
            if (Book_Infoss.Count == 0)
            {
                return null;
            }
            else
            {

                return Book_Infoss;
            }
        }
        [Route("api/GetWiFi")]
        public List<Wifi_Infos> GetWiFi()
        {
            List<Wifi_Infos> Wifi_Infoss = db.Wifi_Infos.ToList();
            if (Wifi_Infoss.Count == 0)
            {
                return null;
            }
            else
            {

                return Wifi_Infoss;
            }
        }
        [Route("api/GetAdditions")]
        public List<Addition> GetAdditions()
        {
            List<Addition> Additions = db.Additions.ToList();

            if (Additions.Count == 0)
            {
                return null;
            }
            else
            {

                return Additions;
            }
        }
        // GET api/values/5
       
        //=========================== POST =================================
        // POST api/values
        //public void Post([FromBody] string value)
        //{

        //}
        //[HttpPost]
        [Route("api/Values/PostLogin")]
        //[AcceptVerbs("POST")]
        public IHttpActionResult PostLogin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var list1 = db.Admins.ToList();

                    foreach (var i in list1)
                    {
                        if (i.AdminName == admin.AdminName && i.Password == admin.Password)
                        {
                            return  Ok(); ;
                        }
                        else { return  BadRequest("Not a valid model");  }
                    }
                }
                catch { }
            }
            return  Ok(); ;
        }
        [Route("api/Values/PostOrder")]
        public HttpResponseMessage PostOrder( Order orderdata)
        {
           // int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                //Order em = new Order();
                //em.OrderID = OrderID;em.ServiceID = ServiceID;em.Coffee_ID = Coffee_ID;em.SweetID = SweetID;em.TableNumber = TableNumber;em.Quantity = Quantity;em.Total_Price = Total_Price;
                int newlastid= GetOrderId();
                orderdata.OrderID = newlastid + 1;
               
                db.Orders.Add(orderdata);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, orderdata);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postservice")]
        public HttpResponseMessage Postservice(Service service)
        {
            try
            {
            
                db.Services.Add(service);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, service);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postceate_book2")]
        public HttpResponseMessage Postceate_book2(Book_Infos book)
        {
            //int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                 List<Book_Infos> Coffees = db.Book_Infos.ToList();

                if (Coffees == null)
                {
                    book.Book_ID = 1;
                }
                else
                {
                    book.Book_ID = (Coffees[Coffees.Count - 1].Book_ID) + 1;
                }
                db.Book_Infos.Add(book);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, book);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postceate_book2type")]
        public HttpResponseMessage Postceate_book2type(BookType book)
        {
            //int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                //Order em = new Order();
                //em.OrderID = OrderID;em.ServiceID = ServiceID;em.Coffee_ID = Coffee_ID;em.SweetID = SweetID;em.TableNumber = TableNumber;em.Quantity = Quantity;em.Total_Price = Total_Price;
                List<BookType> Coffees = db.BookTypes.ToList();

                if (Coffees == null)
                {
                    book.BookType_ID = 1;
                }
                else
                {
                    book.BookType_ID =( Coffees[Coffees.Count - 1].BookType_ID)+1;
                }
                db.BookTypes.Add(book);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, book);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postadditions_2")]
        public HttpResponseMessage Postadditions_2(Addition addi)
        {
            //int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                //Order em = new Order();
                //em.OrderID = OrderID;em.ServiceID = ServiceID;em.Coffee_ID = Coffee_ID;em.SweetID = SweetID;em.TableNumber = TableNumber;em.Quantity = Quantity;em.Total_Price = Total_Price;
                List<Addition> Coffees = db.Additions.ToList();

                if (Coffees == null)
                {
                    addi.Add_ID = 1;
                }
                else
                {
                    addi.Add_ID = (Coffees[Coffees.Count - 1].Add_ID) + 1;
                }
                db.Additions.Add(addi);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, addi);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postcoffe_2")]
        public HttpResponseMessage Postcoffe_2(Coffee book)
        {
            //int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                //Order em = new Order();
                //em.OrderID = OrderID;em.ServiceID = ServiceID;em.Coffee_ID = Coffee_ID;em.SweetID = SweetID;em.TableNumber = TableNumber;em.Quantity = Quantity;em.Total_Price = Total_Price;
                List<Coffee> Coffees = db.Coffees.ToList();

                if (Coffees == null)
                {
                    book.Coffee_ID = 1;
                }
                else
                {
                    book.Coffee_ID = (Coffees[Coffees.Count - 1].Coffee_ID) + 1;
                }
                db.Coffees.Add(book);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, book);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/Postwi_fi_2")]
        public HttpResponseMessage Postwi_fi_2(Wifi_Infos book)
        {
            //int OrderID,int ServiceID,int Coffee_ID,int SweetID,int TableNumber,int Quantity,decimal Total_Price
            try
            {
                //Order em = new Order();
                //em.OrderID = OrderID;em.ServiceID = ServiceID;em.Coffee_ID = Coffee_ID;em.SweetID = SweetID;em.TableNumber = TableNumber;em.Quantity = Quantity;em.Total_Price = Total_Price;
                List<Wifi_Infos> Coffees = db.Wifi_Infos.ToList();

                if (Coffees == null)
                {
                    book.Wifi_ID = 1;
                }
                else
                {
                    book.Wifi_ID = (Coffees[Coffees.Count - 1].Wifi_ID) + 1;
                }
                db.Wifi_Infos.Add(book);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, book);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/PostPostSweet")]
        public HttpResponseMessage PostSweet(Sweet book)
        {
            try
            {
                List<Sweet> Coffees = db.Sweets.ToList();

                if (Coffees == null)
                {
                    book.SweetID = 1;
                }
                else
                {
                    book.SweetID = (Coffees[Coffees.Count - 1].SweetID) + 1;
                }
                db.Sweets.Add(book);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, book);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/Values/PostAdd_Coffee")]
        [Route("api/PostAdd_Coffee/{id?}/{id2?}")]
        //public HttpResponseMessage PostAdd_Coffee([FromUri] string id, [FromUri] string id2, Coffee co1)
        //{
        //    try
        //    {
        //        int addID = db.Additions.Where(a => a.AddType == id2).ToList()[0].Add_ID;
        //        int coID = db.Coffees.Where(a => a.CoffeeName == id).ToList()[0].Coffee_ID;
        //        var newadd1 = db.Additions.ToList();
        //        add_coffes newadd2 = new add_coffes();
        //        newadd2.coofe_id = coID; newadd2.add_id = addID;
        //        // List<Sweet> sweets1 = db.Sweets.ToList();

        //        if (newadd1 == null)
        //        {
        //            newadd2.id = 1;
        //        }
        //        else
        //        {
        //            newadd2.id = (newadd1[newadd1.Count - 1].Add_ID) + 1; newadd2.id = addID;
        //        }
              
        //        db.add_coffes.Add(newadd2);
        //        db.SaveChanges();
        //        var message = Request.CreateResponse(HttpStatusCode.Created, newadd2);
        //        message.Headers.Location = new Uri(Request.RequestUri.ToString());
        //        return message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
        //=========================== PUT =================================
        // PUT api/values/5
        [Route("api/PutBook")]
        public IHttpActionResult PutBook(string selectedname, [FromBody] string Book_Name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            var BookTable = db.Book_Infos.Find(selectedname);

            BookTable.Bookname = Book_Name;

            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        [Route("api/PutBookType")]
        public IHttpActionResult PutBookType(string selectedname, [FromBody] string BookTypeName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            var BookTypeTable = db.BookTypes.Find(selectedname);

            BookTypeTable.BookTypeName = BookTypeName;

            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        [Route("api/PutSweet")]
        public IHttpActionResult PutSweet(string selectedname, [FromBody] Sweet orderdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            var SweetTable = db.Sweets.Find(selectedname);

            SweetTable.SweetName = orderdata.SweetName;
            SweetTable.SweetPrice = orderdata.SweetPrice;

            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        //[Route("api/Values/PutCoffee")]
        [HttpPut]
        public IHttpActionResult PutCoffee([FromUri]int Coffee_ID, Coffee orderdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            //var s = db.Coffees.Where(a => a.CoffeeName == Coffee_Name).ToList()[0];
          //  var CoffeeTable = db.Coffees.Find(selectedname);
            //CoffeeTable.Coffee_ID = orderdata.Coffee_ID;
            //CoffeeTable.CoffeeName = orderdata.CoffeeName;
            //CoffeeTable.CoffeePrice = orderdata.CoffeePrice;
            //CoffeeTable.CoffeeSize = orderdata.CoffeeSize;


            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        [Route("api/PutAdditions")]
        public IHttpActionResult PutAdditions(string selectedname, [FromBody] Addition orderdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            var AdditionsTable = db.Additions.Find(selectedname);

            AdditionsTable.AddType = orderdata.AddType;
            AdditionsTable.Description = orderdata.Description;

            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        [Route("api/PutWifi")]
        public IHttpActionResult PutWifi(string selectedname, [FromBody] Wifi_Infos orderdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the input is un correct");
            }
            var WifiTable = db.Wifi_Infos.Find(selectedname);

            WifiTable.Wifi_Period = orderdata.Wifi_Period;
            WifiTable.Wifi_Price = orderdata.Wifi_Price;


            //var BookTable = new Book_Infos { Bookname = Book_Name, BookType = Book_Type };
            //db.Entry(BookTable).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("done");
        }
        //=========================== DELETE =================================
        // DELETE api/values/5
        [Route("api/Delete_Coffee")]
        public string Delete_Coffee (int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            db.Coffees.Remove(coffee);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_sweeet")]
        public string Delete_sweeet(int id)
        {
            Sweet sweet = db.Sweets.Find(id);
            db.Sweets.Remove(sweet);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_Addition")]
        public string Delete_Addition(int id)
        {
            Addition Addition = db.Additions.Find(id);
            db.Additions.Remove(Addition);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_order")]
        public string Delete_order(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_Services")]
        public string Delete_Services(int id)
        {
            Service Service = db.Services.Find(id);
            db.Services.Remove(Service);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_Book")]
        public string Delete_Book(int id)
        {
            BookType BookType = db.BookTypes.Find(id);
            db.BookTypes.Remove(BookType);
            db.SaveChanges();
            return "Delete Successfully";
        }
        [Route("api/Delete_bookType")]
        public string Delete_bookType(int id)
        {
            BookType BookType = db.BookTypes.Find(id);
            db.BookTypes.Remove(BookType);
            db.SaveChanges();
            return "Delete Successfully";
        }

        //    [EnableCors(origins: "http://localhost:57992", headers: "*", methods: "*")]
      


    }
}
