using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// model for the About Us page, used in AboutUs.cshtml
/// </summary>
public class AboutUsModel : PageModel
{
    // Logger
    private readonly ILogger<AboutUsModel> _logger;



    /// <summary>
    /// default constructor
    /// </summary>
    /// <param name="logger"></param>
    public AboutUsModel(ILogger<AboutUsModel> logger)
    {
        _logger = logger;
    }

    //

    /// <summary>
    /// OnGet() does not have any functionality
    /// </summary>
    public void OnGet()
    {
    }
}
