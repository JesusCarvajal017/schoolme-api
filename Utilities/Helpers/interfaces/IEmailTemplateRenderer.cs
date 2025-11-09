namespace Utilities.Helpers.interfaces
{
    public interface IEmailTemplateRenderer
    {
        Task<string> RenderAsync<TModel>(string templateKey, TModel model);
    }
}
