using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField]
    TMP_InputField m_idField;
    [SerializeField]
    TMP_InputField m_pwField;
    
    [SerializeField]
    TMP_Text m_resultText;

    [SerializeField]
    GameObject m_resultPanel;

    [SerializeField]
    UserData m_data;

    void LoginCheck()
    {
        var data = m_data.Users;
        if(data.Count == 0)
            m_resultText.text = "no information";
        for (int i = 0; i< data.Count; i++) 
        {
            if (m_idField.text == data[i].m_id && m_pwField.text == data[i].m_password)
            {
                m_resultText.text = "Welcome! " + data[i].m_name;

            }
            else
            {
                m_resultText.text = "Login failed";
            }

        }
        
    }
    public void ClearField()
    {
        m_pwField.text = null;
        m_idField.text = null;
    }
    public void OnClickLogin()
    {
        m_resultPanel.SetActive(true);
        LoginCheck();
        
    }

}
