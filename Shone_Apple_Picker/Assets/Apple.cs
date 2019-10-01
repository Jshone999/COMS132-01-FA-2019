using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Apple")]
 
    public static float bottomY = -20f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            Apple_Picker apScript = Camera.main.GetComponent<Apple_Picker>();
            apScript.AppleDestroyed();
        }
    }
}
