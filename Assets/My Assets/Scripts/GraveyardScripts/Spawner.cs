using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject AI;
    public GameObject chase;
    //public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    float positionX;
    float positionY;
    float positionZ;

    void Start()
    {
        positionX = this.transform.position.x;
        positionY = this.transform.position.y;
        positionZ = this.transform.position.z;

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                float randomX = random(positionX);
                float randomZ = random(positionZ);

                Vector3 spawnPosition = new Vector3(randomX, positionY, randomZ);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(AI, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    private float random(float positionCoordinate)
    {
        return Random.Range(positionCoordinate - 10, positionCoordinate + 10);
    }
   

}
