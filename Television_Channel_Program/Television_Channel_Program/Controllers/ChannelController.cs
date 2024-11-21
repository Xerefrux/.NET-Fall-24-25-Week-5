using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Television_Channel_Program.DTOs;
using Television_Channel_Program.EF;

namespace Television_Channel_Program.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        Television_Channel_ProgramEntities db = new Television_Channel_ProgramEntities();

        public static Channel Convert(ChannelDTO c)
        {
            return new Channel
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country
            };
        }

        public static ChannelDTO Convert(Channel c)
        {
            return new ChannelDTO
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country
            };
        }

        public static List<ChannelDTO> Convert(List<Channel> c)
        {
            var list = new List<ChannelDTO>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public ActionResult ChannelList()
        {
            var data = db.Channels.ToList();
            return View(Convert(data));
        }

        [HttpGet]

        public ActionResult CreateChannel()
        {
            return View(new Channel());
        }

        [HttpPost]

        public ActionResult CreateChannel(ChannelDTO c)
        {
            if(ModelState.IsValid)
            {
                db.Channels.Add(Convert(c));
                db.SaveChanges();
                return RedirectToAction("ChannelList");
            }
            return View(c);

        }

        /*public ActionResult ChannelDetails(int id)
        {
            var data = db.Channels.Find(id);
            return View(Convert(data));
        }*/

        [HttpGet]

        public ActionResult EditChannel(int id)
        {
            var data = db.Channels.Find(id);
            return View(Convert(data));
        }

        [HttpPost]

        public ActionResult EditChannel(ChannelDTO c)
        {
            if(ModelState.IsValid)
            {
                var data = db.Channels.Find(c.ChannelId);
                //db.Entry(data).CurrentValues.SetValues(c);
                data.ChannelName = c.ChannelName;
                data.EstablishedYear = c.EstablishedYear;
                data.Country = c.Country;
                db.SaveChanges();
                return RedirectToAction("ChannelList");
            }
            return View(c);
        }

        [HttpGet]

        public ActionResult DeleteChannel(int id)
        {
            var data = db.Channels.Find(id);
            return View(Convert(data));
        }

        public ActionResult DeleteChannel(int id, string dcsn)
        {
            
            if (dcsn.Equals("Yes"))
            {
                var Check = (from p in db.Programs where p.ChannelId == id select p).ToList();
                if (Check.Count > 0)
                {
                    TempData["Message"] = "This channel has programs. You cannot delete this channel.";
                    return RedirectToAction("ChannelList");
                }
                else
                {
                    var data = db.Channels.Find(id);
                    db.Channels.Remove(data);
                    db.SaveChanges();
                }
            }   
            return RedirectToAction("ChannelList");
        }
    }
}