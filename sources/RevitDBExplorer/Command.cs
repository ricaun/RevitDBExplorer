using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitDBExplorer.Augmentations;
using RevitDBExplorer.Domain.Selectors;
using System.Windows.Interop;

namespace RevitDBExplorer
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            BoundingBoxVisualizerFactory.Init(commandData.Application);

            Application.UIApplication = commandData.Application;
            var source = SelectorFactory.Create(Selector.CurrentSelection);
            source.ReadFromTheSource(commandData.Application);
            var window = new MainWindow(source);
            Application.DefaultFontFamily = window.FontFamily;
            new WindowInteropHelper(window).Owner = commandData.Application.MainWindowHandle;
            window.Show();

            return Result.Succeeded;
        }
    }

    public class ExternalCommandAvailability : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            return true;
        }
    }
}