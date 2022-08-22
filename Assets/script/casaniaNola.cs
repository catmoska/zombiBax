using UnityEngine;

public class casaniaNola : MonoBehaviour
{
    public bool casania {
        get
        {
            if(kadar) return casaniaVre;
            kadar = true;
            casaniaVre = rei();
            return casaniaVre;
        } private set { } }


    public float distansia;
    public LayerMask Mask;
    private bool casaniaVre;
    private bool kadar;


    private void LateUpdate()
    {
        kadar = false;
    }

    private bool rei()
    {
        if(globalNeramenia.sig.debug) Debug.DrawRay(transform.position, -Vector2.up* distansia);
        RaycastHit2D[] o =Physics2D.RaycastAll(transform.position, -Vector2.up, distansia, Mask);
        return o.Length != 0;
    }
}
