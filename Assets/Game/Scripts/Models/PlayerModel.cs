using UnityEngine;

namespace BeatSort
{
    [System.Serializable]
    public class PlayerModel : Model
    {
        [SerializeField] protected string _playerName;
        [SerializeField] protected int _score;

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
            }
        }
    }
}
