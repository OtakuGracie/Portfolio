using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public byte[] getMoveData(int index)
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

        public void storeOldValues(byte[] oldValues)
        {
            model.storeOldValues(oldValues);
        }

        public byte getOldValue(int index)
        {
            return model.getOldValues(index);
        }

        public void setPreviousMoveIndex(int index)
        {
            model.setPreviousMoveIndex(index);
        }

        public int getPreviousMoveIndex()
        {
            return model.getPreviousMoveIndex();
        }

        public void updateMoveData(byte[] moveData, int moveIndex)
        {
            model.updateMoveData(moveData, moveIndex);
        }

        public void addNewType(string typeName)
        {
            model.addNewType(typeName);
        }

        public void saveToFile(string fileName)
        {
            model.saveToFile(fileName);
        }

        /*public bool requestClose()
        {

        }
        */
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
