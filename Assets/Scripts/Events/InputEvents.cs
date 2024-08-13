using System;

public class InputEvents
{
    public event Action onMovePressed;
    public void MovePressed() 
    {
        if (onMovePressed is not null) 
        {
            onMovePressed();
        }
    }
    public event Action onSelectPressed;
    public void SelectPressed()
    {
        if (onSelectPressed is not null) 
        {
            onSelectPressed();
        }
    }
}
