using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "State/Idle State")]
public class IdleState : State
{
    [SerializeField] private float wait = 3.0f;
    private float waitTimer;
    private bool isIdleFinished = false;

    public bool IsIdleFinished => isIdleFinished;

    public IdleState(GameObject _owner) : base(_owner)
    {
        owner = _owner;
    }

    public override void Start()
    {
        Debug.Log("Entering Idle State");
        waitTimer = wait; // Initialise le timer
        isIdleFinished = false;
    }

    public override void Update()
    {
        waitTimer -= Time.deltaTime; // Diminue le timer
        if (waitTimer <= 0 && !isIdleFinished)
        {
            isIdleFinished = true;
            Debug.Log("Idle terminé, prêt à nettoyer !");
        }
    }
}
