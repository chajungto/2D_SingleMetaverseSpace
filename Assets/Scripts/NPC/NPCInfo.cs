using UnityEngine;

[CreateAssetMenu(fileName = "NPCInfo", menuName = "NPCInfo", order = int.MaxValue)]

public class NPCInfo : ScriptableObject
{
    //NPC 아이지
    [SerializeField]
    private int id;

    [SerializeField]
    public int ID { get { return id; } }

    //NPC 이름
    [SerializeField]
    private string npcName;

    [SerializeField]
    public string NpcName { get { return npcName; } }

    //NPC 명찰
    [SerializeField]
    private Sprite npcSprtie;

    [SerializeField]
    public Sprite NpcSprtie { get { return npcSprtie; } }

    //NPC 짧은 대사
    [SerializeField]
    private string npcScript;

    [SerializeField]
    public string NpcScript { get { return npcScript; } }

}
