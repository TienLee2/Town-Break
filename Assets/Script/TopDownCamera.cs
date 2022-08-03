using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;

        [System.Serializable]
    public class PositionSettings
    {
        public float distanceFromTarget;
        public bool allowZoom = true;
        public float zoomSmooth = 100;
        public float zoomStep = 2;
        public float maxZoom = -40;
        public float minZoom = -60;
        public bool smoothFollow = true;
        public float smooth = 0.05f;
        [HideInInspector]
        public float newDistance = -50;
    }
    

    [System.Serializable]
    public class OrbitSetting
    {
        public float xRotation = -65;
        public float yRotaion = -180;
        public bool allowOrbit = true;
        public float yOrbitSmooth = 0.5f;
    }

        [System.Serializable]
    public class InputSetting
    {
        public string MOUSE_ORBIT = "MouseOrbit";
        public string ZOOM = "MouseScrollWheel";
    }
    
    public PositionSettings position = new PositionSettings();
    public OrbitSetting orbit = new OrbitSetting();
    public InputSetting input = new InputSetting();
    
    Vector3 Destination = Vector3.zero;
    Vector3 camVelocity = Vector3.zero;

    Vector3 currentMousePosition = Vector3.zero;
    Vector3 previousMousePosition = Vector3.zero;
    float mouseOrbitInput, zoomInput;

    void Start()
    {
        SetCameraTarget(target);

        if(target)
        {
            MovetoTarget();
        }
    }
    public void SetCameraTarget(Transform t)
    {
        target = t;

        if(target == null)
        {
            Debug.LogError("target where?");
        }
    }
    void GetInput()
    {
        mouseOrbitInput = Input.GetAxisRaw(input.MOUSE_ORBIT);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
        
    }
    void Update()
    {
        GetInput();
        if(position.allowZoom)
        {
            ZoomInOnTarget();
        }
    }
    void FixedUpdate()
    {
        if(target)
        {
            MovetoTarget();
            LookAtTarget();
            MouseOrbitTarget();
        }
    }
    void MovetoTarget()
    {
        Destination = target.position;
        Destination += Quaternion.Euler(orbit.xRotation, orbit.yRotaion, 0) * -Vector3.forward * position.distanceFromTarget;

        if (position.smoothFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Destination, ref camVelocity, position.smooth);
        }
        else
            transform.position = Destination;
    }
    void LookAtTarget()
    {
        Quaternion targetRotaion = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = targetRotaion;
    }
    void MouseOrbitTarget()
    {

    }
    void ZoomInOnTarget()
    {

    }
    
    
}
