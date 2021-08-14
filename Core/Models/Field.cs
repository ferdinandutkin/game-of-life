 

namespace Core.Models
{
    class Field : IField
    {

        public ITile[,] Table { get; private set; }

        public Field(ITile[,] table)
        {
            Table = table;



        }
    }
}