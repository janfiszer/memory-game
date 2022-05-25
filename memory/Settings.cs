using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory
{
    public enum Level
    {
        EASY = 3,
        MEDIUM = 4,
        HARD = 5
    }
    public class Settings
    {
        public Level level { get; set; }
        public string Nick { get; set;}
        public int Unfolded_time { get; set; }
        public int Start_time { get; set; }
    }
}
