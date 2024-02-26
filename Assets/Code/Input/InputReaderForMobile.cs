using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using System;
using static HedgehogTeam.EasyTouch.QuickDrag;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="MobileInputReader", menuName = "Game/Mobile InputReader")]
public class InputReaderForMobile : DescriptionBaseSO
{

    public UnityAction<Vector3> OnMoveEvent;


    private void OnEnable()
    {
        EasyTouch.On_DoubleTap += OnDoubleTap;

        EasyTouch.On_SimpleTap += OnSimpleTap;

        EasyTouch.On_Drag += OnDrag;

        EasyTouch.On_DragStart += OnDragStart;
    }


    private void OnDisable()
    {
        EasyTouch.On_DoubleTap -= OnDoubleTap;

        EasyTouch.On_SimpleTap -= OnSimpleTap;

        EasyTouch.On_Drag -= OnDrag;

        EasyTouch.On_DragStart -= OnDragStart;
    }

    private void OnDragStart(Gesture gesture)
    {
   
    }

    private void OnDrag(Gesture gesture)
    {

    }

    private void OnSimpleTap(Gesture gesture)
    {
        // 获取鼠标点击的屏幕坐标
        Vector3 mousePosition = gesture.position;

        // 使用摄像机将屏幕坐标转换为射线
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 获取点击位置的3D坐标
            Vector3 worldPosition = hit.point;

            OnMoveEvent.Invoke(worldPosition);
        }
    }

    private void OnDoubleTap(Gesture gesture)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
