using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigPrefabx : MonoBehaviour
{
    public GameObject EnemyZigPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemyZigPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(EnemyZigPrefab);
    }
}
