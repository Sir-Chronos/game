namespace RPG.Singleton
{
    public class GameState
    {
        private static GameState? _instance;  // Declare a variável como nullable

        private int _score;

        // A propriedade Instance garante que sempre utilizamos a mesma instância (Singleton)
        public static GameState Instance => _instance ??= new GameState();

        // Propriedade para acessar o score
        public int Score => _score;

        // Construtor privado para garantir que não criem instâncias fora da classe
        private GameState()
        {
            _score = 0; // Inicializa com 0 ou algum valor inicial
        }

        // Método para aumentar a pontuação
        public void IncreaseScore(int points)
        {
            _score += points;
        }

        // Método para reiniciar o jogo
        public void ResetGame()
        {
            _score = 0; // Reseta a pontuação
        }
    }
}
