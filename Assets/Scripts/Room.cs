using DG.Tweening;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] bool isDirty;
    [SerializeField] bool isRight;
    [SerializeField] string roomName;
    [SerializeField] Transform centerPoint;
    [SerializeField] MeshRenderer roomRenderer;

    public bool IsDirty { get => isDirty; set => isDirty = value; }
    public bool IsRight { get => isRight; set => isRight = value; }
    public string RoomName { get => roomName; set => roomName = value; }
    public Transform CenterPoint { get => centerPoint; set => centerPoint = value; }

    public void CleanTheRoom()
    {
        IsDirty = false;
        roomRenderer.sharedMaterial.DOFade(0, 1);
    }

    public void MakeItDirty()
    {
        IsDirty = true;
        roomRenderer.sharedMaterial.DOFade(1,0);
    }

    public void CleanInstant()
    {
        IsDirty = false;
        roomRenderer.sharedMaterial.DOFade(0, 0);
    }
}
