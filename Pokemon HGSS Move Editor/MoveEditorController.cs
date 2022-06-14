
using System.Collections.Generic;


namespace PokemonHGSSMoveEditor
{
    public class MoveEditorController : IMoveEditorController
    {
        IMoveEditorView view;
        IMoveEditorModel model;
        private static MoveEditorController instance = null;

        MoveEditorController()
        {

        }

        public static MoveEditorController getInstance()
        {
            if (instance == null)
            {
                instance = new MoveEditorController();
            }

            return instance;
        }

        public (int[], bool[]) getMoveData(int index)
        {
            return model.getMoveData(index);
        }

        public List<string> getMoveList()
        {
            return model.getMoveList();
        }

        public List<string> getTypeList()
        {
            return model.getTypeList();
        }

        public void loadMoveData(string filename)
        {
            model.loadMoveData(filename);
        }

        public void storeOldValues(int[] oldValues, bool[] flags)
        {
            model.storeOldValues(oldValues, flags);
        }

        public (int[], bool[]) getOldValues()
        {
            return model.getOldValues();
        }

        public void setPreviousMoveIndex(int index)
        {
            model.setPreviousMoveIndex(index);
        }

        public int getPreviousMoveIndex()
        {
            return model.getPreviousMoveIndex();
        }

        public bool updateMoveData(int[] moveData, bool[] flags, int moveIndex)
        {
            return model.updateMoveData(moveData, flags, moveIndex);
        }

        public void addNewType(string typeName)
        {
            model.addNewType(typeName);
        }

        public void addNewMove(string moveName)
        {
            model.addNewMove(moveName);
        }

        public void saveToFile(string fileName)
        {
            model.saveToFile(fileName);
        }

        public bool getIsUnsavedChanges()
        {
            return model.UnsavedChanges;
        }

        public void setView(IMoveEditorView view)
        {
            this.view = view;
        }

        public void setModel(IMoveEditorModel model)
        {
            this.model = model;
        }
    }
}
