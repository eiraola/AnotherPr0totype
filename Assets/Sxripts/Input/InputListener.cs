using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    [SerializeField]
    private InputSignalSO _inputSignal = null;

    [SerializeField]
    private UnityEvent<Vector2> _onMoveInput = new UnityEvent<Vector2>();

    private void OnEnable()
    {
        _inputSignal.AddMoveAction(RunMoveActions);
    }

    private void OnDisable()
    {
        _inputSignal.RemoveMoveAction(RunMoveActions);
    }

    private void RunMoveActions(Vector2 value)
    {
        _onMoveInput?.Invoke(value);
    }



}
