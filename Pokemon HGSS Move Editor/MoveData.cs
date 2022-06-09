using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonHGSSMoveEditor
{
    public partial class MoveEditorModel : IMoveEditorModel
    {
        List<string> moveList = new List<string>(Constants.DEFAULTNUMMOVES);
        List<string> typeList = new List<string>(Constants.DEFAULTNUMTYPES);
        List<byte[]> moveData = new List<byte[]>(Constants.DEFAULTNUMMOVES);
        byte[] trailingBytes = new byte[Constants.HGSSMOVEDATAOFFSET - Constants.HGSSMOVEFILEOFFSET]; //stores bytes between the start of the file containing move data and the start of move data
        byte[] oldValues = new byte[Constants.MOVENUMVALUES];
        int previousMoveIndex;
        bool unsavedChanges = false;


        public void addNewMove(byte[] moveData, string name)
        {
            if (validateMoveData(moveData))
            {
                moveList.Add(name);
                this.moveData.Add(moveData);

            }
        }
        public void updateMoveData(byte[] moveData, int moveIndex)
        {
            
            //check if the passed move data has changed from what was previously stored
            for (int i = 0; i < Constants.MOVENUMVALUES; i++)
            {
                if (moveData[i] != oldValues[i])
                {
                    this.moveData[moveIndex] = moveData;
                    unsavedChanges = true;
                    break;
                }
            }


        }
        public bool validateMoveData(byte[] moveData)
        {

            if (moveData[Constants.EFFECTINDEX] > byte.MaxValue || moveData[Constants.EFFECTINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.CLASSINDEX] > 1 || moveData[Constants.CLASSINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.POWERINDEX] > byte.MaxValue || moveData[Constants.POWERINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.TYPEINDEX] > typeList.Count - 1 )
            {
                return false;
            }
            if (moveData[Constants.ACCURACYINDEX] > Constants.MAXPERCENTAGE || moveData[Constants.ACCURACYINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.PPINDEX] > byte.MaxValue || moveData[Constants.PPINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.EFFECTCHANCEINDEX] > Constants.MAXPERCENTAGE || moveData[Constants.EFFECTCHANCEINDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.FLAG1INDEX] > byte.MaxValue || moveData[Constants.FLAG1INDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.PRIORITYINDEX] > Constants.MAXPRIORITY || moveData[Constants.PRIORITYINDEX] < -Constants.MAXPRIORITY)
            {
                return false;
            }
            if (moveData[Constants.FLAG2INDEX] > byte.MaxValue || moveData[Constants.FLAG2INDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }
            if (moveData[Constants.FLAG3INDEX] > byte.MaxValue || moveData[Constants.FLAG3INDEX] < Constants.MINFLAGVALUE)
            {
                return false;
            }

            return true;
        }

        public int getNumMoves()
        {
            return moveList.Count;
        }

        public byte[] getMoveData(int moveIndex)
        {

            if (moveData != null)
            {
                return moveData[moveIndex];
            }
            else
            {
                return null;
            }
            
        }

        public List<string> getMoveList()
        {
            if (moveList.Count == 0)
            {
                List<string> results;
                results = readListFile(Constants.MOVELISTFILENAME);

                if (results != null)
                {
                    moveList = results;
                    
                }
                else
                {
                    return null;
                }
            }

            return moveList;
        }

        public List<string> getTypeList()
        {
            List<string> results;
            results = readListFile(Constants.TYPELISTFILENAME);

            if (typeList.Count == 0)
            {
                if (results != null)
                {
                    typeList = results;
                }
                else
                {
                    return null;
                }
            }
            
            return typeList;
        }

        public void loadMoveData(string filename)
        {
            List<byte[]> fileData;

            fileData = readBinFile(filename);

            trailingBytes = fileData[0];

            if (moveData.Count > 0)
            {
                moveData.Clear();
            }

            //subtract one from fileData count to account for the first byte array containing the trailing bytes
            for (int i = 1; i < fileData.Count - 1; i++)
            {
                moveData.Add(fileData[i]);
            }

            unsavedChanges = false;
        }

        public void storeOldValues(byte[] oldValues)
        {
            this.oldValues = oldValues;
        }

        public byte getOldValues(int index)
        {
            return oldValues[index];
        }

        public void setPreviousMoveIndex(int index)
        {
            previousMoveIndex = index;
        }

        public int getPreviousMoveIndex()
        {
            return previousMoveIndex;
        }

        public void addNewType(string typeName)
        {
            typeList.Add(typeName);
            appendListFile(Constants.TYPELISTFILENAME, typeName);
        }
    }
}
