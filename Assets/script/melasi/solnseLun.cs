using UnityEngine;

public class solnseLun : MonoBehaviour
{
    public GameObject[] mas;
    public float smes;
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, GlobalTime.sig.timeDeika() * 360);
        transform.position = (Vector2)(pleirSingenlton.pleirTransform.position) * new Vector2(1,smes);
        for(int i = 0; i< mas.Length; i++) mas[i].transform.rotation = Quaternion.identity;
        
    }
}
