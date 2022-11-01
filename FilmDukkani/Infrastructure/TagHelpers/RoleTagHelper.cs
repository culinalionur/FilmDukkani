using FilmDukkani.Models.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmDukkani.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-membership")]
    public class RoleTagHelper : TagHelper
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleTagHelper(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HtmlAttributeName("user-membership")]
        public string RoleId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await _roleManager.FindByNameAsync(RoleId);

            if (role != null)
            {
                foreach (User user in _userManager.Users)
                {
                    if (user != null && await _userManager.IsInRoleAsync(user , role.Name))
                    {
                        names.Add(user.UserName);
                    }

                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(',', names));

        }

    }
}
