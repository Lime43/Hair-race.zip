using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform camTarget;
    private Transform camEndLookTarget;
    private Transform finishCamTraget;
    private Vector3 offset;
    private bool playerReachedGoalLine;
    public Transform[] camEndTargets;
    private int currentEndTragetReachedIndex=0;
    //References
    public static CameraController instance;

    // Start is called before the first frame update
    private void Start()
    {
        if (!instance) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        camTarget = GameObject.FindWithTag("Player").transform;
        offset = camTarget.position - this.transform.position;
    }
    void Update()
    {
        if (!playerReachedGoalLine)
            followTarget();
        else
            finishCamPos();

    }
    private void followTarget()
    {
        Vector3 newCamPos = (camTarget.position - offset);
        this.transform.position = Vector3.MoveTowards(this.transform.position, Vector3.Lerp(this.transform.position, newCamPos, .9f), 1f); 
    }
    private void finishCamPos()
    {
        //  Vector3 newCamPos = camTarget.position - this.transform.position;

        this.transform.LookAt(camEndLookTarget.position);
        Vector3 newCamPos=camEndTargets[currentEndTragetReachedIndex].position;
        if (Vector3.Distance(newCamPos, this.transform.position) < 1f)
        {
            switchEndTarget();
        }
        newCamPos = camEndTargets[currentEndTragetReachedIndex].position;
        // newCamPos =this.transform.position+(newCamPos - transform.position)*Time.deltaTime*10;
        this.transform.position = Vector3.MoveTowards(this.transform.position, Vector3.Slerp(this.transform.position, newCamPos, 1f), 1f);  
    }
    public void setCamEndTarget(Transform[] newCamTarget,Transform endLookTraget)
    {
        playerReachedGoalLine = true;
        camEndLookTarget = endLookTraget;
        camEndTargets = newCamTarget;
    }
    private void switchEndTarget()
    {
        if(currentEndTragetReachedIndex<camEndTargets.Length-1)
        currentEndTragetReachedIndex++;

    }

}
