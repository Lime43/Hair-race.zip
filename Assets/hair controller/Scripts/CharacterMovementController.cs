using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed=1;

    private float gravityModifier=-9.81f;

    //Private Data
    private CharacterInputController characterInputController;
    private Rigidbody rb;
    public Animator anim;
    private bool isRunning;
    private bool reachedGoalLine;
    private Transform endTraget;
    private Transform lookAtEndTraget;
    private bool stretchingHairPhase;

    private void Awake()
    {
        characterInputController = this.GetComponent<CharacterInputController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        startPlay();
    }

    // Update is called once per frame
    void Update()
    {

        if(canPlay())
        move();
    }
    private void move()
    {

        if (!reachedGoalLine)
        {
            Vector3 newPos = this.rb.position + characterInputController.getNewPos();
            this.rb.MovePosition(Vector3.MoveTowards(this.rb.position, Vector3.Slerp(this.rb.position, newPos, .7f), 8f));
        }else if (reachedGoalLine)
        {
            Vector3 directionToEndTraget = endTraget.position - this.transform.position;
            directionToEndTraget *= Time.deltaTime * 2f;
            this.transform.position += directionToEndTraget;
            float distanceToEnd = Vector3.Distance(this.transform.position, endTraget.position);
            if (distanceToEnd < 1f &&  !stretchingHairPhase)
            {
                stretchingHairPhase = true;
                int randompose = UnityEngine.Random.Range(1, 8);
                if(randompose==1)
                {
                    anim.SetTrigger("Pose1");
                    anim.SetBool("Running", false);

                }
                else if (randompose == 2)
                {
                    anim.SetTrigger("Pose2");
                    anim.SetBool("Running", false);

                }
                else if (randompose == 3)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose3");

                }
                else if (randompose ==4)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose4");

                }
                else if (randompose == 5)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose5");

                }
                else if (randompose == 6)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose6");

                }
                else if (randompose == 7)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose7");

                }
                else if (randompose == 8)
                {
                    anim.SetBool("Running", false);

                    anim.SetTrigger("Pose8");

                }

                //anim.SetTrigger("Dance0");
                //  anim.SetTrigger("Laying");
                //  anim.SetTrigger("Dance0");
                print("Yoooooo End");
                this.rb.isKinematic = true;
                this.transform.GetComponentInChildren<HairController>().resetHair();
                this.transform.localEulerAngles = new Vector3(0, 180, 0);
                Invoke("stretchHair", 3f);
               // transform.localRotation = Quaternion.Lerp(this.transform.rotation, lookAtEndTraget.rotation, 1);
            }
        }
        
    }
    void FixedUpdate()
    {
        if (isRunning && canPlay())
            rb.velocity = (Vector3.forward * speed + Vector3.up * gravityModifier);
        else
            rb.velocity = Vector3.zero;

    }

    private void startPlay()
    {
        //anim.SetBool("Run", true);
    }
    public void updateMovementState(bool currentState)
    {
        isRunning = currentState;
        if (isRunning)//Enable Run Animation
        {
            anim.SetBool("Running", true);
            print(" running");

            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
        else //Disable Running Animation
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation| RigidbodyConstraints.FreezePositionX;
            print("not running");
            int randompose = UnityEngine.Random.Range(1,8);

            if (randompose == 1)
            {
                anim.SetTrigger("Pose1");
                anim.SetBool("Running", false);

            }
            else if (randompose == 2)
            {
                anim.SetTrigger("Pose2");
                anim.SetBool("Running", false);

            }
            else if (randompose == 3)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose3");

            }
            else if (randompose == 4)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose4");

            }
            else if (randompose == 5)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose5");

            }
            else if (randompose == 6)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose6");
                print("pose");

            }
            else if (randompose == 7)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose7");
                print("pose");

            }
            else if (randompose == 8)
            {
                anim.SetBool("Running", false);

                anim.SetTrigger("Pose8");
                print("pose");

            }

        }
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            print("Rechead finish line");
            anim.SetBool("finish", true);

        HairController.instance.resetHair();
            endTraget = other.GetComponent<FinishController>().getFinishTarget();
            lookAtEndTraget= other.GetComponent<FinishController>().getFinishLookAtTarget();
            characterInputController.enabled = false;
            reachedGoalLine = true;
        }
        if (other.gameObject.CompareTag("Fail"))
        {
            GameManagers.instance.endPlay();
        }
    }
    private bool canPlay()
    {
        return GameManagers.instance.currentGameState == GameManagers.GameState.play;
    }
    private void stretchHair()
    {
        HairController.instance.stretchHair();
    }

}
