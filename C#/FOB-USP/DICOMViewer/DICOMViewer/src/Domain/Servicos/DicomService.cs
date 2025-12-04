using DICOMViewer.Domain.Models;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using System.Collections.Concurrent;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace DICOMViewer.Domain.Servicos
{
    public class DicomService
    {
        private readonly string? _path;

        public DicomService() { }
        public DicomService(string path) => _path = path;

        public Bitmap GetDicomImage(FileInfo file, Size targetSize, int resolution)
        {
            var ds = DicomFile.Open(file.FullName).Dataset;
            using var rendered = new DicomImage(ds).RenderImage().AsSharedBitmap();

            var bmp = new Bitmap(rendered, targetSize);
            bmp.SetResolution(resolution, resolution);

            using (var g = Graphics.FromImage(bmp))
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(rendered, 0, 0, targetSize.Width, targetSize.Height);
            }

            return bmp;
        }

        public async Task LoadAsync(List<FileInfo> files,
                                    Size targetSize,
                                    int resolution,
                                    CancellationToken token,
                                    Action<Bitmap, int, int>? onImageLoaded = null)
        {
            if (files == null || files.Count == 0)
                return;

            int totalFiles = files.Count;
            var results = new Bitmap?[totalFiles];

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                CancellationToken = token
            };

            int deliveryIndex = 0;
            object lockObj = new object();

            var uiContext = SynchronizationContext.Current; // para atualizar UI no thread correto

            await Task.Run(() =>
            {
                Parallel.For(0, totalFiles, options, index =>
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();

                        var file = files[index];
                        var bmp = GetDicomImage(file, targetSize, resolution);
                        results[index] = bmp;

                        lock (lockObj)
                        {
                            while (deliveryIndex < totalFiles && results[deliveryIndex] != null)
                            {
                                var readyBmp = results[deliveryIndex];
                                if (readyBmp != null && onImageLoaded != null)
                                {
                                    onImageLoaded(readyBmp!,
                                                  deliveryIndex,
                                                  totalFiles);
                                }
                                deliveryIndex++;
                            }
                        }
                    }
                    catch (OperationCanceledException) { }
                    catch { }
                });
            });
        }



        // ULTIMA FORMA
        // public async Task LoadAsync(List<FileInfo> files,
        //                            Size targetSize,
        //                            int resolution,
        //                            CancellationToken token,
        //                            Action<Bitmap, int, int> onImageLoaded = null)
        // {
        //     if (files == null || files.Count == 0)
        //         return;

        //     var totalFiles = files.Count;
        //     var totalProcessed = 0;

        //     var options = new ParallelOptions
        //     {
        //         MaxDegreeOfParallelism = Environment.ProcessorCount,
        //         CancellationToken = token,
        //     };

        //     await Task.Run(() =>
        //     {
        //         // for (int index = 0; index < totalFiles; index++)
        //         // {
        //         //     try
        //         //     {
        //         //         token.ThrowIfCancellationRequested();

        //         //         var file = files[index];
        //         //         var bmp = GetDicomImageAsync(file, targetSize, resolution);
        //         //         onImageLoaded(bmp,
        //         //                      Interlocked.Increment(ref totalProcessed),
        //         //                      totalFiles);
        //         //     }

        //         //     catch (OperationCanceledException) { }
        //         //     catch { }
        //         // }


        //         Parallel.For(0, totalFiles, options, index =>
        //         {
        //             try
        //             {
        //                 token.ThrowIfCancellationRequested();

        //                 var file = files[index];
        //                 var bmp = GetDicomImage(file, targetSize, resolution);

        //                 //concurrentDictionary[index] = bmp;
        //                 onImageLoaded(bmp,
        //                              Interlocked.Increment(ref totalProcessed),
        //                              totalFiles);
        //             }

        //             catch (OperationCanceledException) { }
        //             catch { }
        //         });

        //     });

        // }

        //  public async Task LoadAsync(List<FileInfo> files,
        //                              Size targetSize,
        //                              int resolution,
        //                              CancellationToken token,
        //                              Action<Bitmap, int, int>? onImageLoaded = null)
        // {
        //     if(files == null || files.Count == 0)
        //         return;
        //     var totalFiles = files.Count;
        //     var concurrentDictionary = new ConcurrentDictionary<int, Bitmap>();
        //     int maxDegree = Environment.ProcessorCount;
        //     using var semaphoreSlim = new SemaphoreSlim(maxDegree);
        //     var tasks = new List<Task>(totalFiles);

        //     for(int index = 0; index < totalFiles; index++)
        //     {
        //         token.ThrowIfCancellationRequested();
        //         //int index = i;
        //         var file = files[index];

        //         await semaphoreSlim.WaitAsync(token).ConfigureAwait(false);

        //         tasks.Add(Task.Run(async () =>
        //         {
        //             try
        //             {
        //                 token.ThrowIfCancellationRequested();
        //                 var dicomFile = await DicomFile.OpenAsync(file.FullName).ConfigureAwait(false);
        //                 var ds = dicomFile.Dataset;
        //                 ds.AutoValidate = false;

        //                 var dicomImage = new DicomImage(ds);
        //                 using var rendered = dicomImage.RenderImage().AsSharedBitmap();

        //                 var bmp = new Bitmap(targetSize.Width, targetSize.Height, PixelFormat.Format24bppRgb);
        //                 bmp.SetResolution(resolution, resolution);

        //                 using(var g = Graphics.FromImage(bmp))
        //                 {
        //                     g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //                     g.DrawImage(rendered, 0, 0, targetSize.Width, targetSize.Height);
        //                 }

        //                 concurrentDictionary[index] = bmp;

        //                 // if (onImageLoaded != null && (index % ReportInterval == 0 || index == totalFiles - 1))
        //                 if(onImageLoaded != null)
        //                     onImageLoaded(bmp, index + 1, totalFiles);

        //             }

        //             catch(OperationCanceledException) { }
        //             catch { }

        //             finally
        //             {
        //                 semaphoreSlim.Release();
        //             }
        //         }, token));
        //     }
        // }

        public async Task<ExamsCollection> SeparateExams(CancellationToken token,
                                                         Action<int, int>? onExamsSeparated = null)
        {
            if (string.IsNullOrEmpty(_path))
                throw new InvalidOperationException("Caminho não fornecido para SeparateExams.");

            var examsCollection = new ExamsCollection();

            var files = new DirectoryInfo(_path)
                .GetFiles("*.*")
                .OrderBy(f => f.FullName)
                .ToArray();

            var totalFiles = files.Length;
            var totalProcessed = 0;

            var options = new ParallelOptions
            {
                CancellationToken = token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            await Task.Run(() =>
            {
                try
                {
                    Parallel.For(0, totalFiles, options, i =>
                    {
                        try
                        {
                            var file = files[i];
                            token.ThrowIfCancellationRequested();

                            var dicom = DicomFile.Open(file.FullName);
                            var ds = dicom.Dataset;
                            ds.AutoValidate = false;

                            var examName = ds.GetSingleValueOrDefault(DicomTag.SeriesDescription, "Exame Desconhecido");
                            var instance = ds.GetSingleValueOrDefault<int>(DicomTag.InstanceNumber, 0);

                            var info = new ExamsInfo { File = file, InstanceNumber = instance };

                            examsCollection.Exams.AddOrUpdate(
                                examName,
                                new List<ExamsInfo> { info },
                                (_, list) =>
                                {
                                    lock (list)
                                        list.Add(info);
                                    return list;
                                }
                            );

                            onExamsSeparated?.Invoke(Interlocked.Increment(ref totalProcessed) - 1,
                                                     totalFiles);
                        }
                        catch (OperationCanceledException) { }
                        catch { }

                    });

                }
                catch (OperationCanceledException) { }

            }).ConfigureAwait(false);

            token.ThrowIfCancellationRequested();

            foreach (var key in examsCollection.Exams.Keys)
            {
                var list = examsCollection.Exams[key];
                lock (list)
                {
                    list.Sort((a, b) => a.InstanceNumber.CompareTo(b.InstanceNumber));
                }
            }

            return examsCollection;
        }
    }
}