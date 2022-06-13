﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonHGSSMoveEditor
{
    public partial class MoveEditorModel : IMoveEditorModel
    {
        private static MoveEditorModel instance = null;
        private IMoveEditorController controller;

        private MoveEditorModel()
        {
            
        }

        public static MoveEditorModel getInstance()
        {
            if (instance == null)
            {
                instance = new MoveEditorModel();
            }

            return instance;
        }

        

        
    }
}