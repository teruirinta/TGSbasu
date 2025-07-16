using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        // ボタンチェック（A, B, X, Yなど）
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Pressed joystick button: " + i);
            }
        }

        // 軸チェック（スティックやD-Pad）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            Debug.Log($"Axis - Horizontal: {horizontal}, Vertical: {vertical}");
        }

        // D-Pad専用軸（コントローラーによって異なる）
        float dpadX = Input.GetAxis("DPadX"); // Input Managerに定義が必要
        float dpadY = Input.GetAxis("DPadY");

        if (Mathf.Abs(dpadX) > 0.1f || Mathf.Abs(dpadY) > 0.1f)
        {
            Debug.Log($"DPad - X: {dpadX}, Y: {dpadY}");
        }
    }


}
