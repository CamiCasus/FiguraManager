namespace Infrastructure.CrossCutting.Resources.Core
{
    public interface IResourceProvider
    {
        string GetResource(string name, string culture);
        string GetResource(string prefix, string name, string culture);
    }
}