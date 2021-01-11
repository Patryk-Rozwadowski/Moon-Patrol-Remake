﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementV2 : MonoBehaviour
{
    [SerializeField] private Transform[] moveSpots;  //contains top and bottom position
    List<float> beatsTimer = new List<float>();
    public Transform objectToMove;
    private int randomSpot;

    void Update()
    {
        //For testing purposes
        beatsTimer.Add(0.90f);
        beatsTimer.Add(1.895f);
        beatsTimer.Add(2.64f);
        beatsTimer.Add(3.98f);

        //random spot
        randomSpot = Random.Range(0, moveSpots.Length);
        //Start the moveobject
        StartCoroutine(beginToMove());
    }

    IEnumerator beginToMove()
    {
        // 0 = move up, 1 = move down
/*        int upDownMoveDecider = 0;*/

        //Loop through the timers
        for (int i = 0; i < beatsTimer.Count; i++)
        {
/*            if (upDownMoveDecider == 0)
            {*/
                //Move up
                Debug.Log("Moving Up with time: " + beatsTimer[i] + " in index: " + i);
                //Start Moving and wait here until move is complete(moveToX returns)
                yield return StartCoroutine(moveToX(objectToMove, moveSpots[randomSpot].position, beatsTimer[i]));

/*                //Change direction to 1 for next move
                upDownMoveDecider = 1;
            }*/
/*            else
            {
                //Move down
                Debug.Log("Moving Down with time: " + beatsTimer[i] + " in index: " + i);
                //Start Moving and wait here until move is complete(moveToX returns)
                yield return StartCoroutine(moveToX(objectToMove, moveSpots[randomSpot].position, beatsTimer[i]));

                //Change direction to 0 for next move
                upDownMoveDecider = 0;
            }*/
        }
    }

    IEnumerator moveToX(Transform fromPosition, Vector2 toPosition, float duration)
    {
        float counter = 0;

        //Get the current position of the object to be moved
        Vector2 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }
    }
    void RandomMove()
    {
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }
}
