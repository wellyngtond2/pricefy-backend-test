namespace PricefyChallenge.Core.Dto
{
    public sealed class FileUploadDto
    {
        public FileUploadDto(string fileName, string contentType, byte[] data)
        {
            FileName = fileName;
            ContentType = contentType;
            Data = data;
        }

        public string FileName { get; }
        public string ContentType { get; }
        public byte[] Data { get; }
    }
}
