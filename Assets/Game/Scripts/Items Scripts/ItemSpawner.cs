using System.Collections;
using UnityEngine;

namespace BeatSort
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefab;
        [SerializeField] private Vector3 _range;
        [SerializeField] private float spawnDelay = 2f;


        IEnumerator Start()
        {
            while (true)
            {
                bool _full = ScoreHandler._stopSpawn;
                if (_full)
                { break; }
                var rand = Random.Range(0, _prefab.Length);
                Vector3 offset = new Vector3(_range.x, _range.y, Random.Range(-_range.z, _range.z));
                Instantiate(_prefab[rand], transform.position + offset, Quaternion.identity, transform);

                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}