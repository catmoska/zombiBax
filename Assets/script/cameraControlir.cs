using UnityEngine;

public class cameraControlir : MonoBehaviour
{
    private Transform pleir;
    public Vector3 size;

    private void Start()
    {
        pleir = pleirSingenlton.pleirTransform;
    }

    private void FixedUpdate()
    {
        transform.position = pleir.position+ size;
    }
}
