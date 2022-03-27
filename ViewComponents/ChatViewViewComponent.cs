using Microsoft.AspNetCore.Mvc;

namespace PreventDeskTool.ViewComponents
{
    public class ChatViewViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
