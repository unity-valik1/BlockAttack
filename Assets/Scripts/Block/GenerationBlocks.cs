using UnityEngine;

public class GenerationBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabSpawnBlocks;//������
    [SerializeField] GameObject[] _spawnPoints;

    [SerializeField] float _spawnSpeed;
    [SerializeField] float _timeInterval;

    private float _time = 0f;

    private int _numberBlocksSpawn = 0;
    public int _repeatingSpawnInFirstLines = 0;
    public int _repeatingSpawnInSecondLines = 0;

    public int gameMode = 0;

    void Update()
    {
        _time += _spawnSpeed * Time.deltaTime;
        if (_time >= _timeInterval)
        {
            InterestCalculation();
            _time = 0;
            BoostBlockSpawning();
        }
    }


    private void InterestCalculation()
    {
        int prossentSpawn = Random.Range(0, 100);

        if (prossentSpawn >= 0 && prossentSpawn <= 4)
        {
            _repeatingSpawnInFirstLines++;
            if (_repeatingSpawnInFirstLines == 1)
            {
                SpawnBlock(0);
            }
            else if (_repeatingSpawnInFirstLines > 1)
            {
                SpawnBlock(15);
                _repeatingSpawnInFirstLines = 0;
            }
        }
        else if (prossentSpawn >= 5 && prossentSpawn <= 9)
        {
            _repeatingSpawnInSecondLines++;
            if (_repeatingSpawnInSecondLines == 1)
            {
                SpawnBlock(1);
            }
            else if (_repeatingSpawnInSecondLines > 1)
            {
                SpawnBlock(14);
                _repeatingSpawnInSecondLines = 0;
            }
        }
        else if (prossentSpawn >= 10 && prossentSpawn <= 100)
        {
            if (prossentSpawn >= 10 && prossentSpawn <= 24)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(2);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(13);
                }
            }
            else if (prossentSpawn >= 25 && prossentSpawn <= 39)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(3);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(12);
                }
            }
            else if (prossentSpawn >= 40 && prossentSpawn <= 54)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(4);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(11);
                }
            }
            else if (prossentSpawn >= 55 && prossentSpawn <= 69)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(5);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(10);
                }
            }
            else if (prossentSpawn >= 70 && prossentSpawn <= 84)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(6);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(9);
                }
            }
            else if (prossentSpawn >= 85 && prossentSpawn <= 100)
            {
                int randomLine = Random.Range(0, 2);
                if (randomLine == 0)
                {
                    SpawnBlock(7);
                }
                else if (randomLine == 1)
                {
                    SpawnBlock(8);
                }
            }
        }
    }

    private void SpawnBlock(int numberSpawnPoint)
    {
        //int numberBlock = Random.Range(0, _prefabSpawnBlocks.Length);
        int numberBlock = Random.Range(0, 101);
        if(numberBlock >= 0 && numberBlock <= 19)
        {
            Instantiate(_prefabSpawnBlocks[0], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
        else if(numberBlock >= 20 && numberBlock <= 39)
        {
            Instantiate(_prefabSpawnBlocks[1], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
        else if(numberBlock >= 40 && numberBlock <= 59)
        {
            Instantiate(_prefabSpawnBlocks[2], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
        else if(numberBlock >= 60 && numberBlock <= 79)
        {
            Instantiate(_prefabSpawnBlocks[3], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
        else if(numberBlock >= 80 && numberBlock <= 91)
        {
            Instantiate(_prefabSpawnBlocks[4], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
        else if(numberBlock >= 92 && numberBlock <= 100)
        {
            Instantiate(_prefabSpawnBlocks[5], _spawnPoints[numberSpawnPoint].transform.position, Quaternion.identity);
        }
    }

    private void BoostBlockSpawning()
    {
        _numberBlocksSpawn++;
        if (_numberBlocksSpawn == 50)
        {
            _spawnSpeed += 0.5f;
        }
        else if (_numberBlocksSpawn == 75)
        {
            _spawnSpeed += 0.5f;
        }
        else if (_numberBlocksSpawn == 100)
        {
            _spawnSpeed += 0.5f;
        }
        else if (_numberBlocksSpawn == 200)
        {
            _numberBlocksSpawn = 151;
        }
    }
    public void RestartNumberBlocksSpawn()
    {
        _numberBlocksSpawn = 0;
        _spawnSpeed = 2;
    }

    public void ScriptEnabledTrue()
    {
        enabled = true;
    }
    public void ScriptEnabledFalse()
    {
        enabled = false;
    }

    public void GameModeStandart()
    {
        gameMode = 0;
    }
    public void GameModeLevels()
    {
        gameMode = 1;
    }
}
