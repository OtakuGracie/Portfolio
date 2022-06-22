﻿using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonHGSSMoveEditor
{
    partial class MoveEditorModel : IMoveEditorModel
    {
        //reads move data from a gen 4 pokemon rom or binary file
        public List<byte[]> readBinFile(string fileName)
        {
            
            byte[] trailingBytes = new byte[Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET];
            //var header = new byte[Constants.HEADERSIZE];
            var returnVal = new List<byte[]>(getNumMoves() + 1)
            {
                new byte[Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET]
            }; //+1 due to needing to return the trailing bytes in the list as the first value

            for (int i = 0; i <= getNumMoves(); i++)
            {
                returnVal.Add(new byte[Constants.NUMMOVEDATABYTES]);
            }

            if (!File.Exists(fileName))
            {
                return null;
            }

            FileStream stream = new FileStream(fileName, FileMode.Open);

            switch (readFileHeader(stream, false))
            {
                case "HGSS":
                    stream.Position = Constants.HGSSMOVEFILEOFFSET;
                    break;
                case "DPPL":
                    stream.Position = Constants.DPPLMOVEFILEOFFSET;
                    break;
                case "NARC":
                    stream.Position = 0;
                    break;
                case null:
                    return null;
            }

            try
            {

                stream.Read(trailingBytes, 0, Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET);
                returnVal[0] = trailingBytes;

                for (int i = 0; i < getNumMoves(); i++)
                {
                    stream.Read(returnVal[i + 1], 0, Constants.NUMMOVEDATABYTES);
                }

                stream.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                controller.showErrorMsg("Error! Access to read file is not authorized. File may have restricted access to read by the operating system. " +
                                        "Check that read permissions for the file aren't restricted or try running Gen IV Move Editor with administrator privileges.", e.ToString());
            }
            catch (IOException e)
            {
                controller.showErrorMsg("Error! A problem occured reading the selected file.", e.ToString());
            }
            catch (Exception e)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                controller.showErrorMsg(Constants.DEFAULTERRORMSG, e.ToString());
                return null;
            }

            return returnVal;
        }

        //writes move data to a binary file
        public bool writeBinFile(string fileName)
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
            catch (UnauthorizedAccessException e)
            {
                controller.showErrorMsg("Error! Access to write file is not authorized. Destination may have restricted access to write to by the operatiing system. " +
                                        "Try saving to a different location or running Gen IV Move Editor with administrator privileges." , e.ToString());
            }
            catch (IOException e)
            {
                controller.showErrorMsg("Error! A problem occured while attempting to save to binary file.", e.ToString());
            }
            catch (Exception e)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                controller.showErrorMsg(Constants.DEFAULTERRORMSG, e.ToString());
                return false;
            }

            unsavedChanges = false;
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
            catch (FileNotFoundException e)
            {
                controller.showErrorMsg("Error! The required files moves.txt and/or types.txt were not found in the same directory as the exe\n" +
                                        "Please ensure the included moves.txt and types.txt files are in the same directory as the exe", e.ToString());
            }
            catch (IOException e)
            {
                controller.showErrorMsg("Error! A problem occured reading the moves.txt or types.txt file", e.ToString());
            }
            catch (Exception e)
            {
                if (reader != null)
                {
                    reader.Close();
                }

                controller.showErrorMsg(Constants.DEFAULTERRORMSG, e.ToString());
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
            catch (FileNotFoundException e)
            {
                controller.showErrorMsg("Error! The required files moves.txt and/or types.txt were not found in the same directory as the exe\n" +
                                        "Please ensure the included moves.txt and types.txt files are in the same directory as the exe", e.ToString());
            }
            catch (IOException e)
            {
                controller.showErrorMsg("Error! A problem occured appending the moves.txt or types.txt file", e.ToString());
            }
            catch (Exception e)
            {
                if (writer != null)
                {
                    writer.Close();
                }

                controller.showErrorMsg(Constants.DEFAULTERRORMSG, e.ToString());
                return false;
            }

            return true;
        }


        //reads the first 10 bytes of the passed fileStream to check that it is a compatible rom or binary file and which grouping it is
        public string readFileHeader(FileStream stream, bool romOnly)
        {
            var header = new byte[Constants.HEADERSIZE];

            try
            {
                stream.Read(header, 0, Constants.HEADERSIZE);
            }
            catch (IOException e)
            {
                controller.showErrorMsg("Error! A problem occured reading the selected file header.", e.ToString());
            }
            catch (Exception e)
            {
                controller.showErrorMsg(Constants.DEFAULTERRORMSG, e.ToString());
            }

            switch (System.Text.Encoding.ASCII.GetString(header).Replace((char)0, ' ').Replace('?', ' ').Replace((char)1, ' ').Replace(" ", ""))
            {
                case "POKEMONHG":
                case "POKEMONSS":
                case "POKEMONSG": //header for a popular romhack based on HG
                    return "HGSS";
                case "POKEMOND":
                case "POKEMONP ":
                case "POKEMONPL":
                    return "DPPL";
                case "NARC\\,": //this is first 8 bytes in ascii of the file containg move data in HGSS with all non-printable characters removed
                    if (romOnly)
                    {
                        controller.showErrorMsg("Error! File header does not match supported rom.\nPlease try opening a different file.");
                        return null;
                    }
                    return "NARC";
                //if the file header does not match one of the above then show error and return false and null
                default:
                    controller.showErrorMsg("Error! File header does not match supported rom or binary file.\nPlease try opening a different file.");
                    return null;
            }
        }


        //writes move data directly to selected gen 4 pokemon rom file
        public bool writeToRom(string fileName)
        {
            var stream = new FileStream(fileName, FileMode.Open);

            switch(readFileHeader(stream, true))
            {
                case "HGSS":
                    stream.Position = Constants.HGSSMOVEDATAOFFSET;
                    break;
                case "DPPL":
                    stream.Position = Constants.DPPLMOVEDATAOFFSET;
                    break;
                case null:
                    return false;
            }

            try
            {
                foreach (byte[] move in moveData)
                {
                    stream.Write(move, 0, Constants.NUMMOVEDATABYTES);
                }

                stream.Close();
            }
            catch (Exception e)
            {
                if (stream != null)
                {
                    stream.Close();
                }

                controller.showErrorMsg("Error! A problem occured writing to the selected rom. Contents may have been corrupted!", e.ToString());
                return false;
            }

            unsavedChanges = false;
            return true;
        }
    }
}
