using System.Collections.Concurrent;

namespace DICOMViewer.Domain.Models
{
    public class ExamsCollection
    {
        public ConcurrentDictionary<string, List<ExamsInfo>> Exams { get; set; } = new();
        // public int InstanceNumberTag { get; set; }


        public List<FileInfo> GetExamById(string examId)
         => Exams.TryGetValue(examId, out var files) ? files.Select(x => x.File).ToList()
                                                     : new List<FileInfo>();

        public List<FileInfo> GetExamByIndex(int index)
          => Exams.ElementAt(index)
                  .Value
                  .Select(x => x.File)
                  .ToList();
    }


    public class ExamsInfo
    {
        public FileInfo File { get; set; } = null!;
        public int InstanceNumber { get; set; }
    }
}