namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            CasinoGame game = new CasinoGame(1000); // Starta Roulett med bestämda priset
            game.StartGame();
 
            // CasinoGame game1 = new CasinoGame(14000); // Starta Roulett med bestämda priset
            // game1.StartGame();

        }
    }
}
