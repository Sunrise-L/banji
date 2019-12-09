using banjiguanli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Migrations.Seeds
{
    public class ActionLinksCreator
    {
        private readonly banjiguanli.Models.ClassEntities _context;
        public ActionLinksCreator(banjiguanli.Models.ClassEntities context)
        {
            _context = context;
        }

        public  void Seed()
        {
            var initialActionLinks = new List<ActionLinks>
            {
                new ActionLinks
                {
                    Name = "主页",
                    Controller ="Home",
                    Action = "Index"
                }
            };
            foreach (var action in initialActionLinks)
            {
                if (_context.ActionLinks.Any(r => r.Name == action.Name))
                {
                    continue;
                }
                _context.ActionLinks.Add(action);
            }
            _context.SaveChanges();
        }
    }
}