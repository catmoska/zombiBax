using System.Collections;
using UnityEngine;

public class spavn : MonoBehaviour
{
    public GameObject p;
    public Vector2 u;
    void Start()
    {
        StartCoroutine(barerc());
    }

    public IEnumerator barerc()
    {
        while (true) { 
            yield return new WaitForSeconds(3);
            Instantiate(p, u, Quaternion.identity);
        } 
    }
}
