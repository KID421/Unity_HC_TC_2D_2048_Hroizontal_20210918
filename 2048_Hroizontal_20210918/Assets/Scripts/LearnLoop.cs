using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    private void Start()
    {
        // ��X�Ʀr 1 ~ 5
        print("�Ʀr�G" + 1);
        print("�Ʀr�G" + 2);
        print("�Ʀr�G" + 3);
        print("�Ʀr�G" + 4);
        print("�Ʀr�G" + 5);

        // �j��G���ư���
        // while �j��y�k�G
        // while (���L��) { ���L�� ���� true �|���� ���򪽨쥬�L�Ȭ� false �{�����e }
        int number = 1;

        // �� �Ʀr �p�� 6 �|����...
        while (number < 6)
        {
            print("while �j��Ʀr�G" + number);
            number++;
        }

        // for (��l�ȡF���L�ȡF�j�鵲������{���ԭz)
        for (int x = 1; x < 6; x++)
        {
            print("for �j��Ʀr�G" + x);
        }
    }
}
