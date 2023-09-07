namespace AroniumDataExtractor.Services.FileServices
{
    public class FilePickerService : IFilePickerService
    {
        public async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);

                return result;
            }
            catch (Exception ex)
            {
                if (!ex.Data.Contains("UserMessage"))
                    ex.Data.Add("UserMessage", "The user cancelled the databse file selection. " +
                        "See the log file for more information.");

                throw;
            }
        }
    }
}
