# Ads Module

Модуль предназначен для быстрой и простой интеграции рекламы в проекты. 
Поддерживаются следующие рекламные сети:
* <b> Applovin MaxSdk </b>

# Table of content

- [Ads Module](#ads-module)
- [Dependencies](#dependencies)
- [Quick Start](#quick-start)
- [Analytics](#analytics)

# Dependencies

Добавьте следующие зависимости в <b> manifest.json </b>:

```json

"com.littlebitgames.ads" : "https://github.com/github.com/LittleBitOrganization/evolution-engine-ads.git#2.0.0",
"com.littlebitgames.environmentcore": "https://github.com/LittleBitOrganization/evolution-engine-environment-core-module.git#1.0.1",
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

3. Инстанцируйте необходимый <b> IAdsServiceBuilder </b> для вашей рекламной сети, используя созданный ранее <b> AdsConfig </b>:

* MaxSdk:

```c#

var builder = new MaxSdkAdsServiceBuilder(adsConfig, coroutineRunner);

```

4. Настройте будущий <b> IAdsService </b> (ниже мы указываем, что хотим подключить как inter, так и rewarded типы реклам) :

```c#

builder.BuildInterAdUnit();
builder.BuildRewardedAdUnit();

```

Эти методы можно не вызывать вообще, но тогда при попытке отобразить рекламу ничего не произойдет, хотя и ошибка выполнения не будет вызвана.

5. Получите IAdsService и запустите его:

```c#

var adsService = builder.GetResult();
adsService.Run()

```

Метод <b> Run() </b> инициализирует рекламную сеть и начинает загружать рекламу. 

6. Покажите рекламу, используя метод <b> ShowAd() </b>

```c#

adsService.ShowAd(AdType.Inter, new AdUnitPlace("shop"), _ => Debug.Log("Gotcha!"));
adsService.ShowAd(AdType.Rewarded, new AdUnitPlace("booster"), _ => Debug.Log("Meow!"));

```


# Analytics
 
Используйте класс, реализующий IMediationNetworkAnalytics, который соответствует необходимой вам рекламной сети. 

* Для MaxSdk это MaxSdkAnalytics:

```c#

var analytics = new MaxSdkAnalytics();

analytics.OnAdRevenuePaidEvent += dataEventAdImpression => *** метод отправления события в аналитику ***

```

# Advanced

## Добавление новой рекламной сети

Для добавления новой рекламной сети необходимо следовать следующим шагам:

1. Реализовать IMediationNetworkInitializer, который будет делать запрос API на инициализацию.
2. Реализовать IAdUnit для необходимых видов рекламы (в основном это inter и rewarded)
3. "Скормить" это в AdsService (можно создать для этого свой IAdsServiceBuilder)

Как референс можно использовать соответствующие реализации для MaxSdk: <b> MaxSdkInitializer </b> , <b> MaxSdkInterAd </b> , <b> MaxSdkRewardedAd </b>.
