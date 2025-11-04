using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Services
{
    public interface INlpClient
    {
        Task<dynamic> ParseQuery(string query);
    }
}
