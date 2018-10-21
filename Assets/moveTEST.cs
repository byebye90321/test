using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class moveTEST : MonoBehaviour
{

    public float speed;
//    private bool movement = false;
    public GameObject ob;
    private Vector2 target;
    public Rigidbody2D rigid2D;
    private bool wolkk;
    //public GameManager gameManager;

	public void Start()
	{
		
		target = new Vector2(-6.67f,ob.transform.position.y);
	}

    void FixedUpdate()
    {
        walk();
    }

    public void OnTouch(BaseEventData bData)
    {
        target = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, ob.transform.position.y);

    }
    

    public void walk()
    {
        //rigid2D.MovePosition(Mathf.Lerp(transform.position.x, target.x, speed * Time.deltaTime));
        var dir = target - rigid2D.position;
        if(dir.x > 0.1f)
        {
            rigid2D.MovePosition(rigid2D.position + Vector2.right * speed * Time.deltaTime); //鋼體用MovePosition來移動 不要用transform
        }
        else if(dir.x < -0.1f)
        {
            rigid2D.MovePosition(rigid2D.position + Vector2.left * speed * Time.deltaTime);
        }
    }



    void OnTriggerEnter2D(Collider2D door)
    {
        if (door.gameObject.tag == "final")
        {
            win();
        }

    }
    public void win()
    {
        SceneManager.LoadScene(1);
    }
}



