using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Television_Channel_Program.DTOs;
using Television_Channel_Program.EF;

namespace Television_Channel_Program.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        Television_Channel_ProgramEntities db = new Television_Channel_ProgramEntities();
        
        public static Program Convert(ProgramDTO p)
        {
            return new Program
            {
                ProgramId = p.ProgramId,
                ProgramName = p.ProgramName,
                TRPScore = p.TRPScore,
                ChannelId = p.ChannelId,
                AirTime = p.AirTime
            };
        }

        public static ProgramDTO Convert(Program p)
        {
            return new ProgramDTO
            {
                ProgramId = p.ProgramId,
                ProgramName = p.ProgramName,
                TRPScore = p.TRPScore,
                ChannelId = p.ChannelId,
                AirTime = p.AirTime
            };
        }

        public static List<ProgramDTO> Convert(List<Program> p)
        {
            var list = new List<ProgramDTO>();
            foreach (var item in p)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public ActionResult ProgramList()
        {
            var data = db.Programs.ToList();
            return View(Convert(data));
        }

        [HttpGet]

        public ActionResult CreateProgram()
        {
            return View(new Program());
        }

        [HttpPost]

        public ActionResult CreateProgram(ProgramDTO p)
        {
            
            
                db.Programs.Add(Convert(p));
                db.SaveChanges();
                return RedirectToAction("ProgramList");
           
        }
    }
}