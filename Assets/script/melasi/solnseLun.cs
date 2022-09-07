using UnityEngine;

public class solnseLun : MonoBehaviour
{
    public GameObject[] mas;
    public float smes;
    public Camera cam;
    [ColorUsage(false, false)]
    public Color colDei;
    [ColorUsage(false, false)]
    public Color ColHin;

    public float levelCglazavania = 3;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        float rot = GlobalTime.sig.timeDeika() * 360;

        transform.rotation = Quaternion.Euler(0,0, GlobalTime.sig.timeDeika() * 360);
        transform.position = (Vector2)(pleirSingenlton.pleirTransform.position) * new Vector2(1,smes);
        for(int i = 0; i< mas.Length; i++) mas[i].transform.rotation = Quaternion.identity;


        float colors = (normalizat(rot-180, levelCglazavania) +1)/2;
        cam.backgroundColor = colDei * (1 - colors) + ColHin * (colors);
    }


    public float normalizat(float num,float level = 1)
    {
        if (num > level)
            return 1;
        else if (num < -level)
            return -1;

        return num/ level;
    }
}
