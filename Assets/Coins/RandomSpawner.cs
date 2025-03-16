using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 0.1f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnCube();
        }
    }

        void SpawnCube()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-130, 120), 1.2f, Random.Range(-130, 120));
        Quaternion rotation = Quaternion.Euler(90, 0, 0); // Random rotation around x-axis in 90-degree increments
        Instantiate(cubePrefab, randomSpawnPosition,rotation);
    }
}

//IEnumerator it's a return type.
//IEnumerator being so called implies it is an interface, so any class that implements the IEnumerator interface can be returned by this method
//In practice in this use it seems that it's actually more of a hack than intending to provide the true intent of an enumerator, which is to step-by-step rifle through(or generate) a collection of things.
//When you use a yield return statement within a method "some magic happens" whereby it's not a return in the classic sense, but creates a facility whereby the code can resume from where it left off (calling for the next item out of the returned enumerator will cause the code to resume from after the yield, with all the state it had before, rather than starting over).