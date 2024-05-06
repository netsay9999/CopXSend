using Aliyun.OSS;
using System;
using System.IO;

namespace H.Saas.Tools
{
    /// <summary>
    /// 阿里云 OSS 文件上传
    /// </summary>
    public class AliyunOssUpload
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="accessKeyId"></param>
        /// <param name="accessKeySecret"></param>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="fileExt"></param> 
        /// <param name="filePathToUpload"></param> 
        /// <returns>文件名称</returns>
        public static bool UploadFile(string endpoint, string accessKeyId, string accessKeySecret, string bucketName, string key, string fileExt, string filePathToUpload)
        {
            var result = true;
            try
            {
                fileExt = fileExt.TrimStart('.').ToLower();
                var contentType = GetContentType(fileExt);
                var metadata = new ObjectMetadata();
                if (!string.IsNullOrEmpty(contentType))
                {
                    metadata.ContentType = contentType;
                }
                var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                client.PutObject(bucketName, key, filePathToUpload, metadata);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// 获取鉴权url
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="accessKeyId"></param>
        /// <param name="accessKeySecret"></param>
        /// <param name="bucketName"></param>
        /// <param name="fileName"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static string GetFile(string endpoint, string accessKeyId, string accessKeySecret, string bucketName, string fileName, int days = 3600)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            var key = fileName;
            var req = new GeneratePresignedUriRequest(bucketName, key, SignHttpMethod.Get)
            {
                Expiration = DateTime.Now.AddDays(days)
            };
            var tempurl = client.GeneratePresignedUri(req).ToString().Split("?");
            return tempurl[0];
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="accessKeyId"></param>
        /// <param name="accessKeySecret"></param>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="fileExt">文件扩展名称</param> 
        /// <param name="fileStream"></param>
        /// <returns>文件名称</returns>
        public static bool UploadFile(string endpoint, string accessKeyId, string accessKeySecret, string bucketName, string key, string fileExt, Stream fileStream)
        {
            var result = true;

            try
            {
                fileExt = fileExt.TrimStart('.').ToLower();
                var contentType = GetContentType(fileExt);
                var metadata = new ObjectMetadata();
                if (!string.IsNullOrEmpty(contentType))
                {
                    metadata.ContentType = contentType;
                }

                var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                client.PutObject(bucketName, key, fileStream, metadata);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        private static string GetContentType(string fileExt)
        {
            var contentType = "";
            switch (fileExt)
            {
                case "jpeg":
                case "jpe":
                case "jpg":
                    contentType = "image/jpeg";
                    break;
                case "bmp":
                    contentType = "image/bmp";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                case "gif":
                    contentType = "image/gif";
                    break;
                case "ico":
                    contentType = "image/x-icon";
                    break;
                case "net":
                    contentType = "image/pnetvue";
                    break;
                case "tif":
                case "tiff":
                    contentType = "image/tiff";
                    break;
            }
            return contentType;
        }
    }
}
