using FellowOakDicom;
using FellowOakDicom.Imaging;
using FellowOakDicom.Printing;

namespace DICOMViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new DicomSetupBuilder()
               .RegisterServices(s => s.AddFellowOakDicom()
               .AddImageManager<WinFormsImageManager>())
               .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Presentation.View.Main());
        }
    }
}