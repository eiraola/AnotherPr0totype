using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private InputSignalSO _inputSignalSO = null;
    private float _currentXValue = 0.0f;
    private float _currentYValue = 0.0f;



    public void OnMovementXInput(InputAction.CallbackContext context)
    {
        
        _currentXValue = context.ReadValue<float>();
        SendMovementValue();
    }

    public void OnMovementYInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());
        _currentYValue = context.ReadValue<float>();
        SendMovementValue();
    }

    private void SendMovementValue()
    {
        Vector2 currentValue = new Vector2(_currentXValue, _currentYValue);
        if(currentValue.magnitude > 1.0f)
        {
            currentValue = currentValue.normalized;
        }

        _inputSignalSO.ExecuteMoveAction(currentValue);
    }

}
