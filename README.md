# Ads Module

Модуль предназначен для быстрой и простой интеграции рекламы в проекты. 
Поддерживаются следующие рекламные сети:
* <b> Applovin MaxSdk </b>

# Table of content

- [Ads Module](#ads-module)
- [Dependencies](#dependencies)
- [Quick Start](#quick-start)
- [Additionally](#additionally)
- [Advanced](#advanced)
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
Установите значения для необходимых ключей.

![Alt text](https://github.com/LittleBitOrganization/documentation-resources/blob/master/evolution-engine-ads/documentation-images/ads-config.png)

3. Для подключения рекламы AppLovin Max через Zenject используйте следующий инсталлер:

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
    Container
        .Bind<SkipAdsCondition>()
        .FromInstance(IsSkipAds)
        .AsSingle()
        .NonLazy();
    Container
        .Bind<CommandAdsFactory>()
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

Также, если вы используеете Zenject вам необходимо создать класс [CreatorInDiContainer](https://github.com/LittleBitOrganization/documentation-resources/blob/master/evolution-engine/CreatorInDiContainer.md), если его нет в проекте.

4. Покажите рекламу, используя метод <b> ShowReward() </b> или <b> ShowInter() </b>. предварительно получив ссылку на <b> CommandAdsFactory </b>:

```c#
    private CommandAdsFactory _commandAdsFactory;

    [Inject]
    public void Constructor(CommandAdsFactory commandAdsFactory)
    {
        _commandAdsFactory = commandAdsFactory;
    }

    public void OnShowInter()
    {
        _commandAdsFactory
            .ShowInter(new AdUnitPlace("shop"))
            .Execute((isSuc) =>
            {
                if (isSuc)
                    Debug.LogError("Show Inter Ads - " + isSuc);
            });
    }
    
    public void OnShowRewarded()
    {
        _commandAdsFactory
            .ShowReward(new AdUnitPlace("booster"))
            .Execute((isSuc) =>
            {
                if (isSuc)
                    Debug.LogError("Show Reward Ads - " + isSuc);
            });
    }

```

# Additionally

## SkipAdsCondition

Делегат для пропуска рекламы по какому либо условию. Данный делегат передаётся в конструктор CommandAdsFactory, и предоставляет возможность сэмулировать просмотр рекламы, без просмотра рекламы, если SkipAdsCondition будет возвращать true.
Это позволяет реализовать механики NoAds или скипа за рекламные купоны.

```c#
Container
    .Bind<SkipAdsCondition>()
    .FromInstance(() => true)
    .AsSingle()
    .NonLazy();
```



## CompositeSkipAdCommand
Для реализации NoAds или пропуска рекламы например, за какие-нибудь игровые ресурсы вы можете создать ISkipCommand и его реализацию

```c#
public interface ISkipAdCommand
{
    public bool CanExecute { get; }

    public void Execute();
}

//Пример пропуска за рекламные купоны
public class SkipForTickets : ISkipAdCommand
{
    private readonly PlayerResourcesModel _playerResourcesModel;

    public SkipForTickets(PlayerResourcesModel playerResourcesModel) =>
        _playerResourcesModel = playerResourcesModel;

    public bool CanExecute => _playerResourcesModel.GetSlotData(ResourceIDs.Tickets).Value > 0;
        
    public void Execute() => _playerResourcesModel.Substract(ResourceIDs.Tickets, 1, "ads-service", "tickets-skip");
}
```

<b> Вы можете составить композицию скипов рекламы </b>

```c#
public class CompositeSkipAdCommand : ISkipAdCommand
{
    private readonly List<ISkipAdCommand> _commands;
    
    public CompositeSkipAdCommand() =>
        _commands = new();

    public bool CanExecute => _commands.Any(c => c.CanExecute);
    
    public void Execute()
    {
        var command = _commands.First(c => c.CanExecute);
        
        command.Execute();
    }

    public void Add(ISkipAdCommand command)
        => _commands.Add(command);
}
```

```c#
    Container
        .Bind<SkipAdsCondition>()
        .FromInstance(() => compositeSkipCommand.CanExecute)
        .AsSingle()
        .NonLazy();
    
    var compositeSkipCommand = Container.Instantiate<CompositeSkipAdCommand>();

    var skipForTickers = Container.Instantiate<SkipForTickets>();
    var noAdsSkipCommand = Container.Instantiate<SkipForNoAds>();

    compositeSkipCommand.Add(skipForTickers);
    compositeSkipCommand.Add(noAdsSkipCommand);

   
    commandAdsFactory.AdShowed += () =>
    {
        if(compositeSkipCommand.CanExecute) compositeSkipCommand.Execute();
    };
```

# Advanced

## Добавление новой рекламной сети

Для добавления новой рекламной сети необходимо следовать следующим шагам:

1. Реализовать IMediationNetworkInitializer, который будет создавать request на инициализацию.
2. Реализовать IAdUnit для необходимых видов рекламы (в основном это inter и rewarded)
3. "Скормить" это в AdsService (можно создать для этого свой IAdsServiceBuilder)

Как референс можно использовать соответствующие реализации для MaxSdk: <b> MaxSdkInitializer </b> , <b> MaxSdkInterAd </b> , <b> MaxSdkRewardedAd </b>, <b> MaxSdkAds </b>, <b> MaxSdkAdsServiceBuilder </b>
