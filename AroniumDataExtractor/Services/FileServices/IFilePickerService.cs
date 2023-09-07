namespace AroniumDataExtractor.Services.FileServices
{
    public interface IFilePickerService
    {
        Task<FileResult> PickAndShow(PickOptions options);
    }
}