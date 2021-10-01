using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public TMP_Text versionText;
    void Start()
    {
        versionText.text = "V" + Application.version;
    }
}
