using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float scrollData;
    private Camera cam;

    private float targetZoom;
    private Vector3 vecZero = new Vector3(0, 0, 10);
    Vector3 screenToWorldCube;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float camTransformLerpSpeed;
    private Vector3 targetPosition;
    private Vector3 mouseOffSet;

    [SerializeField] float viewPortFactor;
    [SerializeField] private float camLerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = 7.5f;
        targetPosition = playerTransform.position - vecZero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region camera Zoom
        scrollData = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scrollData != 0)
        {
            targetZoom -= 3f * scrollData;
        }
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 8f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * camLerpSpeed);
        #endregion

        screenToWorldCube = (cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10)) - cam.ScreenToWorldPoint(vecZero)) * viewPortFactor;

        #region camera player follow
        Vector2 playerDistance = new Vector2(Mathf.Abs(playerTransform.position.x - transform.position.x),
            Mathf.Abs(playerTransform.position.y - transform.position.y));
        Vector2 playerDistanceSign = new Vector2(Mathf.Sign(playerTransform.position.x - transform.position.x),
            Mathf.Sign(playerTransform.position.y - transform.position.y));

        if (playerDistance.x > screenToWorldCube.x * .5f)
        {
            targetPosition.x = playerTransform.position.x - (screenToWorldCube.x * playerDistanceSign.x * .5f);
        }
        if (playerDistance.y > screenToWorldCube.y * .5f)
        {
            targetPosition.y = playerTransform.position.y - (screenToWorldCube.y * playerDistanceSign.y * .5f);
        }
        #endregion

        #region mouse follow
        mouseOffSet = (cam.ScreenToWorldPoint(Input.mousePosition - vecZero) - transform.position).normalized;
        #endregion

        transform.position = Vector3.Lerp(transform.position, targetPosition + mouseOffSet, Time.deltaTime * camTransformLerpSpeed);
    }


    void OnDrawGizmos()
    {
        Color c = Color.green;
        c.a = .25f;
        Gizmos.color = c;
        Gizmos.DrawCube(transform.position, screenToWorldCube);
    }
}