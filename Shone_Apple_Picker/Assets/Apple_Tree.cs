using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Tree : MonoBehaviour
{
    public GameObject Apple_Prefab;
    public GameObject Gold_Apple_Prefab;

    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("ranDrop", 2f);
    }

    void ranDrop()
    {
        if (Random.value * 100 > 10)
        {
            Invoke("DropApple", 2f);
        }
        else
            Invoke("DropAppleGold", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(Apple_Prefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
        Start();
    }

    void DropAppleGold()
    {
        GameObject apple = Instantiate<GameObject>(Gold_Apple_Prefab);
        apple.transform.position = transform.position;
        Invoke("DropAppleGold", secondsBetweenAppleDrops);
        Start();
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
