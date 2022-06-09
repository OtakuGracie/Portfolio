using System;

namespace PokemonHGSSMoveEditor
{
    public enum Target
    {
        FOE = 0,
        OTHER = 1,
        SELFINFLICT = 2,
        FOES = 4,
        OTHERS = 8,
        SELF = 16,
        SELFALLY = 32,
        ALL = 64,
        FOESIDE = 128
    }

    public enum Category
    {
        PHYSICAL,
        SPECIAL,
        STATUS
    }

    public enum ContestCondition
    {
        COOL,
        BEAUTIFUL,
        CUTE,
        SMART,
        TOUGH
    }

    
}
