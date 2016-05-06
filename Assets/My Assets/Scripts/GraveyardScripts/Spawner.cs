using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject AI;
    public GameObject chase;
    //public Vector3 spawnValues;
    public int aiCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int totalWaves;
    int waveCounter;

    float positionX;
    float positionY;
    float positionZ;

    void Start()
    {
        positionX = this.transform.position.x;
        positionY = this.transform.position.y;
        positionZ = this.transform.position.z;
        waveCounter = 0;

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (waveCounter < totalWaves)
        {
            for (int i = 0; i < aiCount; i++)
            {
                float randomX = random(positionX);
                float randomZ = random(positionZ);

                Vector3 spawnPosition = new Vector3(randomX, positionY, randomZ);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(AI, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            waveCounter++;
        }
    }

    private float random(float xyz)
    {
        return Random.Range(xyz - 10, xyz + 10);
    }
   

}
