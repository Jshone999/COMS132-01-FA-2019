using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePrefab : MonoBehaviour
{
    public GameObject Sphere_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Sphere_Prefab);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Sphere_Prefab);
    }
}
