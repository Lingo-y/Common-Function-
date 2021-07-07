using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRay : MonoBehaviour
{
    public Ray ray;
    [SerializeField]
    private float maxDistance=100;
    RaycastHit hitInfo;
    RaycastHit[] hits;
    public LayerMask mask;
    public Material highlightMat;
    private void Update()
    {
        //transform.forward为物体自身z轴朝向，会随物体旋转改变，Vector3.forward为固定的世界空间z轴
        ray = new Ray(transform.position, transform.forward);
        //if (Physics.Raycast(ray, out hitInfo, maxDistance, mask, QueryTriggerInteraction.Ignore))
        //{
        //    Debug.Log(hitInfo.collider.gameObject.name);
        //    Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        //}
        //else {
        //    Debug.DrawLine(transform.position, transform.position+ transform.forward*100, Color.yellow);
        //}
        //RaycastAll返回值不再是布尓值，要存入hits數組
        hits = Physics.RaycastAll(ray,maxDistance,mask);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.red);
        foreach (RaycastHit hit in hits)
            hit.collider.gameObject.GetComponent<Renderer>().material = highlightMat;              
    }
}
