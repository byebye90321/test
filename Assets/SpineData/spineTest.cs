using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class spineTest : MonoBehaviour {

	[SpineAnimation]
	public string jumpAnim;
	[SpineAnimation]
	public string runAnim;

	private SkeletonAnimation skeletonAnimation;
	// Use this for initialization
	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("space"))
		{
			skeletonAnimation.state.SetAnimation(0, jumpAnim, false);
			skeletonAnimation.state.AddAnimation(0, "run", true, 0);
		}
		else {
			//skeletonAnimation.AnimationName = "run";
			//skeletonAnimation.state.SetAnimation(1, runAnim, true);
		}
	}
}
