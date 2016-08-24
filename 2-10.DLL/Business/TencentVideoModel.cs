using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_10.Model.Business
{
    public class TencentVideoModel
    {
        public int costtime { get; set; }
        public string errormsg { get; set; }
        public int errorno { get; set; }
        public long resptime { get; set; }
        public List<TencentVideoResultsModel> results { get; set; }
    }

    public class TencentVideoFieldsModel
    {
        public long allnumc { get; set; }
        public long allnumc_m { get; set; }
        public long c_column_id { get; set; }
        public object column { get; set; }
        public long tdnumc { get; set; }
        public long tdnumc_m { get; set; }
    }

    public class TencentVideoResultsModel
    {
        public TencentVideoFieldsModel fields { get; set; }
        public string id { get; set; }
        public long retcode { get; set; }
    }
}
