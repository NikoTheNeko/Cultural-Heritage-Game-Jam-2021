using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [Header("Target to Track")]
    public Transform targetToTrack;

    [Header("Camera tuning")]
    public float cameraSmoothness = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrackTarget();
    }

    /**
    **/
    private void TrackTarget()
    {
        Vector3 targetPos = new Vector3(0, targetToTrack.position.y, -10);
        Vector3 currentPos = transform.position;
        Vector3 newPos = Vector3.Lerp(currentPos, targetPos, cameraSmoothness);
        transform.position = newPos;
    }
}
