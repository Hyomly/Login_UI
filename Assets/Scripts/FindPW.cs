using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindPW : MonoBehaviour
{
    [SerializeField]
    TMP_InputField m_id;
    [SerializeField]
    TMP_InputField m_name;
    [SerializeField]
    TMP_Text m_foundText;
    [SerializeField]
    TMP_Text m_text;
    [SerializeField]
    GameObject m_foundPanel;
    [SerializeField]
    UserData m_data;

    void PWCheck()
    {
        var data = m_data.Users;
        if (data.Count == 0)
        {
            m_text.text = "";
            m_foundText.text = "no information";
        }
        for (int i = 0; i < data.Count; i++)
        {
            if (m_id.text == data[i].m_id && m_name.text == data[i].m_name)
            {
                m_text.text = "Your Password";
                m_foundText.text = data[i].m_password;
                break;
            }
            else
            {
                m_text.text = "";
                m_foundText.text = "no information";

            }
        }

    }
    public void ClearField()
    {
        m_name.text = null;
        m_id.text = null;
    }
    public void OnClick_PW_OK()
    {
        m_foundPanel.SetActive(true);
        PWCheck();
        ClearField();
    }
}
