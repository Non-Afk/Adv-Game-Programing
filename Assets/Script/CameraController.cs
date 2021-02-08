using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Vector2 Margin;
    public Vector2 smoothing;
    public BoxCollider2D Bounds;
    private Vector3 _min;
    private Vector3 _max;
    public bool IsFollowing { get; set; }

    void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFollowing = true;
    }

    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        if (IsFollowing)
        {
            if (Mathf.Abs(x - player.position.x) > Margin.x)
            {//如果相机与角色的x轴距离超过了最大范围则将x平滑的移动到目标点的x
                x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
            }
        }
        float orthographicSize = GetComponent<Camera>().orthographicSize;//orthographicSize代表相机(或者称为游戏视窗)竖直方向一半的范围大小,且不随屏幕分辨率变化(水平方向会变)
        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);//的到视窗水平方向一半的大小
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);//限定x值
        transform.position = new Vector3(x, y, transform.position.z);//改变相机的位置
    }
}
