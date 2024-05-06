namespace H.Saas.Apis
{
    internal class OssClient
    {
        private string endpoint;
        private string accessKeyId;
        private string accessKeySecret;

        public OssClient(string endpoint, string accessKeyId, string accessKeySecret)
        {
            this.endpoint = endpoint;
            this.accessKeyId = accessKeyId;
            this.accessKeySecret = accessKeySecret;
        }
    }
}