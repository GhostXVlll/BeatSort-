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
            //var level = PlayerPrefs.GetInt("Level", 0);
            //var idx = SceneManager.GetActiveScene().buildIndex;
            //if (level != idx)
            LoadSomeLevel(idx);
        }


        public void LoadSomeLevel(int idx)
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            //var idx = SceneManager.GetActiveScene().buildIndex;
            //var sceneCount = SceneManager.sceneCountInBuildSettings;
            //var nextLevel = (idx) % _levels.Length;

            Vector3 offset = new Vector3(0, 0, 0);

            _currentLevel = Instantiate(_levels[idx], transform.position + offset, Quaternion.identity);
            Debug.Log("Level \"" + _currentLevel + "\" was loaded.");
        }
        public void NextLevel()
        {
            Debug.Log("AAAAAAAAAAAAAAAA"); //
            var idx = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var nextLevel = idx + 1;

            PlayerPrefs.SetInt("Level", nextLevel);

            _currentLevel = Instantiate(_levels[nextLevel]);
            Debug.Log("Level \"" + _currentLevel + "\" was loaded.");
            //LoadSomeLevel(idx);
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
