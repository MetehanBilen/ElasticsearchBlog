using ElasticsearchBlog.Services;
using ElasticsearchBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchBlog.Controllers
{
    public class BlogController : Controller
    {

        private BlogService blogService;

        public BlogController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogCreateViewModel model)
        {
            var isSuccess = await blogService.SaveAsync(model);

            if (!isSuccess) 
            {
                TempData["result"] = "kayıt başarısız";
                return RedirectToAction(nameof(BlogController.Save));
            }



            TempData["result"] = "kayıt başarılı";
            return RedirectToAction(nameof(BlogController.Save));
        }
    }
}
