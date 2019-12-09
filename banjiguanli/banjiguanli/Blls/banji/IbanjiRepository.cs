using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banjiguanli.Blls.banji
{
    public interface IbanjiRepository
    {
        List<kechenganpaiDetail> GetBanjiSubject(int id);
    }
}
