using System;
using System.Linq;
using System.Threading.Tasks;
using Blockchain;
using Microsoft.Extensions.Logging;

namespace BlockChain.Infraestructure
{
    public class DbInitializer
    {
        public static async Task Initialize(Db db, ILogger<Startup> logger)
        {           
            await db.SaveChangesAsync();
        }
    }
}
