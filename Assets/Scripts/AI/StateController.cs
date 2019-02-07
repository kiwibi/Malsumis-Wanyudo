using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State currentState;
    public State remainState;
    public AlienStats stats;
    public Transform stateVisualizer;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive = true;

    void OnDrawGizmos()
    {
        if (currentState != null && stateVisualizer != null) 
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(stateVisualizer.position, 0.7f);
        }
    }
    
    void Start () 
    {
        chaseTarget = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AlienTarget>().transform;
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState (this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}