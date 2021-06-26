using UnityEngine;

public class Object : MonoBehaviour
{
    public float minRotationSpeed;
    public float maxRotationSpeed;
    private float vRotationSpeed;
    private float hRotationSpeed;
    public GameObject DestroyedObject;

    private void Start()
    {
        vRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        hRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(transform.right, vRotationSpeed * Time.deltaTime);
        transform.Rotate(transform.up, hRotationSpeed * Time.deltaTime);
    }

    public void Destroy()
    {
        print(transform.position);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject go = Instantiate(DestroyedObject, transform.position, transform.rotation);
        go.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-go.transform.right * 5, ForceMode.Impulse);
        go.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(go.transform.right * 5, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
