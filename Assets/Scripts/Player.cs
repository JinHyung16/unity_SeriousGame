using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    private Vector3 moveDir;
    private bool isRun = false;

    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        this.gameObject.transform.position = new Vector3(0, -1, 0);
    }

    private void Update()
    {
        TouchInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && !GameManager.Instance.isTakeItem)
        {
            anim.SetTrigger("isTake");

            //GameManager.Instance.ItemName = other.gameObject.name;

            // ui upadet
            GameManager.Instance.TakeItem(other.gameObject.name);
            GameManager.Instance.isTakeItem = true;
        }
    }
    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            // ui upadet
            GameManager.Instance.TakeItem("None");
        }
    }
    */

    private void TouchInput()
    {
        // pc mouse click system
        if (Input.GetMouseButtonDown(1))
        {
            // right click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100.0f, groundLayer))
            {
                if(hit.collider.CompareTag("Room"))
                {
                    moveDir = new Vector3(hit.point.x, 0, hit.point.z);
                    agent.SetDestination(moveDir);

                }
                else if(hit.collider.CompareTag("Box"))
                {
                    moveDir = new Vector3(hit.point.x, 0, hit.point.z - 0.3f);
                    agent.SetDestination(moveDir);
                }
                else if(hit.collider.CompareTag("Decoration"))
                {
                    return;
                }
            }
        }

        // mobile touch system
        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out RaycastHit hit, 100.0f, groundLayer))
                    {
                        if (hit.collider.CompareTag("Room"))
                        {
                            moveDir = new Vector3(hit.point.x, 0, hit.point.z);
                            agent.SetDestination(moveDir);

                        }
                        else if (hit.collider.CompareTag("Box"))
                        {
                            moveDir = new Vector3(hit.point.x, 0, hit.point.z - 0.3f);
                            agent.SetDestination(moveDir);

                        }
                        else if (hit.collider.CompareTag("Decoration"))
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //The remaining distance are less or equal than the stopping distance it means character stop moving and reached destination
            isRun = false;
        }
        else
        {
            //If remaining distance are greater than the stopping distance than character still moving toward Destination
            isRun = true;
        }

        anim.SetBool("isRun", isRun);
    }
}
