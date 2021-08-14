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
    // Start is called before the first frame update
    void Start()
    {
        currentPilarIndex = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pilar"))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GoToNextPilar();
        }
    }


    void GoToNextPilar()
    {
        if (currentPilarIndex + 1 < pilars.Length)
        {
            currentPilarIndex += 1;
            pilars[currentPilarIndex].enabled = true;
            rig.AddForce(transform.forward * transitionForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
        rig.velocity = Vector3.forward * 0;
    }
}
