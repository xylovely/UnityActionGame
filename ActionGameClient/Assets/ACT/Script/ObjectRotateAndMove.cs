using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateAndMove : MonoBehaviour {

    [Header("是否开启自转")]
    public bool isRotateSelf = false;
    
    [Header("定义自转的速度")]
    public float _RotationSpeed = 0.1f; //定义自转的速度

    [Header("是否开启公转")]
    public bool isRotateAround = false;

    [Header("物体需要公转的参照物")]
    public GameObject Axis; //物体需要公转的参照物

    [Header("公转速度")]
    public float _PublicRotationSpeed = 0.1f; //公转速度

    [Header("是否开启上下浮动")]
    public bool isUpDown = false;

    [Header("上下移动速度")]
    public float upDownSpeed = 1f;

    [Header("向上移动的范围")]
    public float upArea = 5f;

    [Header("向下移动的范围")]
    public float downArea = -5f;

    private bool upOrDown = true;

    private Vector3 oriPosition;
    // Use this for initialization
    void Start () {
        oriPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (isRotateSelf)
        {
            transform.Rotate(Vector3.down * _RotationSpeed, Space.World); //物体自转
        }
        

        if (isUpDown)
        {
            if (transform.position.y >= oriPosition.y + upArea)
            {
                upOrDown = false;
                
            }
            else if (transform.position.y <= oriPosition.y + downArea)
            {
                upOrDown = true;
                
            }
            if (upOrDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        }

        if (isRotateAround)
        {
            transform.RotateAround(Axis.transform.position, Vector3.up, _PublicRotationSpeed);//将需要公转的参照物拖入，设置公转
        }
        
    }
}
