using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public static class GameExtension
    {


        public static void Clear(this IField field)
        {
            var (width, height) = GetBounds(field);

        

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    field.Table[i, j].IsAlive = false;


                }
            }
        }

        static (int width, int height) GetBounds(IGame game)
        {
            return GetBounds(game.Field);

        }

        static (int width, int height) GetBounds(IField field)
        {
            int width = field.Table.GetLength(0);
            int height = field.Table.GetLength(1);

            return (width, height);
        }




        private static int GetAliveNeighboursCount( IGame game, int x, int y)
        {

            var (rows, columns) = GetBounds(game);



            int xL = (x > 0) ? x - 1 : columns - 1;
            int xR = (x < columns - 1) ? x + 1 : 0;

          
            int yT = (y > 0) ? y - 1 : rows - 1;
            int yB = (y < rows - 1) ? y + 1 : 0;

            var cells = game.Field.Table;
            

            int aliveNeighbours = 0;
            aliveNeighbours += cells[xL, yT].IsAlive? 1 : 0;
            aliveNeighbours += cells[x, yT].IsAlive ? 1 : 0;
            aliveNeighbours += cells[xR, yT].IsAlive ? 1 : 0;
            aliveNeighbours += cells[xL, y].IsAlive? 1 : 0;
            aliveNeighbours += cells[xR, y].IsAlive ? 1 : 0;
            aliveNeighbours += cells[xL, yB].IsAlive ? 1 : 0;
            aliveNeighbours += cells[x, yB].IsAlive ? 1 : 0;
            aliveNeighbours += cells[xR, yB].IsAlive ? 1 : 0;

            return aliveNeighbours;

        }
        public static void NextState(this IGame game)
        {
            var (width, height) = GetBounds(game);

            bool[,] nextState = new bool[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int neighbours = GetAliveNeighboursCount(game,i, j);

                    if (!game.Field.Table[i, j].IsAlive && neighbours == 3)
                    {
                        nextState[i, j] = true;
                    }
                    else if (game.Field.Table[i, j].IsAlive && neighbours is 3 or 2)
                    {
                        nextState[i, j] = true;
                    }
                    else
                    {
                        nextState[i, j] = false;
                    }
                 

                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    game.Field.Table[i, j].IsAlive = nextState[i, j];


                }
            }


            
        }
    }
}
