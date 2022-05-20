using System;

namespace LittleBit.Modules.Ads
{
    public interface IAdUnit
    {
        public event Action<bool> OnFinish;
        public void Show();
        public void Initialize(ApplovinSettings applovinSettings);
    }
}
