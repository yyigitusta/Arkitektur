using Amazon.S3;
using Amazon.S3.Model;
using Artitektur.Business.BaseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.FileServices
{
    public class FileService(IAmazonS3 _s3Client,IConfiguration configuration) : IFileService
    {
        private readonly string bucketName=configuration["AWS:BucketName"];
        public async Task<BaseResult<object>> UploadImageToS3Async(IFormFile? file)
        {
            if(file == null || file.Length == 0)
            {
                return BaseResult<object>.Fail("No file provided.");
            }
            await _s3Client.EnsureBucketExistsAsync(bucketName);
            var key=$"{Guid.NewGuid()}_{file.FileName}";
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = file.OpenReadStream(),
                CannedACL = S3CannedACL.PublicRead
            };
            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            string fileUrl = $"https://{bucketName}.s3.{_s3Client.Config.RegionEndpoint.SystemName}.amazonaws.com/{key}";
            return BaseResult<object>.Success(fileUrl);

        }
    }
}
