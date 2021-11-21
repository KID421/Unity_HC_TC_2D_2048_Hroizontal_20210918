using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// �{�ѤG���}�C
/// </summary>
public class Learn2DArray : MonoBehaviour
{
    // �@���}�C
    public int[] numbers = { 1, 7, 9, 10, 50 };
    // �G���}�C�G���|��� - �ˮM�� Odin �ۤv�g Editor
    public int[,] blocks = { { 2, 4 }, { 6, 8 } };

    public string[,] objects = new string[4, 6];

    public int[,] scores = { { 70, 90 }, { 77, 30 }, { 10, 20 } };

    private void Start()
    {
        // �@���}�C�s��
        numbers[4] = 99;
        print("�@���}�C�Ĥ�����ơG" + numbers[4]);

        // �G���}�C�s��
        print("�G���}�C�ĤG�C�Ĥ@�� 1, 0�G" + blocks[1, 0]);
        blocks[1, 0] = 7;
        print("�G���}�C�ĤG�C�Ĥ@�� 1, 0�G" + blocks[1, 0]);

        print("�G���}�C�Ĥ@���ת��סG" + scores.GetLength(0));
        print("�G���}�C�ĤG���ת��סG" + scores.GetLength(1));

        string result = "";

        for (int i = 0; i < scores.GetLength(0); i++)
        {
            for (int j = 0; j < scores.GetLength(1); j++)
            {
                result += scores[i, j] + " | ";
            }

            result += "\n";
        }

        print(result);
    }
}
