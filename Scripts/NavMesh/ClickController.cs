using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    private NavMeshAgent agent;

    private RaycastHit[] hits = new RaycastHit[1];

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.RaycastNonAlloc(ray, hits) > 0)
            {
                agent.SetDestination(hits[0].point);
            }
        }
    }
}
