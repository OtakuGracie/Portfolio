using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonHGSSMoveEditor
{
    partial class MoveEditorModel : IMoveEditorModel
    {
        public List<byte[]> readBinFile(string fileName)
        {
            //int offset = 0;
            //int count = Constants.HEADERSIZE;
            byte[] trailingBytes = new byte[Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET];
            var header = new byte[Constants.HEADERSIZE];
            var returnVal = new List<byte[]>(getNumMoves() + 1); //+1 due to needing to return the trailing bytes in the list as the first value

            returnVal.Add(new byte[Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET]);

            for (int i = 0; i <= getNumMoves(); i++)
            {
                returnVal.Add(new byte[Constants.NUMMOVEDATABYTES]);
            }

            if (!File.Exists(fileName))
            {
                return null;
            }

            FileStream stream = new FileStream(fileName, FileMode.Open);

            try
            {
                stream.Read(header, 0, Constants.HEADERSIZE);

                switch (System.Text.Encoding.ASCII.GetString(header).Replace((char)0, ' ').Replace('?', ' ').Replace((char)1, ' ').Replace(" ", ""))
                {
                    case "POKEMONHG":
                    case "POKEMONSS":
                        stream.Position = Constants.HGSSMOVEFILEOFFSET;
                        break;
                    case "POKEMOND":
                    case "POKEMONP ":
                    case "POKEMONPL":
                        stream.Position = Constants.DPPLMOVEFILEOFFSET;
                        break;
                    case "NARC\\,": //this is first 8 bytes in ascii of the file containg move data in HGSS with all non-printable characters removed
                        stream.Position = 0;
                        break;
                    //if the file header does not match one of the above then exit method early
                    default:
                        return null;
                }

                stream.Read(trailingBytes, 0, Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET);
                returnVal[0] = trailingBytes;

                //offset = Constants.HGSSMOVEDATAOFFSET;

                for (int i = 0; i < getNumMoves(); i++)
                {
                    stream.Read(returnVal[i + 1], 0, Constants.NUMMOVEDATABYTES);
                }

                stream.Close();
            }
            catch (Exception E)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                return null;
            }

            return returnVal;
        }

        public bool writeBinFile(string fileName, byte[] trailingBytes, List<byte[]> moveData)
        {
            var stream = new FileStream(fileName, FileMode.Create);

            try
            {
                stream.Write(trailingBytes, 0, trailingBytes.Length);

                foreach (byte[] move in moveData)
                {
                    stream.Write(move, 0, Constants.NUMMOVEDATABYTES);
                }
                
                stream.Close();
            }
            catch (Exception E)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                return false;
            }

            return true;
        }

        public List<string> readListFile(string fileName)
        {
            var contents = new List<string>();

            if (!File.Exists(fileName))
            {
                return null;
            }

            StreamReader reader = new StreamReader(fileName);

            try
            {
                while (!reader.EndOfStream)
                {
                    contents.Add(reader.ReadLine().Trim());
                }

                reader.Close();
            }
            catch (Exception E)
            {
                if (reader != null)
                {
                    reader.Close();
                }

                return null;
            }

            return contents;

        }

        public bool appendListFile(string fileName, string item)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            StreamWriter writer = new StreamWriter(fileName, true);

            try
            {
                writer.Write("\n" + item);
                writer.Close();
            }
            catch (Exception E)
            {
                if (writer != null)
                {
                    writer.Close();
                }

                return false;
            }

            return true;
        }

        public void saveToFile(string fileName)
        {
            writeBinFile(fileName, trailingBytes, moveData);
            unsavedChanges = false;
        }
    }
}
