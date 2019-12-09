using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Models
{
    public partial class kechenganpai
    {
        public string TeacherName
        {
            get
            {
                if (TeacherId == 0)
                {
                    return "";
                }

                ClassEntities db = new ClassEntities();
                var teacher = db.teacher.Where(t => t.Id == TeacherId).FirstOrDefault();
                if (teacher == null)
                {
                    return "";
                }
                return teacher.Name;
            }

        }

    }
}