using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Models
{
    public partial class kechenganpai
    {
        public string SubjectName
        {
            get
            {
                if (SubjectId==0)
                {
                    return "";
                }

                ClassEntities db = new ClassEntities();
                var subject = db.subject.Where(s => s.Id == SubjectId).FirstOrDefault();
                if (subject == null)
                {
                    return "";
                }
                return subject.SubjectName;
            }

        }

    }
}