using UnityEngine;

namespace BeatSort
{
    public class ChangeGameStateTo : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private GameStates _gameState;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public void ChangeState()
        {
            GameStateMachine.GameState = _gameState;
        }
    }
}
