using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;
    public int score = 99;

    // �}�l
    private void Start()
    {
        // �P�_�� if else
        // �y�k
        // �p�G (���L��) { ���L�� ���� true �|���� �@�� �{�����e }
        // �_�h { ���L�� ���� false �|���� �{�����e }
        if (true)
        {
            print("���L�� true");
        }
        if (false)
        {
            print("���L�� false");
        }

        // openDoor == ture �P openDoor
        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
    }

    // ��s�G�@���������Q�� 60FPS
    private void Update()
    {
        // �p�G���� >= 60 �� �ή�
        if (score >= 60)
        {
            print("�ή�");
        }
        // �p�G���� >= 40 �� �ɦ�
        // �y�k�Gelse if (���L��) { ���L�� �� true �ɰ��� }
        // else if ��b if �U��P else �W��A�i�H�L����
        else if (score >= 40)
        {
            print("�ɦ�");
        }
        // �p�G���� < 40 �� ����
        else
        {
            print("����");
        }
    }
}
