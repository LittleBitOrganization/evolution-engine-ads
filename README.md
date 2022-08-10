# Ads Module

Модуль предназначен для быстрой и простой интеграции рекламы в проекты. 
Поддерживаются следующие рекламные сети:
* <b> Applovin MaxSdk </b>

# Table of content

- [Ads Module](#ads-module)
- [Dependencies](#dependencies)
- [Quick Start](#quick-start)

# Dependencies

Добавьте следующие зависимости в <b> manifest.json </b>:

```json

"com.littlebitgames.ads" : "https://github.com/LittleBitOrganization/evolution-engine-ads.git",
"com.littlebitgames.environmentcore": "https://github.com/LittleBitOrganization/evolution-engine-environment-core-module.git",
"com.littlebitgames.coremodule": "https://github.com/LittleBitOrganization/evolution-engine-core.git",
"com.google.external-dependency-manager" : "https://github.com/LittleBitOrganization/evolution-engine-google-version-handler.git"

```

# Quick Start

1. Настройте необходимые рекламные сети в <b> Applovin Integration Manager </b>.

2. Создайте <b> Ads Config </b> с помощью меню <b> Tools/Configs/Ads Config </b>. 

![Alt text](https://github.com/LittleBitOrganization/documentation-resources/blob/master/evolution-engine-ads/documentation-images/toolbar-menu.png)

Конфиг будет создан по следующему пути - <b> Assets/Resources/Configs </b>
Установите значения для необходимых ключей:

![Alt text](https://github.com/LittleBitOrganization/documentation-resources/blob/master/evolution-engine-ads/documentation-images/ads-config.png)

3. Для подключения рекламы AppLovin Max используйте следующий инсталлер:

```c#
public override void InstallBindings()
        {
            Container
                .Bind<ICreator>()
                .To<CreatorInDiContainer>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle()
                .NonLazy();
           

            var maxSdkAds = Container.Instantiate<MaxSdkAds>();
            var adsService = maxSdkAds.CreateAdsService();
            var analytics = maxSdkAds.CreateAnalytics();

            Container
                .Bind<IAdsService>()
                .FromInstance(adsService)
                .AsSingle()
                .NonLazy();
            
            /* раскомментируйте, чтобы подключить аналитику
            
            Container
                .BindInterfacesAndSelfTo<EventsService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<AnalyticsInitializer>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IMediationNetworkAnalytics>()
                .FromInstance(analytics)
                .AsSingle()
                .NonLazy();
                
            Container
                .Bind<AdRevenueAnalytics>()
                .AsSingle()
                .NonLazy();
                
           */
        }

```

4. Покажите рекламу, используя метод <b> ShowAd() </b>

```c#

adsService.ShowAd(AdType.Inter, new AdUnitPlace("shop"), _ => Debug.Log("Gotcha!"));
adsService.ShowAd(AdType.Rewarded, new AdUnitPlace("booster"), _ => Debug.Log("Meow!"));

```
# Advanced

## Добавление новой рекламной сети

Для добавления новой рекламной сети необходимо следовать следующим шагам:

1. Реализовать IMediationNetworkInitializer, который будет создавать request на инициализацию.
2. Реализовать IAdUnit для необходимых видов рекламы (в основном это inter и rewarded)
3. "Скормить" это в AdsService (можно создать для этого свой IAdsServiceBuilder)

Как референс можно использовать соответствующие реализации для MaxSdk: <b> MaxSdkInitializer </b> , <b> MaxSdkInterAd </b> , <b> MaxSdkRewardedAd </b>, <b> MaxSdkAds </b>, <b> MaxSdkAdsServiceBuilder </b>
