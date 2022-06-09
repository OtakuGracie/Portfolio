
using System.Collections.Generic;


namespace PokemonHGSSMoveEditor
{
    public interface IMoveEditorView
    {
        void showMoveList(List<string> moveList);
        //void showMoveData(int effect, int moveClass, Category moveCategory, int power, int moveType, int accuracy, int pp, int effectChance,
        //                          Target moveTarget, int flag1, int priority, int flag2, int flag3, ContestCondition moveContest);
        bool selectFile();
        void displayError(string errorMsg);
        void close();
    }
}
