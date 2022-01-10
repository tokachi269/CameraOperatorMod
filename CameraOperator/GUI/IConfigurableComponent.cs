namespace CamOpr.GUI
{
    interface IConfigurableComponent<ConfigT>
        where ConfigT : IConfig
    {
        ConfigT Config { get; set; }
    }
}
