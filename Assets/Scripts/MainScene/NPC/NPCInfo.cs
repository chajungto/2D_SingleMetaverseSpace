using UnityEngine;

[CreateAssetMenu(fileName = "NPCInfo", menuName = "NPCInfo", order = int.MaxValue)]

public class NPCInfo : ScriptableObject
{
    [SerializeField]                                            //NPC 아이디
    private int id;

    [SerializeField]
    public int ID { get { return id; } }


    [SerializeField]
    private string npcName;                                     //NPC 이름

    [SerializeField]
    public string NpcName { get { return npcName; } }

    
    [SerializeField]                                            //NPC 명찰
    private Sprite npcSprtie;

    [SerializeField]
    public Sprite NpcSprtie { get { return npcSprtie; } }
}
