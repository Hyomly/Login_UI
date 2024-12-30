using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public struct sUserInfo
{
    public string m_name;
    public string m_email;
    public string m_id;
    public string m_password;

    public sUserInfo(string name, string email, string id, string password)
    {
        m_name = name;
        m_email = email;
        m_id = id;
        m_password = password;
    }
}

public class UserData : MonoBehaviour
{

    [SerializeField]
    TMP_InputField m_nameField;
    [SerializeField]
    TMP_InputField m_emailField;
    [SerializeField]
    TMP_InputField m_idField;
    [SerializeField]
    TMP_InputField m_passwordField;
    [SerializeField]
    TMP_InputField m_checkPWField;


    [SerializeField]
    GameObject m_popup;
    [SerializeField]
    TMP_Text m_popupText;

    [SerializeField]
    TMP_Text m_checkPwText;
    

    [SerializeField]
    UIManager m_uiManager;
    

    string m_name;
    string m_email;
    string m_id;
    string m_password;
    string m_checkPW;
    bool m_checkID = false;

    List<sUserInfo> m_users = new List<sUserInfo>();

    public  List<sUserInfo> Users => m_users;


    //회원 정보 얻기
    public void GetInfo() 
    {
        m_name = m_nameField.text;
        m_email = m_emailField.text;
        m_id = m_idField.text;
        m_password = m_passwordField.text;

        m_users.Add(new sUserInfo(m_name, m_email, m_id, m_password));

        for (int i = 0; i < m_users.Count; i++)
            Debug.Log("회원정보 \nname : " + m_users[i].m_name + " / email : " + m_users[i].m_email + " / id : " + m_users[i].m_id + " / password : " + m_users[i].m_password);

    }

    //ID 중복 확인버튼
    public void CheckingID_Button()
    {

        m_popup.SetActive(true);
        if (m_users.Count == 0 )
        {
            m_popupText.text = "You can use it";
            m_checkID = true;
        }
        for (int i = 0; i < m_users.Count; i++)
        {
            if (m_idField.text == m_users[i].m_id && m_idField.text != "")
            {
                m_popupText.text = "This ID already in use";                
                m_checkID = false;
            }
            else
            {
                m_popupText.text = "You can use it";
                m_checkID = true;
            }
        }
    }

    //ID 중복확인 OK버튼
    public void OKButton()
    {
        m_popup.SetActive(false);
    }

    //Password 확인하기
    public void CheckingPW()
    {
        if (m_checkPWField.text != m_passwordField.text)
        {
            m_checkPwText.gameObject.SetActive(true);
        }
        else
        {
            m_checkPwText.gameObject.SetActive(false);
        }    
        
    }

    //Field 값 지우기
    public void ClearField()
    {
        m_nameField.text = null;
        m_emailField.text = null;
        m_idField.text = null;
        m_passwordField.text = null;
        m_checkPWField.text = null;

    }
    

    //제출하기
    public void Submit()
    {
        if (m_nameField.text != "" && m_emailField.text != ""
            && m_idField.text != "" && m_passwordField.text != "" && m_checkPWField.text != "")
        {
            if (m_checkID == true)
            {
                if (m_checkPWField.text == m_passwordField.text)
                {
                    m_popup.SetActive(false);
                    GetInfo();
                    m_uiManager.GoLoginPanel();
                    m_checkID = false;
                    ClearField();                    
                }
                else
                {
                    m_popupText.text = "Check For Password";
                    m_popup.SetActive(true);
                }
            }

            else
            {
                m_popupText.text = "Check For ID";
                m_popup.SetActive(true);
            }
        }
        else
        {
            m_popupText.text = "No value";
            m_popup.SetActive(true);
        }
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        m_name = m_nameField.GetComponent<TMP_InputField>().text;
        m_email = m_emailField.GetComponent<TMP_InputField>().text;
        m_id = m_idField.GetComponent<TMP_InputField>().text;
        m_password = m_passwordField.GetComponent<TMP_InputField>().text;
        m_checkPW = m_checkPWField.GetComponent<TMP_InputField>().text;

        m_popup.SetActive(false);
        m_checkPwText.gameObject.SetActive(false);
    }

    
}
