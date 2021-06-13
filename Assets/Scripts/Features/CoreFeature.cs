using UnityEngine;
using MVCF.Controllers;
using MVCF.Views;
using MVCF.Models;

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
        new MouseTestController(LeftMouseView, RightMouseView, new TestValueModel());
        new EmptyTestController();
    }
}
