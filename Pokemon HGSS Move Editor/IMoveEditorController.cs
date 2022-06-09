

using System.Collections.Generic;

namespace PokemonHGSSMoveEditor
{
    public interface IMoveEditorController
    {
        //void addNewMove(byte[] moveData);
        List<string> getMoveList();
        List<string> getTypeList();
        void loadMoveData(string fileName);
        void storeOldValues(byte[] oldValues);
        byte getOldValue(int index);
        void setPreviousMoveIndex(int index);
        int getPreviousMoveIndex();
        void updateMoveData(byte[] moveData, int moveIndex);
        void addNewType(string typeName);
        void saveToFile(string fileName);

        //bool requestClose();
        void setModel(IMoveEditorModel model);
        void setView(IMoveEditorView view);
        byte[] getMoveData(int index);
    }
}
