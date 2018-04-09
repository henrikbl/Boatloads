using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject camTarget;
    public float rotateSpeed = .5f;
    public Vector3 TargetPosition;
    public Vector3 resetPos;


    void Start()
    {
        resetPos = transform.localPosition;
        transform.LookAt(TargetPosition);
    }

	// Update is called once per frame
	void Update () {
        TargetPosition = camTarget.transform.position;
        transform.LookAt(TargetPosition);

        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(TargetPosition, new Vector3(0.0f, 1.0f, 0.0f), 20 * Input.GetAxis("Mouse X") * rotateSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, resetPos, 5f * Time.deltaTime);
        }
	}
}
