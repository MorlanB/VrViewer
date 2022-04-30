using UnityEngine;

public class TransformTarget : MonoBehaviour
{
    private bool inTransformMode = false;
    private bool inTranslateMode = false;

    public Transform leftController;
    public Transform rightController;

    public Transform target;

    public Transform controllerTracker;

    private bool rightTrackerIsPressed;
    private bool leftTrackerIsPressed;

    private Vector3 initialTrackerDir;
    private Vector3 angularDifference;
    private Vector3 targetsInitRot;

    private Vector3 initialPosOffset;

    private Vector3 initScale;
    private float initControllersDistance;
    private float controllersDistanceDiff;

    GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        rightTrackerIsPressed = gm.rightTracker;
        leftTrackerIsPressed = gm.leftTracker;

        #region Enter Transform Mode
        if (rightTrackerIsPressed && leftTrackerIsPressed)
        {
            if (!inTransformMode)
            {
                enterTransformMode();
            }
        }
        else if (inTransformMode)
        {
            inTransformMode = false;
        }
        #endregion


        #region Enter Translate Mode
        if (rightTrackerIsPressed != leftTrackerIsPressed)
        {
            if (!inTranslateMode)
            {
                enterTransalateMode(rightTrackerIsPressed);
            }
        }
        else if (inTranslateMode)
        {
            inTranslateMode = false;
        }
        #endregion


        // Move or Transform if conditions are met
        if (inTranslateMode)
        {
            MoveTarget(rightTrackerIsPressed);
        }
        else if (inTransformMode)
        {
            ScaleTarget();
            RotateTarget();
        }
    }

    void enterTransformMode()
    {
        inTransformMode = true;

        //Scale
        initScale = target.localScale;
        initControllersDistance = Vector3.Distance(leftController.position, rightController.position);


        //Rotation
        initialTrackerDir = controllerTracker.rotation.eulerAngles;
        targetsInitRot = target.transform.rotation.eulerAngles;
    }

    void enterTransalateMode(bool rightTrigger)
    {
        inTranslateMode = true;

        //Position
        if (rightTrigger)
            initialPosOffset = target.position - rightController.position;
        else
            initialPosOffset = target.position - leftController.position;

    }


    //TranslateMode
    public void MoveTarget(bool rightTrigger)
    {
        if (rightTrigger)
            target.position = rightController.transform.position + initialPosOffset;
        else
            target.position = leftController.transform.position + initialPosOffset;
    }

    //TransformMode
    public void ScaleTarget()
    {
        float updatingControllersDistance = Vector3.Distance(leftController.position, rightController.position);
        controllersDistanceDiff = updatingControllersDistance / initControllersDistance;
        target.localScale = initScale * controllersDistanceDiff;
    }

    public void RotateTarget()
    {
        angularDifference = initialTrackerDir - controllerTracker.transform.rotation.eulerAngles;
        target.eulerAngles = targetsInitRot - angularDifference;
    }
}
