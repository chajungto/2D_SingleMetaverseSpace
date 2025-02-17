using UnityEngine;

[CreateAssetMenu(fileName = "NPCInfo", menuName = "NPCInfo", order = int.MaxValue)]

public class NPCInfo : ScriptableObject
{
    //NPC ������
    [SerializeField]
    private int id;

    [SerializeField]
    public int ID { get { return id; } }

    //NPC �̸�
    [SerializeField]
    private string npcName;

    [SerializeField]
    public string NpcName { get { return npcName; } }

    //NPC ����
    [SerializeField]
    private Sprite npcSprtie;

    [SerializeField]
    public Sprite NpcSprtie { get { return npcSprtie; } }

    //NPC ª�� ���
    [SerializeField]
    private string npcScript;

    [SerializeField]
    public string NpcScript { get { return npcScript; } }

}
