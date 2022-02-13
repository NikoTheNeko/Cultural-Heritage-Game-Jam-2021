using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    #region Public Variables
    [Header("Target to Track")]
    [Tooltip("This is the target the camera will track.")]
    public Transform targetToTrack;

    [Header("Camera tuning")]

    [Tooltip("This control smoothness of the camera. Set between 0 and 1. \n Default is 0.5f")]
    [Range(0.0f, 1.0f)]
    public float cameraSmoothness = 0.5f;

    [Tooltip("This is the camera offset for the X Axis.")]
    public float cameraOffsetX = 0.0f;
    [Tooltip("This is the camera offset for the Y Axis.")]
    public float cameraOffsetY = 0.0f;

    [Tooltip("This will lock the X Axis movement for the Camera")]
    public bool lockXAxis = false;
    [Tooltip("This will lock the y Axis movement fo the Camera.")]
    public bool lockYAxis = false;

    #endregion  


    //Runs the Track Target thing
    //Has to run on FixedUpdate not sure why
    //Brackeys doesn't know either
    private void FixedUpdate()
    {
        TrackTarget();
    }

    /**
        Track Target tracks a singular target that is set in the inspector.
        This is the main function of the script and probably will be the only function.
        It uses the lerp function to just follow the player with stuff like
        offsets implemented and so forth
    **/
    private void TrackTarget()
    {
        //Creates a vector to track the player. This gets the player's (or at least one of them) position and then offsets by a bit.
        //Offset is necessary due to how unity works. If it's not offset on the Z axis it'll like zyoom on in the player making them invisible
        Vector3 targetPos = new Vector3(targetToTrack.position.x + cameraOffsetX, targetToTrack.position.y + cameraOffsetY, -10);

        //This will "Lock" the axis. This makes it so taht the axis of the camera will stay still. This is done by just leaving the current
        //Camera position as the value. Note, don't lock both of the axis you won't MOVE. Unless this is intentional. Wait sheeesh i have ideas
        if(lockXAxis)
            targetPos.x = transform.position.x;
        if(lockYAxis)
            targetPos.y = transform.position.y;

        //This will also (mainly for my readibility sake) get the current position of the camera
        //Then assign it to CurrentPos
        //This doesn't *NEED* to be done, again this is just done for readability's sake it helps my tiny little pea brain.
        Vector3 currentPos = transform.position;

        //This now gets a "new position" this is the lerp done with the camera's current position, target, and the camera smoothness
        Vector3 newPos = Vector3.Lerp(currentPos, targetPos, cameraSmoothness);

        //Sets camera's pos to the new pos so it schmooves nicely.
        transform.position = newPos;
    }
}
