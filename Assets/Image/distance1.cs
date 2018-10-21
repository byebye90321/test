using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class distance1 : MonoBehaviour {

    public Vector3 EndPoint;
    public Vector3 StartPoint;
	public GameObject moster;

	public GameObject Tr_M;
	public float Tr_MStart;
    public float TrEnd;
    

    Image DistanceBar;
	public float Total_MLenght;
	public float Now_MDistance;
	// Use this for initialization
	void Start () {

        DistanceBar= GetComponent<Image>();
        StartPoint =moster.transform.position;
        Total_MLenght = EndPoint.x - StartPoint.x;

        

    }
	
	// Update is called once per frame
	void Update () {

		Now_MDistance = moster.transform.position.x - StartPoint.x;

		DistanceBar.fillAmount = Now_MDistance / Total_MLenght;
		Tr_M.transform.localPosition = new Vector3(Tr_MStart + (Now_MDistance / Total_MLenght) * (TrEnd - Tr_MStart),318f, 0);

       // DistanceBar=



	}
}
