using UnityEngine;
using UnityEngine.Events;

namespace BeatSort
{
    public class StateProvider : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public UnityEvent OnChangeState;

        private void OnEnable()
        {
            _gameStateMachine.OnChangedState.AddListener(OnChangeStateDelegate);
        }
        private void OnDisable()
        {
            _gameStateMachine.OnChangedState.RemoveListener(OnChangeStateDelegate);
        }
        private void OnChangeStateDelegate()
        {
            OnChangeState.Invoke();
        }
    }
}