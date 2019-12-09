using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Models
{
    public partial class Stdent
    {
        public string ClassName
        {
            get
            {
                if (Classid==0)
                {
                    return "";
                }

                ClassEntities db = new ClassEntities();
                var Banji = db.banji.Where(t => t.id== Classid).FirstOrDefault();
                if (Banji == null)
                {
                    return "";
                }
                return Banji.name;
            }

        }

    }
}