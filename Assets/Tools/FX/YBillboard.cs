using UnityEngine;
using System.Collections;

public class YBillboard : MonoBehaviour {

    private Transform cacheTrans = null;
    private Transform cacheCameraTrans = null;
    public static bool IsUpdate = false;
	// Use this for initialization
	void Awake () {
        cacheTrans = this.transform;
        if (Camera.main != null)
            cacheCameraTrans = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (IsUpdate && cacheCameraTrans != null)
        {
            Vector3 eularAngle = cacheTrans.rotation.eulerAngles;
            Vector3 cameraEularAngle = cacheCameraTrans.rotation.eulerAngles;
            cacheCameraTrans.rotation = Quaternion.Euler(cameraEularAngle.x, cameraEularAngle.y, eularAngle.z);
	    }
	}
}
