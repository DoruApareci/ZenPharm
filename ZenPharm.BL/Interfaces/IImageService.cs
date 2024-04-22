using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenPharm.BL.Interfaces;

public interface IImageService
{
    ImageUploadResult AddPhoto(IFormFile file);
    DeletionResult DeletePhoto(string publicId);
}
