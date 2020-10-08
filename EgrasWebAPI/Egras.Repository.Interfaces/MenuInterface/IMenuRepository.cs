using Egras.Entities;
using System.Collections.Generic;

namespace Egras.Repository.Interfaces
{
    public interface IMenuRepository
    {
        bool AddMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool DeleteMenu(int menuId);
        IList<Menu> GetAllMenu();
        Menu GetMenuById(int menuId);
        Menu GetMenuByUserId(int UserId);
    }
}
