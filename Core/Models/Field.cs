 

namespace Core.Models
{
    public class Field : IField
    {

        public ITile[,] Table { get; private set; }

        public Field(ITile[,] table)
        {
            Table = table;



        }
    }
}