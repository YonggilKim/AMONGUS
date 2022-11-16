using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button MounseCtrlButton;
    [SerializeField] private Button keyboardMounseCtrlButton;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MounseCtrlButton.image.color = Color.green;
                keyboardMounseCtrlButton.image.color = Color.white;
                break;
            case EControlType.keyboardMouse:

                MounseCtrlButton.image.color = Color.white;
                keyboardMounseCtrlButton.image.color = Color.green;
                break;
        }
    }
    public void SetControlMode(int ctrlType)
    {
        PlayerSettings.controlType = (EControlType)ctrlType;
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MounseCtrlButton.image.color = Color.green;
                keyboardMounseCtrlButton.image.color = Color.white;
                break;
            case EControlType.keyboardMouse:

                MounseCtrlButton.image.color = Color.white;
                keyboardMounseCtrlButton.image.color = Color.green;
                break;
        }
    }    
    public virtual void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }
    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
