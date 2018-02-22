namespace Vidalink
{
    public static class Services
    {
        public static Bll.Task Task { get { return FastLibrary.Service.ServiceLocator<Bll.Task>.Default; } }
        public static Bll.User User { get { return FastLibrary.Service.ServiceLocator<Bll.User>.Default; } }
    }
}
