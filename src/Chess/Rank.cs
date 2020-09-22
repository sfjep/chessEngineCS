using System.Collections.Generic;

namespace Chess
{
    public class Rank
    {
        public static long RANK_1 = (1L<<56) | (1L<<57) | (1L<<58) | (1L<<59) | (1L<<60) | (1L<<61) | (1L<<62) | (1L<<63);
        public static long RANK_2 = (1L<<48) | (1L<<49) | (1L<<50) | (1L<<51) | (1L<<52) | (1L<<53) | (1L<<54) | (1L<<55);
        public static long RANK_3 = (1L<<40) | (1L<<41) | (1L<<42) | (1L<<43) | (1L<<44) | (1L<<45) | (1L<<46) | (1L<<47);
        public static long RANK_4 = (1L<<32) | (1L<<33) | (1L<<34) | (1L<<35) | (1L<<36) | (1L<<37) | (1L<<38) | (1L<<39);
        public static long RANK_5 = (1L<<24) | (1L<<25) | (1L<<26) | (1L<<27) | (1L<<28) | (1L<<29) | (1L<<30) | (1L<<31);
        public static long RANK_6 = (1L<<16) | (1L<<17) | (1L<<18) | (1L<<19) | (1L<<20) | (1L<<21) | (1L<<22) | (1L<<23);
        public static long RANK_7 = (1L<<8) | (1L<<9) | (1L<<10) | (1L<<11) | (1L<<12) | (1L<<13) | (1L<<14) | (1L<<15);
        public static long RANK_8 = 1L | (1L<<1) | (1L<<2) | (1L<<3) | (1L<<4) | (1L<<5) | (1L<<6) | (1L<<7);
        public static List<string> rankNames = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8"};
        public static List<long> AllRanks = new List<long>() {RANK_1, RANK_2, RANK_3, RANK_4, RANK_5, RANK_6, RANK_7, RANK_8};

        public static long bbRank(long bb)
        {
            foreach(long rankNr in AllRanks)
            {
                if((bb & rankNr) != 0L) { return rankNr; }
            }
            return 0L;
        }
    }
}