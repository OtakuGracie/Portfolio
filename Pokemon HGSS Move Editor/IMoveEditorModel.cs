

using System.Collections.Generic;

namespace PokemonHGSSMoveEditor
{
    public interface IMoveEditorModel
    {
        
        bool writeBinFile(string fileName, byte[] trailingBytes, List<byte[]> moveData);
        void loadMoveData(string filename);
        void addNewMove(byte[] moveData, string name);
        void updateMoveData(byte[] moveData, int moveIndex);
        bool validateMoveData(byte[] moveData);
        void storeOldValues(byte[] oldValues);
        byte getOldValues(int index);
        void setPreviousMoveIndex(int index);
        int getPreviousMoveIndex();
        //int getNumMoves();
        byte[] getMoveData(int index);
        void addNewType(string typeName);
        void saveToFile(string fileName);
        List<string> getMoveList();
        List<string> getTypeList();
    }
}
