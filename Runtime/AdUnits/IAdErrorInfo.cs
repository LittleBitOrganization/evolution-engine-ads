namespace LittleBitGames.Ads.AdUnits
{
    public interface IAdErrorInfo
    {
        public string Message { get;}
        public int MediatedNetworkErrorCode { get;}
        public string MediatedNetworkErrorMessage { get;}
    }
}