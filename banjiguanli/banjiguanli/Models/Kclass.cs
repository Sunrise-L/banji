using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banjiguanli.Models
{
    public partial class kechenganpai
    {
        public string BanjiName
        {
            get
            {
                if (BanjiId == 0)
                {
                    return "";
                }

                ClassEntities db = new ClassEntities();
                var Banji = db.banji.Where(b => b.id == BanjiId).FirstOrDefault();
                if (Banji == null)
                {
                    return "";
                }
                return Banji.name;
            }

        }

    }
}