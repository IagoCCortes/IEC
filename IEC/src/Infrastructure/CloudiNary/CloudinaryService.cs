// using System.Threading.Tasks;
// using CloudinaryDotNet;
// using CloudinaryDotNet.Actions;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Options;

// namespace Infrastructure.CloudiNary
// {
//     public class CloudinaryService
//     {
//         private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
//         private readonly Cloudinary _cloudinary;

//         public CloudinaryService(IOptions<CloudinarySettings> cloudinaryConfig)
//         {
//             _cloudinaryConfig = cloudinaryConfig;

//             Account acc = new Account(
//                 _cloudinaryConfig.Value.CloudName,
//                 _cloudinaryConfig.Value.ApiKey,
//                 _cloudinaryConfig.Value.ApiSecret
//             );

//             _cloudinary = new Cloudinary(acc);
//         }

//         public string[] UploadImage(IFormFile file)
//         {
//             var uploadResult = new ImageUploadResult();

//             if(file.Length > 0) {
//                 using(var stream = file.OpenReadStream()) {
//                     var uploadParams = new ImageUploadParams() {
//                         File = new FileDescription(file.Name, stream),
//                         Transformation = new Transformation()
//                             .Width(500)
//                     };

//                     uploadResult = _cloudinary.Upload(uploadParams);
//                 }
//             }else
//                 return null;

//             return new string[] {
//                 uploadResult.Uri.ToString(),
//                 uploadResult.PublicId
//             };
//         }

//         public async Task<bool> DeleteImage(string publicId)
//         {
//             var deleteParams = new DeletionParams(publicId);
//             var result = await _cloudinary.DestroyAsync(deleteParams);
//             if(result.Result == "ok")
//                 return true;

//             return false;
//         }
//     }
// }