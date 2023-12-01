using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private BaseState _currentState;

    [HideInInspector]
    public PatrolState PatrolState = new PatrolState();
    [HideInInspector]
    public ChaseState ChaseState = new ChaseState();
    [HideInInspector]
    public RetreatState RetreatState = new RetreatState();

    [SerializeField]
    public List<Transform> Waypoints = new List<Transform>();

    [HideInInspector]
    public NavMeshAgent NavMeshAgent;

    [SerializeField]
    public float ChaseDistance;

    [SerializeField]
    public Player Player;

    private void Awake()
    {
        _currentState = PatrolState;
        _currentState.EnterState(this);

        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Player.OnPowerUpStart += StartRetreating;
        Player.OnPowerUpStop += StopRetreating;
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.UpdateState(this);
        }
    }

    public void SwitchState(BaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    private void StartRetreating()
    {
        SwitchState(RetreatState);
    }

    private void StopRetreating()
    {
        SwitchState(PatrolState);
    }

}
