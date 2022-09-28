using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeatSort
{
    public class LoadLevel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;
        private GameObject _currentLevel;
        int idx = 0;

        void Start()
        {
            PlayerPrefs.SetInt("Level", idx);
            LoadSomeLevel();
        }


        public void LoadSomeLevel()
        {
            if (_currentLevel != null) // Dstroying old level
            {
                Destroy(_currentLevel);
            }

            idx = PlayerPrefs.GetInt("Level");

            Vector3 offset = new Vector3(0, 0, 0);

            _currentLevel = Instantiate(_levels[idx], transform.position + offset, Quaternion.identity);

            Debug.Log("Level \"" + _currentLevel + "\" was loaded.");
        }
        public void NextLevel()
        {
            Debug.Log("next level TAG \n --------------------------------------------");
            var level = PlayerPrefs.GetInt("Level");

            int nextLevel = level + 1;

            PlayerPrefs.SetInt("Level", nextLevel);

            LoadSomeLevel();
        }
        private void OnApplicationQuit()  //save settings on app quit
        {
            PlayerPrefs.Save();
        }

        private void Update() // Reload Scene \|/
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ReloadLevel();
            }
        }
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}