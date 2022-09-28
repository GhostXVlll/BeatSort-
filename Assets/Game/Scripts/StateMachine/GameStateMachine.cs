using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    [CreateAssetMenu(fileName = "GameStateMachine", menuName = "Create GameStateMachine", order = 0)]
    public class GameStateMachine : ScriptableObject
    {
        [SerializeField] private GameStates _gameState;

        public UnityEvent OnChangedState;

        public GameStates GameState
        {
            get => _gameState;
            set
            {
                if (_gameState == value)
                {
                    return;
                }

                _gameState = value;

                OnChangedState.Invoke();
            }
        }
    }
}
