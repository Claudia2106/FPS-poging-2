using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform arrowOrigin;
    public GameObject arrow;
    public float speed;
    public int points;
    public GameObject endScreen;

    private bool loaded;
    private GameObject loadedArrow = null;

    // Update is called once per frame
    void Update()
    {
        if (loaded)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                loaded = false;

                // Hulp van Casey met pijl schieten
                loadedArrow.transform.SetParent(null, true);
                Rigidbody arrowRigidbody = loadedArrow.GetComponent<Rigidbody>();
                arrowRigidbody.isKinematic = false;
                arrowRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                arrowRigidbody.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
                arrowRigidbody.AddRelativeTorque(Vector3.up * speed, ForceMode.Impulse);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                loaded = true;
                loadedArrow = Instantiate(arrow, arrowOrigin);
            }
        }
    }

    public void RemovePoint()
    {
        points = points - 1;
        if (points == 0)
        {
            endScreen.SetActive(true);
        }
    }
}
