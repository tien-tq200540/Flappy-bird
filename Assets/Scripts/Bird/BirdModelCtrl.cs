using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdModelCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;

    public enum BirdModelState
    {
        Up,
        Down
    }

    [SerializeField] protected BirdModelState state;

    protected override void LoadComponents()
    {
        LoadModel();
    }

    private void OnEnable()
    {
        EventManager.OnPlayerModelChangeState += UpdateState;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerModelChangeState -= UpdateState;
    }

    protected virtual void UpdateState(object sender, PlayerModelChangeStateEventArgs e)
    {
        if (state == e.State) return;
        state = e.State;
        Quaternion quaternion;
        switch (state)
        {
            case BirdModelState.Up:
                quaternion = Quaternion.Euler(0f, 0f, 30f);
                transform.rotation = quaternion;
                break;
            case BirdModelState.Down:
                quaternion = Quaternion.Euler(0f, 0f, -30f);
                transform.rotation = quaternion;
                break;
        }
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform;
        Debug.Log($"{transform.name}: LoadModel", this);
    }
}