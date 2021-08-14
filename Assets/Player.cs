using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Collider[] pilars;

    [Header("Components")]
    [SerializeField]
    private Rigidbody rig;

    [Header("Stats")]
    [SerializeField]
    private int jumpForce;
    [SerializeField]
    private int transitionForce;
    [SerializeField]
    private int currentPilarIndex;
    [SerializeField]
    private bool isMovingTowardsPilar;

    [Header("Time Stats")]
    [SerializeField]
    private float currentTime;
    [SerializeField]
    private float nextTime;
    [SerializeField]
    private float holdTime;
    // Start is called before the first frame update
    void Start()
    {
        currentPilarIndex = 0;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Pilar"))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        { 
            GoToNextPilar();
        }
        */
        if (Input.GetMouseButtonDown(0))  //|| Input.GetMouseButtonDown(1)) Uncomment this for right click backawrds
        {
            currentTime = Time.time;
            nextTime = currentTime + holdTime;
        }

    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            MoveForward();

        }
        /*else if(Input.GetMouseButton(1))  Uncomment this for right click backwards
        {
            MoveBackwards();
        }
        */
    }

    void MoveForward()
    {
        if (Time.time >= nextTime)
        {
            Debug.Log("HOli");
            transform.position += transform.forward * 0.1f;
            nextTime += holdTime;
        }
    }

    void MoveBackwards()
    {
        if (Time.time >= nextTime)
        {
            Debug.Log("HOli");
            transform.position -= transform.forward * 0.1f;
            nextTime += holdTime;
        }
    }
    /*
    void GoToNextPilar()
    {
        if(currentPilarIndex + 1 < pilars.Length)
        {
            currentPilarIndex += 1;
            pilars[currentPilarIndex].enabled = true;
            rig.AddForce(transform.forward * transitionForce, ForceMode.Impulse);
        }
    }
    */
    /*
    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
        rig.velocity = Vector3.forward * 0;
    }
    */
}

