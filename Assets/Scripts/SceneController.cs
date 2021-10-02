using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] waypoints;

    private int[] countEnemiesOnWaypoints;
    private int currentCheckedWaypoint = 0;

    private float runSpeed = 2f;

    private bool startGame = false;

    private Animator playerAnimator;

    private const string isReachedWaypoint = "isReachedWaypoint";

    private InputController inputController;

    private void Start()
    {
        inputController = gameObject.AddComponent<InputController>();
        playerAnimator = player.GetComponent<Animator>();

        countEnemiesOnWaypoints = new int[] {0,2,0,0,3,3,0,0,0,0};
    }

    private void Update()
    {
        if (inputController.isUserTapOnScreen())
        {
            startGame = true;
        }

        if (startGame)
        {
            isPlayerReachedWaypoint();
        }
    }

    private bool isPlayerReachedWaypoint()
    {
        bool playerReachWaypoint = player.transform.position == waypoints[currentCheckedWaypoint].transform.position;

        if (playerReachWaypoint)
        {
            StayOnWaypoint();
            return true;

        }
        if (isAllEnemyDead())
        {
            playerAnimator.SetBool(isReachedWaypoint, false);
            MoveToNextWaypoint();
            return false;
        }

        return false;
    }

    private void StayOnWaypoint()
    {
        playerAnimator.SetBool(isReachedWaypoint, true);

        currentCheckedWaypoint++;

        player.transform.LookAt(waypoints[currentCheckedWaypoint].transform.position);
    }

    private void MoveToNextWaypoint()
    {
        Vector3 current = player.transform.position;
        Vector3 target = waypoints[currentCheckedWaypoint].transform.position;
        float totalSpeed = Time.deltaTime * runSpeed;

        player.transform.position = Vector3.MoveTowards(current, target, totalSpeed);
        player.transform.LookAt(target);
    }

    private bool isAllEnemyDead()
    {
        if (countEnemiesOnWaypoints[currentCheckedWaypoint] == 0)
        {
            return true;
        }
        return false;
    }

    public void EnemyDied(int waypoint)
    {
        countEnemiesOnWaypoints[waypoint+1] -= 1;
    }
}
