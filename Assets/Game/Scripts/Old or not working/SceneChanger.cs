using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeatSort
{
    public class SceneChanger : MonoBehaviour
    {
        private GameObject _currentLevel;
        [SerializeField] private GameObject[] _levels;

        private void Start()
        {
            LoadLevel();
        }
        public void LoadLevel()
        {
            Destroy(_currentLevel);

            var idx = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var nextLevel = (idx) % sceneCount;

            _currentLevel = Instantiate(_levels[nextLevel]);
        }

        public void NextLevel()
        {
            var idx = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var nextLevel = (idx + 1) % sceneCount;

            PlayerPrefs.SetInt("Level", nextLevel);

            LoadLevel();
        }



        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ReloadLevel();
            }
        }
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(_currentLevel);

            //} private void Start()
            //{
            //    var level = PlayerPrefs.GetInt("Level", 0);
            //    var idx = SceneManager.GetActiveScene().buildIndex;
            //    if (level != idx)
            //    {
            //        LoadLevel(level);
            //    }
            //}

            //public void LoadNextLevel()
            //{
            //    var idx = SceneManager.GetActiveScene().buildIndex;
            //    var sceneCount = SceneManager.sceneCountInBuildSettings;
            //    var nextLevel = (idx + 1) % sceneCount;

            //    PlayerPrefs.SetInt("Level", nextLevel);
            //    SceneManager.LoadScene(nextLevel);
            //}

            //public void LoadLevel(int levelIdx)
            //{
            //    var sceneCount = SceneManager.sceneCountInBuildSettings;
            //    var nextLevel = (levelIdx) % sceneCount;
            //    SceneManager.LoadScene(nextLevel);
            //}
        }
    }
}
