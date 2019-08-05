using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Van Tutorial
public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.SetParent(other.transform, true);

        Component[] components = GetComponents<Component>();
        foreach (Component component in components)
        {
            if (!(component is Transform))
            {
                Destroy(component);
            }
        }

        // Van mij
        if (other.name == "Camp1_Shooting_shield")
        {
            Light light = other.GetComponentInChildren<Light>();
            Destroy(light);
            ArrowController arrowController = GameObject.Find("FPSController").GetComponent<ArrowController>();
            arrowController.RemovePoint();
        }
    }
}
