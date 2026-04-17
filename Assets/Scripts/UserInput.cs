using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Vertical = "Vertical";
    private readonly string Horizontal = "Horizontal";

    public event Action<float> Moved;
    public event Action<float> Rotated;

    private void Update()
    {
        float moveDirecion = Input.GetAxis(Vertical);
        float rotateDirection = Input.GetAxis(Horizontal);

        if(moveDirecion != 0) 
            Moved?.Invoke(moveDirecion);
    
        if(rotateDirection != 0)
            Rotated?.Invoke(rotateDirection);
    }
}
