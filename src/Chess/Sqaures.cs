
using System;
using System.Collections.Generic;

namespace Chess
{
    public class Squares
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

        public const long FILE_A = 1L | (1L<<8) | (1L<<16) | (1L<<24) | (1L<<32) | (1L<<40) | (1L<<48) | (1L<<56);
        public const long FILE_B = (1L<<1) | (1L<<9) | (1L<<17) | (1L<<25) | (1L<<33) | (1L<<41) | (1L<<49) | (1L<<57);
        public const long FILE_C = (1L<<2) | (1L<<10) | (1L<<18) | (1L<<26) | (1L<<34) | (1L<<42) | (1L<<50) | (1L<<58);
        public const long FILE_D = (1L<<3) | (1L<<11) | (1L<<19) | (1L<<27) | (1L<<35) | (1L<<43) | (1L<<51) | (1L<<59);
        public const long FILE_E = (1L<<4) | (1L<<12) | (1L<<20) | (1L<<28) | (1L<<36) | (1L<<44) | (1L<<52) | (1L<<60);
        public const long FILE_F = (1L<<5) | (1L<<13) | (1L<<21) | (1L<<29) | (1L<<37) | (1L<<45) | (1L<<53) | (1L<<61);
        public const long FILE_G = (1L<<6) | (1L<<14) | (1L<<22) | (1L<<30) | (1L<<38) | (1L<<46) | (1L<<54) | (1L<<62);
        public const long FILE_H = (1L<<7) | (1L<<15) | (1L<<23) | (1L<<31) | (1L<<39) | (1L<<47) | (1L<<55) | (1L<<63);
        public static List<long> AllFiles = new List<long>() {FILE_A, FILE_B, FILE_C, FILE_D, FILE_E, FILE_F, FILE_G, FILE_H};
        public static List<string> fileNames = new List<string>() {"a", "b", "c", "d", "e", "f", "g", "h"};


        public static String[] SquareNames = {
            "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8",
            "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7",
            "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6",
            "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5",
            "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4",
            "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3",
            "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2",
            "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1",
        };
    }
}

