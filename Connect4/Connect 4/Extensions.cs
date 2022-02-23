using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    public static class Extensions
    {
        public static Coin Opposite(this Coin coin)
        {
            return coin == Coin.Green ? Coin.Red : Coin.Green;
        }
    }
}
