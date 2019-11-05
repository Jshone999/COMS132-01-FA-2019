using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject Launch_Point;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public GameObject projectileLine;

    private Rigidbody projectileRigidbody;



    static public Vector3 LAUNCH_POS
    {
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }

    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("Launch_Point");
        Launch_Point = launchPointTrans.gameObject;
        Launch_Point.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        ///print("Slingshot:OnMouseEnter()");
        Launch_Point.SetActive(true);
    }

    void OnMouseExit()
    {
        ///print("Slingshot:OnMouseExit()");
        Launch_Point.SetActive(false);
    }

    void OnMouseDown()
    {
            aimingMode = true;
            projectile = Instantiate(projectile) as GameObject;
            projectile.transform.position = launchPos;
            projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!aimingMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;


        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            //projectile = null;
            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectile.GetComponentInChildren<Renderer>().material.color = Color.red;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.mass = 7;
            projectileLine.GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectile.GetComponentInChildren<Renderer>().material.color = Color.blue;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            projectileLine.GetComponentInChildren<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectile.GetComponentInChildren<Renderer>().material.color = Color.green;
            Transform rb = projectile.GetComponent<Transform>();
            Vector3 scale = new Vector3(5, 5, 5);
            rb.localScale = scale;
            projectileLine.GetComponentInChildren<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            projectile.GetComponentInChildren<Renderer>().material.color = Color.magenta;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.mass = 3;
            projectileLine.GetComponentInChildren<Renderer>().material.color = Color.magenta;
            
        }
    }

}
