using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallControl : MonoBehaviour
{
    public float power = 10f;

    public float maxDrag = 5f;

    //public Rigidbody2D rb;

    public LineRenderer lr;

    [SerializeField] private Rigidbody2D rb; // new
    [SerializeField] private PhotonView view; // new




    Vector3 dragStartPos;

    Touch touch;



    private void Update()

    {

        


            if (Input.touchCount > 0 && PlayerPrefs.GetInt("atishakki") == 1 && view.IsMine)

            {

                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)

                {

                    DragStart();

                }

                if (touch.phase == TouchPhase.Moved)

                {

                    Dragging();

                }

                if (touch.phase == TouchPhase.Ended)

                {

                    DragRealease();
                    PlayerPrefs.SetInt("atishakki", 0);

                }

            }
        

        
        





    }

    private void DragStart()

    {

        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);

        dragStartPos.z = 0f;

        lr.positionCount = 1;

        lr.SetPosition(0, dragStartPos);

    }

    private void Dragging()

    {

        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);

        dragStartPos.z = 0f;

        lr.positionCount = 2;

        lr.SetPosition(1, draggingPos);

    }

    private void DragRealease()

    {

        lr.positionCount = 0;



        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);

        dragStartPos.z = 0f;



        Vector3 force = dragStartPos - dragReleasePos;

        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);

    }
}
