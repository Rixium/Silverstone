using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverstone.Util {

    public static class Random {

        private static System.Random random = new System.Random();

        public static int GetRandomInt(int max) {
            return random.Next(max);
        }

        public static int GetRandom(int min, int max) {
            return random.Next(min, max);
        }
    }

}
