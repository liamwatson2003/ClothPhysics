using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour {

    public GameObject[] otherGO;

    public float maxdistance;
    public float gravpower;

    private float mag;

    public float correctionForce;
    public float force;

    public float StretchThreshold;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 5; i++)
        {
            foreach (GameObject GO in otherGO)
            {

                if (GO != null)
                {
                    Debug.DrawLine(this.transform.position, GO.transform.position, Color.blue);
                    mag = wobkmath.Instance.GetMag(transform, GO.transform);

                    correctionForce = force / 10 * mag / 2;
                    //Debug.Log(mag + " and " + maxdistance);
                    if (mag > maxdistance)
                    {
                        wobkmath.Instance.MoveTowards(this.gameObject.transform, GO.transform, correctionForce, false, true);
                    }

                    if (mag < maxdistance + StretchThreshold)
                    {
                        transform.Translate(Vector3.down * (gravpower * Time.deltaTime) / otherGO.Length);
                    }
                }
            }//end foreach
        }
        //transform.Translate(Vector3.down * gravpower * Time.deltaTime);




    }
}
