using UnityEngine;

[ExecuteInEditMode]
public class SnapEditor : MonoBehaviour
{
#if UNITY_EDITOR
    void Update()
    {
        if (transform.position.x < 0f)
        {
            Vector3 position = transform.position;
            position.x = 0f;
            transform.position = position;
        }

        if (transform.position.z < 0f)
        {
            Vector3 position = transform.position;
            position.z = 0f;
            transform.position = position;
        }

        Mathf.Round(5.5f);
    }

#endif
}
