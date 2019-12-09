using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Models
{
    public partial class banji
    {
        public string TeacherName
        {
            get
            {
                if (!Teacherid.HasValue)
                {
                    return "";
                }

                ClassEntities db = new ClassEntities();
                var teacher = db.teacher.Where(t => t.Id == Teacherid.Value).FirstOrDefault();
                if (teacher == null)
                {
                    return "";
                }
                return teacher.Name;
            }

        }

    }
}