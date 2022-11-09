using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3
{
    public class Memory
    {
        public List<User> Users { get; set; }
        private static readonly Memory _memory = new();
        private Memory()
        {
            Users = new();
        }
        public static Memory GetMemory()
        {
            return _memory;
        }
    }
}
