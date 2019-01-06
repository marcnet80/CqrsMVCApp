using System;

namespace CqrsApp.Models
{
    public class UploadImgModel
    {
        public Guid PlayerId { get; set; }
        public bool IsImgUploaded { get; set; }
    }
}