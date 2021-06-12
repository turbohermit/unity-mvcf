using UnityEngine;
using MVCF.Controllers;
using MVCF.Views;

public class CoreFeature : MonoBehaviour
{
    public LeftMouseView LeftMouseView;
    public RightMouseView RightMouseView;

    private void Start()
    {
        CreateControllers();
    }

    private void CreateControllers()
    {
        new MouseTestController(LeftMouseView, RightMouseView);
        new EmptyTestController();
    }
}
