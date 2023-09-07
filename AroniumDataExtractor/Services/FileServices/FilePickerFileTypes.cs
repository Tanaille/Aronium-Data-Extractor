namespace AroniumDataExtractor.Services.FileServices
{
    public class FilePickerFileTypes : IFilePickerFileTypes
    {
        public PickOptions PickOptions { get; }

        public FilePickerFileTypes()
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".db" } }, // SQLite database file extension
                });

            PickOptions = new PickOptions
            {
                PickerTitle = "Please select a database file",
                FileTypes = customFileType,
            };
        }
    }
}
