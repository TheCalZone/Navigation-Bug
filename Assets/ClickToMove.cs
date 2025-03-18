using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (agent != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse clicked");
                if (NavMesh.SamplePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition), out NavMeshHit hit, 100, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                }
                else
                {
                    Debug.Log("No path found");
                }
            }
        }

        CameraFollowPlayer();

    }

    private void CameraFollowPlayer()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
