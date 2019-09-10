using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefabVar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spherePrefabVar);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(spherePrefabVar);
    }
}
