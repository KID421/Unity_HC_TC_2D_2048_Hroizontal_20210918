using UnityEngine;
using System.Linq;
using UnityEngine.UI;

/// <summary>
/// 2048 �t��
/// �x�s�C�Ӱ϶����
/// �޲z�H���ͦ�
/// �ưʱ���
/// �Ʀr�X�֧P�w
/// �C������P�w
/// </summary>
public class System2048 : MonoBehaviour
{
    [Header("�ťհ϶�")]
    public Transform[] blocksEmpty;
    [Header("�Ʀr�϶�")]
    public GameObject goNumberBlock;
    [Header("�e�� 2048")]
    public Transform traCanvas2048;

    // �p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    private Direction direction;
    private bool isClick;
    private Vector3 positionKeyDown;
    private Vector3 positionKeyUp;

    /// <summary>
    /// �Ҧ��϶����
    /// </summary>
    public BlockData[,] blocks = new BlockData[1, 4];

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckDirection();
    }

    /// <summary>
    /// ��l�Ƹ��
    /// </summary>
    private void Initialize()
    {
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                blocks[i, j] = new BlockData();
                blocks[i, j].v2Index = new Vector2Int(i, j);
                blocks[i, j].v2Position = blocksEmpty[i * blocks.GetLength(1) + j].position;
            }
        }

        PrintBlockData();
        CreateRandomNumberBlock();
        CreateRandomNumberBlock();
        CreateRandomNumberBlock();
    }

    /// <summary>
    /// ��X�϶��G���}�C���
    /// </summary>
    private void PrintBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                // �s���B�Ʀr�P�y��
                // result += "�s��" + blocks[i, j].v2Index + " <color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=yellow>" + blocks[i, j].v2Position + "</color> |";
                // �s���B�Ʀr�P����
                result += "�s��" + blocks[i, j].v2Index + " <color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=yellow>" + (blocks[i, j].goBlock ? "��" : "�@") + "</color> |";
            }

            result += "\n";
        }

        print(result);
    }

    /// <summary>
    /// �إ��H���Ʀr�϶�
    /// �P�_�Ҧ��϶����S���Ʀr���϶� - �Ʀr���s
    /// �H���D��@��
    /// �ͦ��Ʀr���Ӱ϶���
    /// </summary>
    private void CreateRandomNumberBlock()
    {
        var equalZero =
            from BlockData data in blocks
            where data.number == 0
            select data;

        print("���s����Ʀ��X���G" + equalZero.Count());

        int randomIndex = Random.Range(0, equalZero.Count());
        print("�H���s���G" + randomIndex);

        // ��X�H���϶� �s��
        BlockData select = equalZero.ToArray()[randomIndex];
        BlockData dataRandom = blocks[select.v2Index.x, select.v2Index.y];
        // �N�Ʀr 2 ��J���H���϶���
        dataRandom.number = 2;

        // ��Ҥ�-�ͦ�(����A������)
        GameObject tempBlock = Instantiate(goNumberBlock, traCanvas2048);
        // �ͦ��϶� ���w�y��
        tempBlock.transform.position = dataRandom.v2Position;
        // �x�s �ͦ��϶� ���
        dataRandom.goBlock = tempBlock;

        PrintBlockData();
    }

    /// <summary>
    /// �ˬd��V
    /// </summary>
    private void CheckDirection()
    {
        if (!isClick && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClick = true;
            positionKeyDown = Input.mousePosition;
        }
        else if (isClick && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClick = false;
            positionKeyUp = Input.mousePosition;

            Vector3 directionValue = positionKeyUp - positionKeyDown;
            Vector2 normalized = directionValue.normalized;

            if (Mathf.Abs(normalized.x) > Mathf.Abs(normalized.y)) direction = normalized.x > 0 ? Direction.Right : Direction.Left;
            else if (Mathf.Abs(normalized.y) > Mathf.Abs(normalized.x)) direction = normalized.y > 0 ? Direction.Up : Direction.Down;
            else direction = Direction.None;

            if (direction != Direction.None) MoveBlock();
        }
    }

    /// <summary>
    /// ���ʰ϶�
    /// </summary>
    private void MoveBlock()
    {
        BlockData blockMove = new BlockData();
        BlockData blockCheck = new BlockData();
        bool canMove = false;

        switch (direction)
        {
            case Direction.None:
                break;
            case Direction.Right:
                break;
            case Direction.Left:

                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < blocks.GetLength(1); j++)
                    {
                        if (blocks[i, j].number == 0) continue;

                        blockMove = blocks[i, j];

                        for (int k = j - 1; k >= 0; k--)
                        {

                            if (blocks[i, k].number == 0 || blocks[i, k].number == blockMove.number)
                            {
                                canMove = true;
                                blockCheck = blocks[i, k];
                            }
                            else if (blocks[i, k].number != 0 && blocks[i, k].number != blockMove.number) continue;
                        }

                        if (canMove) CanMoveAndMoveBlock(blockMove, blockCheck);

                        PrintBlockData();
                    }
                }

                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// �i�H���ʨò��ʰ϶�
    /// </summary>
    /// <param name="blockMove">�n���ʪ��϶�</param>
    /// <param name="blockCheck">�ˬd���϶�</param>
    private void CanMoveAndMoveBlock(BlockData blockMove, BlockData blockCheck)
    {
        blockMove.goBlock.transform.position = blockCheck.v2Position;

        if (blockCheck.number == blockMove.number)
        {
            int number = blockCheck.number + blockMove.number;
            blockCheck.number = number;
            blockCheck.goBlock.transform.Find("�Ʀr").GetComponent<Text>().text = number.ToString();
            blockMove.number = 0;
            Destroy(blockMove.goBlock);
            blockMove.goBlock = null;
        }
        else
        {
            blockCheck.number = blockMove.number;
            blockCheck.goBlock = blockMove.goBlock;
            blockMove.number = 0;
            blockMove.goBlock = null;
        }
    }
}

/// <summary>
/// �϶����
/// �C�Ӱ϶��C������B�y�СB�s���B�Ʀr
/// </summary>
public class BlockData
{
    /// <summary>
    /// �϶������Ʀr����
    /// </summary>
    public GameObject goBlock;
    /// <summary>
    /// �϶��y��
    /// </summary>
    public Vector2 v2Position;
    /// <summary>
    /// �϶��s���G�G���}�C�����s��
    /// </summary>
    public Vector2Int v2Index;
    /// <summary>
    /// �϶��Ʀr�G�w�]�� 0�A�Ϊ� 2�B4�B8....2048
    /// </summary>
    public int number;
}

/// <summary>
/// ��V�C�|�G�L�B�k�B���B�W�B�U
/// </summary>
public enum Direction
{
    None, Right, Left, Up, Down
}