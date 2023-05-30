namespace LittleBitGames.Ads.AdUnits
{
    public class AdErrorInfo
    {
        public string Message { get; private set; }
        public int MediatedNetworkErrorCode { get; private set; }
        public string MediatedNetworkErrorMessage { get; private set; }
        
        public AdErrorInfo(MaxSdkBase.ErrorInfo errorInfo)
        {
            Message = errorInfo.Message;
            MediatedNetworkErrorCode = errorInfo.MediatedNetworkErrorCode;
            MediatedNetworkErrorMessage = errorInfo.MediatedNetworkErrorMessage;
        }
        
        public AdErrorInfo()
        {
            
        }
    }
}