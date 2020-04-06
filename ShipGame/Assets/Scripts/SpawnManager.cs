using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;    
    [SerializeField]
    private GameObject _enemySet;
    [SerializeField]
    private GameObject[] _PowerUpPrefab;
    

    [SerializeField]
    private bool _stopSpawing = false;


    #region Singleton
    public static SpawnManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is Another SpawnManager in the Scene!!!");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        _stopSpawing = false;
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupsRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (!_stopSpawing)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int enemyIndex = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(_enemyPrefabs[enemyIndex], spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemySet.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupsRoutine()
    {
        while(!_stopSpawing)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            GameObject newPowerUp = Instantiate(_PowerUpPrefab[randomPowerUp], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawing = true;
    }
}
