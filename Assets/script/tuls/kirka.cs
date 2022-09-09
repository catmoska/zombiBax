using UnityEngine;

public class kirka : defoltTuls
{
    public int uron;
    public stritelstvo stro;

    private void Start()
    {
        stro = stritelstvo.sig;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            stro.lomats(stro.mesnostMaus(),uron,true);
    }

}
