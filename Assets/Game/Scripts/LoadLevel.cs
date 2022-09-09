using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeatSort
{
    public class LoadLevel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _levels;
        private GameObject _currentLevel;

        void Start()
        {
            LoadSomeLevel();
        }


        public void LoadSomeLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            var idx = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var nextLevel = (idx) % sceneCount;

            Vector3 offset = new Vector3(0, 0, 0);

            _currentLevel = Instantiate(_levels[nextLevel], transform.position + offset, Quaternion.identity);
        }
        public void NextLevel()
        {
            var idx = SceneManager.GetActiveScene().buildIndex;
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            var nextLevel = (idx + 1) % sceneCount;

            PlayerPrefs.SetInt("Level", nextLevel);

            LoadSomeLevel();
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
        }
    }
}
