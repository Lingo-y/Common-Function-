using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    //不设置层的话射线会被cube挡住，或者可以将cube的碰撞体关掉
    public LayerMask planeLayer;
    public GameObject tree;
    void Update()
    {
        //将鼠标的位置信息从屏幕坐标系转换到ray类型；ray就是从屏幕到鼠标位置的射线
        //这里操作的是cube中心点的位置，可以设置一个空物体，将两个物体归零，然后cube设为空物体的子物体，并将cube向上移动0.5个单位，脚本给空物体，这样操作的就是cube的底部中心点
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Mathf.Infinity无限长
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity,planeLayer)) {
            tree.transform.position = hitInfo.point;
            tree.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal); //初始为向上，旋转到接触平面的法向量
        }

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(tree, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        }
    }
}
