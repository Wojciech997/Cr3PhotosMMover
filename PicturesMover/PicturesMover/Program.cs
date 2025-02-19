internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Lets Start");
        var jpgFilesSourceDir = "put your jpg path here";
        var cr3FilesSourceDir = "put your cr3source path here";
        var cr3DestDir = "put your cr3 dest path here";
        var cr3FilesNames = new List<string>();
        var jpgFilesNames = Directory.GetFiles(jpgFilesSourceDir).ToList();
        foreach (var fileName in jpgFilesNames)
        {
            var jpgFileName = Path.GetFileNameWithoutExtension(fileName);
            if (jpgFileName != null)
            {
                cr3FilesNames.Add(jpgFileName+".cr3");
            }
        }
        
        foreach (var cr3File in cr3FilesNames)
        {
            try
            {
                string sourcePath = cr3FilesSourceDir + "\\" + cr3File;
                string destinationPath = cr3DestDir + "\\" + cr3File;
                var sourceExist = File.Exists(sourcePath);
                var destinationExist = File.Exists(destinationPath);
                if (sourceExist && !destinationExist)
                {
                    File.Move(sourcePath, destinationPath);
                    Console.WriteLine($"Moved {cr3File} to {cr3DestDir}");   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
    }
}