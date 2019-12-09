using banjiguanli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banjiguanli.Blls.banji
{
    public class BanjiRepository : IbanjiRepository
    {
        protected ClassEntities db = new ClassEntities();
        public List<kechenganpaiDetail> GetBanjiSubject(int id)
        {
            var query =
                from cm in db.kechenganpai
                join c in db.banji
                    on cm.BanjiId equals c.id
                join cr in db.subject
                    on cm.SubjectId equals cr.Id
                join t in db.teacher
                    on cm.TeacherId equals t.Id
                where cm.BanjiId == id
                select new kechenganpaiDetail
                {
                    BanjiName = c.name,
                    SubjectName = cr.SubjectName,
                    TeacherName = t.Name
                };
            return query.ToList();
        }
    }
}
