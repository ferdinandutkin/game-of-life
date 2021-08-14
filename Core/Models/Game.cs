namespace Core.Models
{
    class Game : IGame
    {

        public IField Field { get; private set; }
        public Game(IField field) => Field = field;

 
    }
}