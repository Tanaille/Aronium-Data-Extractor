namespace AroniumDataExtractor.Services.FileServices
{
    /// <summary>
    /// Provides file picking services.
    /// </summary>
    public class FilePickerService : IFilePickerService
    {
        /// <summary>
        /// Creates a file picker window.
        /// </summary>
        /// <param name="options">Additional options for the file picker (such as custom file extensions).</param>
        /// <returns></returns>
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
                    ex.Data.Add("UserMessage", "The user cancelled the file selection. " +
                        "See the log file for more information.");

                throw;
            }
        }
    }
}
