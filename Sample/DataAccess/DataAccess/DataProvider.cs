using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace DataAccess
{
    public abstract class DataProvider
    {
        public abstract int PostAdd(Post post);
        
    }
}
