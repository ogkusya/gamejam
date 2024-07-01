using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private List<KeyValuePair<string, string>> Dialog1Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("�������", "����� �� ����, ������? ����� �� ����, �������?"),
        new KeyValuePair<string, string>("���������", "�����, �����, ���������!"),
        new KeyValuePair<string, string>("�������", "��� �� ��, �����, � ���� ����-����������� �������?"),
        new KeyValuePair<string, string>("���������", "��� � ������ �����. ����� ����, ��� ��� ��� ������ ���� ����."),
        new KeyValuePair<string, string>("�������", "������ � ����, ������ ����, �� ������ ���� ��������� ������ ���������. ������ �� �� �� ������� ������, ����������� ������ ��������?"),
        new KeyValuePair<string, string>("���������", "����, �������, ����."),
        new KeyValuePair<string, string>("�������", "�������� �� �� �������, ������ ���� ���� � ��������� ����. ���� ���������� � ������� ������ ��������."),
        new KeyValuePair<string, string>("���������", "����� � ���� ���������, ���������. ���������� �� �������� ����.")
    };

    private List<KeyValuePair<string, string>> Dialog2Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("���������", "��� � � �� �������, ���������. ���� ��������� ����������."),
        new KeyValuePair<string, string>("�������", "����, ������ �� � ���� ��������� ����������. ��� ���� ��� ������� � ������� ������. � ��� ���� � ���� ����� ����� ������������."),
        new KeyValuePair <string, string>("���������", "��������� ����, �������. ���� ��� ����� � ������� ��������."),
        new KeyValuePair <string, string>("", "������� \"SPACE\" ������ ��� �������� ������. � ��� ������� ����� ������� ����."),
        new KeyValuePair <string, string>("�������", "������ ��, ���������, �������. ��������� ������ � ������ ������. ������ ���� � �������� ���� ��������� �������. ������ ���� ����� � �������� ���, ������ ������� ����, �������� � �����������."),
        new KeyValuePair <string, string>("���������", "������, ���������. ������ �, ���� ���� � ����� ������� ����."),
        new KeyValuePair <string, string>("�������", "���� ������ �����, ������. ����������� ����� � ������� ���� ���������.")
    };

    private List<KeyValuePair<string, string>> Dialog3Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("���������", "��� � � � �������� ���, ���������. ������� ���� ����������, ���� ��� ���� �������."),
        new KeyValuePair<string, string>("�������", "������, ������. ��� ��� ��� � �����. � ��� �� ������� ���� �������� ��������."),
        new KeyValuePair <string, string>("���������", "�������, �������. ����� � �������������� ���� ������ ���."),
        new KeyValuePair <string, string>("", "������� \"SHIFT\" ��� ����� ������. � ��� ������� ����� �������� ������ �� ����� ���������."),
        new KeyValuePair <string, string>("�������", "�����, �������� ���������, ���������� �� �� �������� �������. ��������� ��������� � ��� ���� ����������. �������� �� ������� ����� �������  ����, �� ������� ��� ��� �����, ��� ��� ��������."),
        new KeyValuePair <string, string>("���������", "�����, ���������. ����� ���� ����� � �������.")
    };

    private List<KeyValuePair<string, string>> Dialog4Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("���������", "���������� � � ��������� ����� ����������, ���������. �������� ���� ����� � ����� ������� ����� ������� ����."),
        new KeyValuePair<string, string>("�������", "�������, ���������, ���������� �� ��� �������� � � ��������, � ������. ������ ��� ���� �����. ������ �, ��� ������������ ��� �� ������ � ���� � �� ��������������."),
        new KeyValuePair <string, string>("���������", "��������� ����, �������, �� ����� ������ �������."),
        new KeyValuePair <string, string>("", "������� \"LMB\" ��� ���������� ����� �������. Ѡ��� ������� ����� ��������� ������������� ����������."),
        new KeyValuePair <string, string>("�������", "����� ���� ������� ���� ���������� � ���������, �� ����� �������� ��� ������ ����, � ������ ���� ��� �� ������� ���������� ��������. ����� � ����� �������� ����� ���� ������, ��� �� ������ ������������."),
        new KeyValuePair <string, string>("���������", "������� ���� �� ���, ���������, �� ������� � ���� ����. ����� � �������� ���� ��� �� ��������� � ��������."),
        new KeyValuePair <string, string>("", "�� ��� ��� ������ ������ �������...")
    };

    //[SerializeField] private GameObject mainCharacter;
    //[SerializeField] private CharacterStateMachine mainCharacterSM;

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text mainText;
    [SerializeField] private TMP_Text nameCharacter;
    [SerializeField] private Image imageNastya;
    [SerializeField] private Image imageMoroz;
    [SerializeField] private Image imageDefault;

    private bool _isUseDialog = false;
    private List<KeyValuePair<string, string>> _currentDialog = null;

    private int _currentIndex = -1;
    private int _newIndex = -1;

    private bool _isWasDialog2 = false;
    private bool _isWasDialog3 = false;

    private void Start()
    {
        StartDialog(Dialog1Dict);
    }

    private void Update()
    {
        if (_isUseDialog && _currentDialog != null && _newIndex == _currentIndex + 1 && _newIndex < _currentDialog.Count)
        {
            _currentIndex = _newIndex;

            string name = _currentDialog[_currentIndex].Key;
            nameCharacter.text = name;

            switch (name)
            {
                case "�������":
                    imageMoroz.enabled = true;
                    imageNastya.enabled = false;
                    imageDefault.enabled = false;
                    break;
                case "���������":
                    imageMoroz.enabled = false;
                    imageNastya.enabled = true;
                    imageDefault.enabled = false;
                    break;
                default:
                    imageMoroz.enabled = false;
                    imageNastya.enabled = false;
                    imageDefault.enabled = true;
                    break;
            }

            mainText.text = _currentDialog[_currentIndex].Value;
        }

        if (CharacterStateMachine.IsDoubleJumpExist && !_isWasDialog2)
        {
            StartDialog(Dialog2Dict);
            _isWasDialog2 = true;
        }

        if (CharacterStateMachine.IsDashExist && !_isWasDialog3)
        {
            StartDialog(Dialog3Dict);
            _isWasDialog3 = true;
        }
    }

    private void StartDialog(List<KeyValuePair<string, string>> dialog)
    {
        _currentDialog = dialog;
        _isUseDialog = true;
        _currentIndex = -1;
        _newIndex = 0;
        dialogPanel.SetActive(true);
    }

    public void ContinueDialog()
    {
        _newIndex++;

        if (_newIndex >= _currentDialog.Count)
        {
            dialogPanel.SetActive(false);
        }
    }
}
