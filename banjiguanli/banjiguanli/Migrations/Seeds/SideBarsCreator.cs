using banjiguanli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Migrations.Seeds
{
    public class SideBarsCreator
    {
        private readonly banjiguanli.Models.ClassEntities _context;
        public SideBarsCreator(banjiguanli.Models.ClassEntities context)
        {
            _context = context;
        }

        public void Seed()
        {
            var initialSideBars = new List<SideBars>
            {
                new SideBars
                {
                    Name = "班级管理",
                    Controller ="banji",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "教师管理",
                    Controller ="teachers",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "学生管理",
                    Controller ="Stdent",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "课程科目管理",
                    Controller ="subject",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "课程安排",
                    Controller ="kechenganpai",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "顶部导航栏管理",
                    Controller ="ActionLinks",
                    Action = "Index"
                },
                new SideBars
                {
                    Name = "左侧导航栏管理",
                    Controller ="SideBar",
                    Action = "Index"
                }
            };
            foreach (var action in initialSideBars)
            {
                if (_context.SideBars.Any(r => r.Name == action.Name))
                {
                    continue;
                }
                _context.SideBars.Add(action);
            }
            _context.SaveChanges();
        }
    }
}