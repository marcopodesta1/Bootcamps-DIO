namespace DICOMViewer.Domain.Interfaces

{
    public interface IMain
    {
        PictureBox pbImage { get; }
        Size ImageAreaSize { get; }
        void ResetControls();
        void ShowImage(Bitmap bmp);
        void SetLoadingState(bool isLoading);
        void SetSavingState(bool isSaving);
        void SetTrackbar(int max);
        void SetTrackbarValue(int index);
        void UI(Action action);
        void UpdateExamCounter(int index, int total);
        void UpdateLoadCounter(int index, int total);
        //void UpdateSaveProgress(int value, int max);
        public void UpdateProgressBar(int index, int total);

    }
}
