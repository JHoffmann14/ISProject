using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotManager.Models;

namespace LotManager.Controllers
{
    public class LotController : Controller
    {
        // GET: Lot
        public ActionResult LotsDisplay()
        {
            using (LotsDBEntities db = new LotsDBEntities())
            {
               
                return View(db.Lots.OrderBy(l => l.id).ToList());
            }
        }

        //add/edit log
        [HttpPost]
        public void addLot(string LotName, int LotCapacity)
        {

   

            using (LotsDBEntities db = new LotsDBEntities())
            {
                string sql = "INSERT INTO [dbo].[Lots] (Id, Name, totalCapacity, Location) " +
                                "VALUES(" + db.Lots.Count() + 1 + ", '" + LotName + "', " + LotCapacity + ")";

               
                if (LotName != "" || LotCapacity != 0)
                {
                    string sql1 = "SELECT * FROM Lots ORDER BY ID DESC LIMIT 1";

                    
                    if (db.Lots.Count() == 0)
                    {
                        db.Lots.Add(new Lot { id = 0, name = LotName, totalCapacity = LotCapacity });
                       
                    }
                    else
                    {
                        int last = db.Lots.OrderByDescending(l => l.id).First().id;
                        db.Lots.Add(new Lot { id = last+1, name = LotName, totalCapacity = LotCapacity });

                    }
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                Response.Redirect("LotsDisplay");
            }
  
        }
        public void DeleteLot(string LotName)
        {
            using (LotsDBEntities db = new LotsDBEntities())
            {
                Lot removeLot = db.Lots.Where(l => l.name == LotName).FirstOrDefault();

                try
                {
                    db.Lots.Remove(removeLot);
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                try
                {
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                Response.Redirect("LotsDisplay");
            }
        }

        public void UpdateLot(string LotName, int LotCapacity)
        {
            using (LotsDBEntities db = new LotsDBEntities())
            {
                Lot updateLot = db.Lots.Where(l => l.name == LotName).FirstOrDefault();
                string sql = "UPDATE LOTS " +
                           "SET totalCapacity = " + LotCapacity +
                           " WHERE name = " + LotName + ";";
                try
                {
                    updateLot.totalCapacity = LotCapacity;
                    
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }

                try
                {
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            Response.Redirect("LotsDisplay");
        }
    }   
}