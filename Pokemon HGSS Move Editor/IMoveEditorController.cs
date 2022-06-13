

using System.Collections.Generic;

namespace PokemonHGSSMoveEditor
{
    public interface IMoveEditorController
    {
        
        List<string> getMoveList();
        List<string> getTypeList();
        void loadMoveData(string fileName);
        void storeOldValues(int[] oldValues, bool[] flags);
        (int[], bool[]) getOldValues();
        void setPreviousMoveIndex(int index);
        int getPreviousMoveIndex();
        bool updateMoveData(int[] moveData, bool[] flags, int moveIndex);
        void addNewType(string typeName);
        void addNewMove(string moveName);
        void saveToFile(string fileName);
        bool getIsUnsavedChanges();

        //bool requestClose();
        void setModel(IMoveEditorModel model);
        void setView(IMoveEditorView view);
        (int[], bool[]) getMoveData(int index);
    }
}
