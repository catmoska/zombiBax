using UnityEngine;

public class generit : MonoBehaviour
{
    public stritelstvo SS;

    private void Start()
    {
        for (int X = 0; X < 100; X++)
            SS.nostavkaBloca(X, 0, 0,true);

        for (int X = 0; X < 100; X++)
            for (int Y = 1; Y < 3; Y++)
                SS.nostavkaBloca(X, Y, 1, true);

        for (int X = 0; X < 2; X++)
            SS.nostavkaBloca(X, 3, 2, true);

        for (int X = 2; X < 6; X++)
            SS.nostavkaBloca(X, 3, 0, true);

        for (int X = 6; X < 100; X++)
            SS.nostavkaBloca(X, 3, 2, true);
    }
}
