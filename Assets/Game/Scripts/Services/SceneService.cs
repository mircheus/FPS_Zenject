using UnityEngine.SceneManagement;

namespace Game.Scripts.Services
{
    public class SceneService : ISceneService
    {
        public void LoadMainMenu() => SceneManager.LoadScene("MainMenu");
        public void LoadGameplay() => SceneManager.LoadScene("Gameplay");
        public void LoadGameOver() => SceneManager.LoadScene("GameOver");
    }
}