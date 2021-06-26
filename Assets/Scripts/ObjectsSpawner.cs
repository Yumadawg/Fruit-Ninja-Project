using System.Collections;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPool;
    [SerializeField] private Transform[] objectDownSpawner;
    [SerializeField] private Transform[] objectSideSpawner;

    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;
    private float force;

    public enum SpawnerType { down, sides }
    public SpawnerType Type;

    private void Start()
    {
        StartCoroutine(WaitAndPrint());
    }

    void SpawnObject()
    {
        int spawnerNum = 0;
        int objectNum = 0;

        switch (Type)
        {
            case SpawnerType.down:
                spawnerNum = Random.Range(0, objectDownSpawner.Length);
                objectNum = Random.Range(0, objectsPool.Length);

                Instantiate(objectsPool[objectNum], objectDownSpawner[spawnerNum].position, Quaternion.identity);
                break;
            case SpawnerType.sides:
                force = Random.Range(minForce, maxForce);
                spawnerNum = Random.Range(0, objectSideSpawner.Length);
                GameObject go =  Instantiate(objectsPool[objectNum], objectSideSpawner[spawnerNum].position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(objectSideSpawner[spawnerNum].forward * force, ForceMode.Impulse);
                break;
        }
    }

    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnObject();
        }
    }
}
