using System.Printing;
using DICOMViewer.Domain.Interfaces;
using DICOMViewer.Domain.Models;
using DICOMViewer.Domain.Servicos;
using DICOMViewer.Infrastructure;

namespace DICOMViewer.Presenter
{
    public class ImagePresenter
    {
        private readonly IMain _main;
        public ExamsCollection? _examsCollections;
        private readonly List<Bitmap> _images = new();
        public CancellationTokenSource? _cts;
        private int _total = 0;
        private int _resolution = 0;

        public ImagePresenter(IMain view)
        {
            _main = view;
        }

        public async Task OpenAsync(string path, int resolution)
        {
            _resolution = resolution;
            _main.ResetControls();
            await GetExamsSeparatedAsync(path, resolution).ConfigureAwait(false);
            if (_examsCollections != null && _examsCollections.Exams.Count > 0)
                await LoadImagesAsync(_examsCollections.GetExamByIndex(5), resolution).ConfigureAwait(false);
        }

        public async Task LoadImagesAsync(List<FileInfo> examsList, int resolution)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            _images.Clear();
            _main.SetLoadingState(true);

            var token = _cts.Token;
            var dicomReader = new DicomService();

            void onImageLoaded(Bitmap bmp, int index, int total)
            {
                try
                {
                    var value = index + 1;
                    //_main.pbImage.Invoke(() =>
                    _main.UI(() =>
                        {
                            if (!_cts.IsCancellationRequested)
                            {
                                _images.Add(bmp);
                               
                                if (index == 0)
                                {
                                    _total = total;
                                    _main.SetTrackbar(_total - 1);
                                    DisplayImage(index);
                                }

                                _main.UpdateLoadCounter(value, _total);
                                _main.UpdateProgressBar(value, _total);
                            }

                        });
                }
                catch { }
            }

            try
            {
                if (!_cts.IsCancellationRequested)
                    await dicomReader.LoadAsync(examsList, _main.ImageAreaSize, resolution, token, onImageLoaded);
            }
            catch { }

        }

        private async Task GetExamsSeparatedAsync(string path, int resolution)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            _main.SetLoadingState(true);

            var token = _cts.Token;

            try
            {
                var reader = new DicomService(path);
                _examsCollections = await reader.SeparateExams(token, (index, total) =>
                {
                    try
                    {
                        _main.UI(() =>
                         {
                             if (!_cts.IsCancellationRequested)
                             {

                                 _main.UpdateLoadCounter(index + 1, total);
                                 _main.UpdateProgressBar(index + 1, total);
                             }
                         });
                    }

                    catch { }

                }).ConfigureAwait(false);



            }

            catch (OperationCanceledException) { }
            finally
            {
                //_main.SetLoadingState(false);
            }
        }

        public void DisplayImage(int index)
        {
            try
            {
                if (index < 0 || index >= _total)
                    return;

                if (index < _images.Count)
                    _main.ShowImage(_images[index]);

                _main.UpdateExamCounter(index + 1, _total);
                _main.SetTrackbarValue(index);
            }
            catch { }
        }

        public async Task SaveAsync(string path, int resolution)
        {
            if (_images.Count == 0)
                return;

            _cts ??= new CancellationTokenSource();
            var token = _cts.Token;

            _main.SetSavingState(true);

            var saver = new ImageSaver();

            try
            {
                await saver.SaveAsync(_images,
                                       path,
                                       resolution,
                                       progress => _main.UpdateProgressBar(progress, _images.Count),
                                       token);
            }

            catch (OperationCanceledException) { }

            finally
            {
                _main.SetSavingState(false);
            }
        }

        public void Cancel()
        {
            _cts?.CancelAsync();
            _images.Clear();
            _examsCollections = null;
        }

        private void AddExamsControl()
        {
            foreach (var exam in _examsCollections!.Exams)
            {
                var firstFile = exam.Value[0].File.FullName;

            }
        }
    }
}
