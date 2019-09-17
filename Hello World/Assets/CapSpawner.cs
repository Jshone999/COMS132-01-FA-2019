using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapSpawner : MonoBehaviour
{
    public GameObject capPrefabVar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(capPrefabVar);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(capPrefabVar);
    }
}
