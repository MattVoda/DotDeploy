using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HutongGames.PlayMaker;


public class FindCirclePos : MonoBehaviour {


    public float radius = 1f;

    public object[] circlePositions;
    public FsmArray globalTilePosArray;

    public int childCount;

    // Use this for initialization
    void Start () {

        globalTilePosArray = FsmVariables.GlobalVariables.FindFsmArray("tilePositionsOnCircle");

        childCount = transform.childCount;
        circlePositions = new object[childCount];

        Figure();

        print(circlePositions);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Figure() {
        for(int i=1; i<=childCount; i++) {

            Vector3 newCirclePos = new Vector3(0, 0, 0);

            float angle = (Mathf.PI / i);

            newCirclePos.x = radius * Mathf.Cos(angle);
            newCirclePos.y = radius * Mathf.Sin(angle);

            circlePositions[i-1] = newCirclePos;
            
        }

        globalTilePosArray.Values = circlePositions;
    }

}