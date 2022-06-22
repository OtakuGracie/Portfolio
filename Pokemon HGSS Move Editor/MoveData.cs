using System.Collections.Generic;


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
        private bool unsavedChanges = false;
        public bool UnsavedChanges { get => unsavedChanges; }

        public bool updateMoveData(int[] moveData, bool[] flags, int moveIndex)
        {
            byte[] byteMoveData = convertMoveDataToBytes(moveData, flags);

            //check if the passed move data has changed from what was previously stored
            for (int i = 0; i < Constants.MOVENUMVALUES; i++)
            {
                if (byteMoveData[i] != oldValues[i])
                {
                    this.moveData[moveIndex] = byteMoveData;
                    unsavedChanges = true;
                    return true;
                }
            }

            return false;
        }
        

        public int getNumMoves()
        {
            return moveList.Count;
        }

        public (int[], bool[]) getMoveData(int moveIndex)
        {
            int[] moveData = new int[Constants.NUMMOVEDATABYTES];
            bool[] flags = new bool[Constants.NUMFLAGS];
            int flagsIntVal = this.moveData[moveIndex][Constants.FLAGSINDEX];

            if (this.moveData != null)
            {
                if (this.moveData[moveIndex][Constants.EFFECTEXTINDEX] == 1)
                {
                    moveData[Constants.EFFECTINDEX] = this.moveData[moveIndex][Constants.EFFECTINDEX] + 256;
                }
                else
                {
                    moveData[Constants.EFFECTINDEX] = this.moveData[moveIndex][Constants.EFFECTINDEX];
                }

                moveData[Constants.CATEGORYINDEX] = this.moveData[moveIndex][Constants.CATEGORYINDEX];
                moveData[Constants.POWERINDEX] = this.moveData[moveIndex][Constants.POWERINDEX];
                moveData[Constants.TYPEINDEX] = this.moveData[moveIndex][Constants.TYPEINDEX];
                moveData[Constants.ACCURACYINDEX] = this.moveData[moveIndex][Constants.ACCURACYINDEX];
                moveData[Constants.PPINDEX] = this.moveData[moveIndex][Constants.PPINDEX];
                moveData[Constants.EFFECTCHANCEINDEX] = this.moveData[moveIndex][Constants.EFFECTCHANCEINDEX];

                if (this.moveData[moveIndex][Constants.TARGETEXTINDEX] == 1)
                {
                    moveData[Constants.TARGETINDEX] = (int)Target.ALLY;
                }
                else if (this.moveData[moveIndex][Constants.TARGETEXTINDEX] == 2)
                {
                    moveData[Constants.TARGETINDEX] = (int)Target.SELF_OR_ALLY;
                }
                else if (this.moveData[moveIndex][Constants.TARGETEXTINDEX] == 4)
                {
                    moveData[Constants.TARGETINDEX] = (int)Target.ANY_FOE;
                }
                else
                {
                    moveData[Constants.TARGETINDEX] = this.moveData[moveIndex][Constants.TARGETINDEX];
                }

                moveData[Constants.PRIORITYINDEX] = (sbyte)this.moveData[moveIndex][Constants.PRIORITYINDEX];
                moveData[Constants.CONTESTEFFECTINDEX] = this.moveData[moveIndex][Constants.CONTESTEFFECTINDEX];
                moveData[Constants.CONTESTCONDITIONINDEX] = this.moveData[moveIndex][Constants.CONTESTCONDITIONINDEX];

                //indirectly checks the bit values of the flags byte to determine what individual flags are set
                for (int i = Constants.NUMFLAGS - 1, bitFlagVal = 128; i >= 0; i--, bitFlagVal /= 2)
                {
                    if (flagsIntVal >= bitFlagVal)
                    {
                        flags[i] = true;
                        flagsIntVal -= bitFlagVal;
                    }
                    else
                    {
                        flags[i] = false;
                    }
                }
                
                return (moveData, flags);
            }
            else
            {
                return (null, null);
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

        public bool loadMoveData(string filename)
        {
            List<byte[]> fileData;

            fileData = readBinFile(filename);

            if (fileData == null)
            {
                return false;
            }

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

            return true;
        }

        public void storeOldValues(int[] oldValues, bool[] flags)
        {
            byte[] byteOldValues = convertMoveDataToBytes(oldValues, flags);
            this.oldValues = byteOldValues;
        }

        public (int[], bool[]) getOldValues()
        {
            int[] oldValues = new int[Constants.NUMMOVEDATABYTES];
            bool[] flags = new bool[Constants.NUMFLAGS];
            int flagsIntVal = this.oldValues[Constants.FLAGSINDEX];

            if (this.oldValues[Constants.EFFECTEXTINDEX] == 1)
            {
                oldValues[Constants.EFFECTINDEX] = this.oldValues[Constants.EFFECTINDEX] + 256;
            }
            else
            {
                oldValues[Constants.EFFECTINDEX] = this.oldValues[Constants.EFFECTINDEX];
            }

            oldValues[Constants.CATEGORYINDEX] = this.oldValues[Constants.CATEGORYINDEX];
            oldValues[Constants.POWERINDEX] = this.oldValues[Constants.POWERINDEX];
            oldValues[Constants.TYPEINDEX] = this.oldValues[Constants.TYPEINDEX];
            oldValues[Constants.ACCURACYINDEX] = this.oldValues[Constants.ACCURACYINDEX];
            oldValues[Constants.PPINDEX] = this.oldValues[Constants.PPINDEX];
            oldValues[Constants.EFFECTCHANCEINDEX] = this.oldValues[Constants.EFFECTCHANCEINDEX];

            if (this.oldValues[Constants.TARGETEXTINDEX] == 1)
            {
                oldValues[Constants.TARGETINDEX] = (int)Target.ALLY;
            }
            else if (this.oldValues[Constants.TARGETEXTINDEX] == 2)
            {
                oldValues[Constants.TARGETINDEX] = (int)Target.SELF_OR_ALLY;
            }
            else if (this.oldValues[Constants.TARGETEXTINDEX] == 4)
            {
                oldValues[Constants.TARGETINDEX] = (int)Target.ANY_FOE;
            }
            else
            {
                oldValues[Constants.TARGETINDEX] = this.oldValues[Constants.TARGETINDEX];
            }

            oldValues[Constants.PRIORITYINDEX] = (sbyte)this.oldValues[Constants.PRIORITYINDEX];
            oldValues[Constants.CONTESTEFFECTINDEX] = this.oldValues[Constants.CONTESTEFFECTINDEX];
            oldValues[Constants.CONTESTCONDITIONINDEX] = this.oldValues[Constants.CONTESTCONDITIONINDEX];

            //indirectly checks the bit values of the flags byte to determine what individual flags are set
            for (int i = Constants.NUMFLAGS - 1, bitFlagVal = 128; i >= 0; i--, bitFlagVal /= 2)
            {
                if (flagsIntVal >= bitFlagVal)
                {
                    flags[i] = true;
                    flagsIntVal -= bitFlagVal;
                }
                else
                {
                    flags[i] = false;
                }
            }

            return (oldValues, flags);
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

        public void addNewMove(string moveName)
        {
            moveList.Add(moveName);
            appendListFile(Constants.MOVELISTFILENAME, moveName);
            moveData.Add(new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            unsavedChanges = true;
        }

        //takes passed int array and bool array of move data and converts them to a byte array to be stored
        private byte[] convertMoveDataToBytes(int[] moveData, bool[] flags)
        {
            int flagsVal = 0;

            //calculates the value of the flag byte based on boolean flags
            for (int i = Constants.NUMFLAGS - 1, bitFlagVal = 128; i >= 0; i--, bitFlagVal /= 2)
            {
                if (flags[i])
                {
                    flagsVal += bitFlagVal;
                }
            }
            moveData[Constants.FLAGSINDEX] = flagsVal;

            //seperates the effect value across 2 bytes like it is stored in the games if the value is greater than 255
            if (moveData[Constants.EFFECTINDEX] > byte.MaxValue)
            {
                moveData[Constants.EFFECTINDEX] -= byte.MaxValue;
                moveData[Constants.EFFECTEXTINDEX] = 1;
            }

            //same as above but for target value
            if (moveData[Constants.TARGETINDEX] == (int)Target.ALLY)
            {
                moveData[Constants.TARGETINDEX] -= (int)Target.ALLY;
                moveData[Constants.TARGETEXTINDEX] = 1;
            }
            if (moveData[Constants.TARGETINDEX] == (int)Target.SELF_OR_ALLY)
            {
                moveData[Constants.TARGETINDEX] -= (int)Target.SELF_OR_ALLY;
                moveData[Constants.TARGETEXTINDEX] = 2;
            }
            if (moveData[Constants.TARGETINDEX] == (int)Target.ANY_FOE)
            {
                moveData[Constants.TARGETINDEX] -= (int)Target.ANY_FOE;
                moveData[Constants.TARGETEXTINDEX] = 4;
            }

            return new byte[]  {
                (byte)moveData[Constants.EFFECTINDEX], (byte)moveData[Constants.EFFECTEXTINDEX], (byte)moveData[Constants.CATEGORYINDEX], (byte)moveData[Constants.POWERINDEX],
                (byte)moveData[Constants.TYPEINDEX], (byte)moveData[Constants.ACCURACYINDEX], (byte)moveData[Constants.PPINDEX],
                (byte)moveData[Constants.EFFECTCHANCEINDEX], (byte)moveData[Constants.TARGETINDEX], (byte)moveData[Constants.TARGETEXTINDEX], (byte)moveData[Constants.PRIORITYINDEX],
                (byte)moveData[Constants.FLAGSINDEX], (byte)moveData[Constants.CONTESTEFFECTINDEX], (byte)moveData[Constants.CONTESTCONDITIONINDEX], 0, 0 };
        }
    }
}
