using UnityEngine;

namespace BeatSort
{
    public class LevelSelector : MonoBehaviour
    {
        private LoadLevel _level;
        public void Click(int idx)
        {
            PlayerPrefs.SetInt("Level", idx);

            _level = FindObjectOfType<LoadLevel>();

            _level.StartProvider();
        }
    }
}
