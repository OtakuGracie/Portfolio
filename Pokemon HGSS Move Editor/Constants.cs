using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonHGSSMoveEditor
{
    public static class Constants
    {
        public const string MOVELISTFILENAME = "moves.txt";
        public const string TYPELISTFILENAME = "types.txt";

        public const int HGSSMOVEDATAOFFSET = 33153788; //01F9E2FC in hex
        public const int DPPLMOVEDATAOFFSET = 30861564; //01D6E8FC in hex
        public const int HGSSMOVEFILEOFFSET = 33149952; //01F9D400 in hex
        public const int DPPLMOVEFILEOFFSET = 30857728; //01D6DA00 in hex


        public const int HEADERSIZE = 10;
        public const int NUMMOVEDATABYTES = 16;

        public const int MOVENUMVALUES = 14;

        public const int DEFAULTNUMMOVES = 470;
        public const int DEFAULTNUMTYPES = 18;

        public const int MAXPERCENTAGE = 100;
        public const int MINFLAGVALUE = 0;
        public const int MAXPRIORITY = 15;
        public const int NUMFLAGS = 8;


        public const int EFFECTINDEX = 0;
        public const int EFFECTEXTINDEX = 1;
        public const int CATEGORYINDEX = 2;
        public const int POWERINDEX = 3;
        public const int TYPEINDEX = 4;
        public const int ACCURACYINDEX = 5;
        public const int PPINDEX = 6;
        public const int EFFECTCHANCEINDEX = 7;
        public const int TARGETINDEX = 8;
        public const int TARGETEXTINDEX = 9;
        public const int PRIORITYINDEX = 10;
        public const int FLAGSINDEX = 11;
        public const int CONTESTEFFECTINDEX = 12;
        public const int CONTESTCONDITIONINDEX = 13;

        public const int CONTACTFLAGINDEX = 0;
        public const int PROTECTFLAGINDEX = 1;
        public const int MAGICCOATFLAGINDEX = 2;
        public const int SNATCHFLAGINDEX = 3;
        public const int MIRRORMOVEFLAGINDEX = 4;
        public const int KINGSROCKFLAGINDEX = 5;
        public const int UNK1FLAGINDEX = 6;
        public const int UNK2FLAGINDEX = 7;
    }
}
