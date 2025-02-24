using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InputSignal", menuName = "ScriptableObjects/Input/Signal", order = 1)]
public class InputSignalSO : ScriptableObject
{
    private Action<Vector2> _onMoveAction = default;

    #region Movement


    public void AddMoveAction(Action<Vector2> newAction)
    {
        _onMoveAction += newAction;
    }

    public void RemoveMoveAction(Action<Vector2> newAction)
    {
        _onMoveAction -= newAction;
    }

    public void ExecuteMoveAction(Vector2 value)
    {
        _onMoveAction?.Invoke(value);
    }

    #endregion
}
