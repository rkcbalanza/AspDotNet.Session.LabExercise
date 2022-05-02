using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyUniverseData.Data;
using ToyUniverseData.Models;

namespace ToyUniverseData.Repositories
{
    public interface IToyRepository : IBaseRepository<Toy>
    {
    }
    public class ToyRepository : GenericRepository<Toy>, IToyRepository
    {
        public ToyRepository(ToyUniverseContext context) : base(context)
        {
        }
    }
}
