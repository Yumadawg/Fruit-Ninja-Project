using UnityEngine;

public class Knife : MonoBehaviour
{
    public GameObject lineT;

    void Update()
    {
        RaycastHit hit;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 linePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 5));

        if (Input.GetMouseButton(0))
        {
            lineT.SetActive(true);
            lineT.transform.position = linePosition;

            if (Physics.Raycast(mousePosition, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(mousePosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.transform.tag == "Object")
                {
                    hit.transform.GetComponent<Object>().Destroy();
                }
            }
            else
            {
                Debug.DrawRay(mousePosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            }
        }
        else
        {
            lineT.SetActive(false);
        }
    }
}
