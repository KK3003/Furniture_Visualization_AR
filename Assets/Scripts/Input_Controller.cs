using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Input_Controller : MonoBehaviour
{
    [SerializeField] GameObject AR_object;
    [SerializeField] Camera AR_Camera;
    [SerializeField] ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    bool is_Spawned = false;
    [SerializeField]  ARSession arsession;
    ARPlaneManager planeManager;
    [SerializeField] GameObject planeFinadAnimation;

    void Start()
    {
        planeManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
        planeFinadAnimation.SetActive(true);
    }


    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            if (!is_Spawned)
            {
                Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
                if (raycastManager.Raycast(ray, hits))
                {
                    Pose pose = hits[0].pose;
                    Instantiate(AR_object, pose.position, pose.rotation);
                    is_Spawned = true;
                    planeFinadAnimation.SetActive(false);
                    SetAllPlanesActive();
                    planeManager.enabled = false;
                }
            }
        } 
    }

   
    void SetAllPlanesActive()
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    public void DisableARSession()
    {
        arsession.enabled = false;
        
    }

    public void EnableARSession()
    {
        arsession.enabled = true;
        
    }
}



