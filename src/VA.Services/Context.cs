using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public class Properties
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                return (_cache[key]);
            }
            set
            {
                _cache.Add(key, value);
            }
        }
    }

    public class Context
    {
        public Context()
        {
            Properties = new Properties();
        }

        public Properties Properties { get; set; }
    }
}
