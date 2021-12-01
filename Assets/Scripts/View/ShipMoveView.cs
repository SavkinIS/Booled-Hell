using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class ShipMoveView : MonoBehaviour
{

    [Tooltip("—корость по X")]
    [SerializeField] float moveX;
    [Tooltip("—корость вращение€")]
    [SerializeField] float rollSpeed;
    [Tooltip("”гол ¬ращени€")]
    [SerializeField] float rollAxis;
    [Tooltip("ƒиапазон отклонени€ по X")]
    [SerializeField] float rangeX;
    [Tooltip("‘актор отклонен€и по оси Y при перемещении")]
    [SerializeField] float factorY;

    float speed;
    
    float axisZ = 0;
    float _moveX = 0;

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Select(_ =>Input.GetAxis("Horizontal")).RepeatUntilDestroy(this).Subscribe(b=>Move(b));
    }
    void Move(float axis)
    {
        var axisY = axis * factorY;

        if (axis == 0)
        {
            axisZ = 0;
            _moveX = 0;
            axisY = transform.position.x / 100 * factorY;
        }
        else if (axis < 0)
        {
            axisZ = rollAxis;
            _moveX = -moveX;
        }
        else if (axis > 0) 
        {
            axisZ = -rollAxis;
            _moveX = moveX;
        }

        
        var rot = transform.localRotation;
        transform.DORotate(new Vector3(0, axisY, axisZ), rollSpeed);
        var xPos = transform.position.x + _moveX;
        if(xPos>-rangeX && xPos < rangeX)
        {
            transform.DOMoveX(xPos, speed);
        }
        

    }

    void OnDestroy()
    {
        DOTween.Clear(destroy: true);
    }

}
