using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CountItHigher : MonoBehaviour
{
    private int num = 0;

    void Update()
    {
        print(nextNum);   
    }

    public int nextNum
    {
        get
        {
            num++;
            return (num);
        }
    }

    public int currentNum
    {
        get
        {
            return (num);
        }

        set
        {
            num = value;
        }
    }
}
