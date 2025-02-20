using UnityEngine;

[CreateAssetMenu(fileName = "NPCInfo", menuName = "NPCInfo", order = int.MaxValue)]

public class NPCInfo : ScriptableObject
{
    [SerializeField]                                            //NPC ���̵�
    private int id;

    [SerializeField]
    public int ID { get { return id; } }


    [SerializeField]
    private string npcName;                                     //NPC �̸�

    [SerializeField]
    public string NpcName { get { return npcName; } }

    
    [SerializeField]                                            //NPC ����
    private Sprite npcSprtie;

    [SerializeField]
    public Sprite NpcSprtie { get { return npcSprtie; } }
}
