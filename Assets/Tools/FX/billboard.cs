using UnityEngine;
public class billboard : MonoBehaviour
{
    private static float updateTime = 0.1f;
    private float time = 0.0f;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
    void Update() 
    {
        //time += Time.deltaTime;
        //if(time>updateTime)
        {
            //time = 0.0f;
            //for performance update fixed time

            Camera c = Camera.main;
            if (c != null) transform.LookAt(c.transform.position);

        }
	}
}
