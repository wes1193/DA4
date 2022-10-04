using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        private API.Extensions.LoggingExtensions _Logger = null;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] PhotoService - Constructor") ;
            var acc =  new Account(
                config.Value.CloudName, 
                config.Value.ApiKey, 
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);

            _Logger = new API.Extensions.LoggingExtensions();
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            Console.WriteLine("PhotoService - AddPhotoAsync") ;

            var uploadResult = new CloudinaryDotNet.Actions.ImageUploadResult();

            if(file.Length > 0)
            {   using  var stream = file.OpenReadStream();
                var uploadParams = new  ImageUploadParams 
                {
                    File = new FileDescription(file.FileName, stream), 
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                Console.WriteLine(" PhotoService - AddPhotoAsync -  uploading....") ;
                uploadResult =  await  _cloudinary.UploadAsync(uploadParams);  // now upload the file
                Console.WriteLine(" PhotoService - AddPhotoAsync -  uploading complete") ;
            }
            
            Console.WriteLine(" PhotoService - AddPhotoAsync - stop - return\n\n") ;
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            Console.WriteLine(" PhotoService - DeletePhotoAsync") ;            
            var deleteParams = new CloudinaryDotNet.Actions.DeletionParams(publicId);
            var result = await  _cloudinary.DestroyAsync(deleteParams);

            Console.WriteLine(" PhotoService - DeletePhotoAsync - stop - return\n\n") ;
            return result;
        }
    }
}