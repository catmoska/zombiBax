using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDell : MonoBehaviour
{
    public float times;
    void Start()=>Destroy(gameObject, times);
}
